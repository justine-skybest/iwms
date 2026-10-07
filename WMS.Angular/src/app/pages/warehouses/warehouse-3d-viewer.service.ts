import { Injectable, inject } from '@angular/core';
import { Observable, firstValueFrom, from, of, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Api } from '../../api/generated/api';
import { rackV2WarehouseIdGet, binRackIdGet, getBinStockById } from '../../api/generated/functions';
import { RackSummaryDto, BinSummaryDto } from '../../api/generated/models';
import { WarehouseService } from '../../lib/services/warehouse.service';
import { ItemLocationSummaryDto } from '../../api/generated/models/item-location-summary-dto';
import { DisplayCheckInProductsDto } from '../../api/generated/models/display-check-in-products-dto';

export interface Warehouse3DData {
  racks: Rack3D[];
}

export interface Rack3D {
  id: number;
  name: string | null;
  bayCount: number;
  levelCount: number;
  bays: Bay3D[];
  isCrossDocking?: boolean;
  isMetalShelving?: boolean;
}

export interface Bay3D {
  id: number;
  bayNumber: number;
  levels: Level3D[];
}

export interface Level3D {
  id: number;
  levelNumber: number;
  bins: Bin3D[];
}

export interface Bin3D {
  id: number;
  binName: string | null;
  binHashCode: string | null;
  rack: string | null;
  bay: string | null;
  level: string | null;
  warehouse: string | null;
  dateAdded: string | null;
  isOccupied?: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class Warehouse3DViewerService {
  private api = inject(Api);
  private warehouseService = inject(WarehouseService);

  // Inventory cache to avoid repeated API hits
  private inventoryCache = new Map<number, ItemLocationSummaryDto[]>();

  async fetchWarehouse3DData(): Promise<Warehouse3DData> {
    const warehouseId = await this.warehouseService.ensureInitialized();

    if (!warehouseId) {
      throw new Error('No warehouse selected. Please select a warehouse from the dropdown.');
    }

    const racksResponse = await this.api.invoke(rackV2WarehouseIdGet, {
      id: warehouseId,
      page: 1,
      pageSize: 1000
    });
    const racks = ((racksResponse.items ?? []) as RackSummaryDto[]).filter((rack) => {
      const normalizedName = (rack.name ?? '').toLowerCase().replace(/[^a-z0-9]+/g, ' ').trim();
      return !/^cross\s*dock(?:ing)?\s*4$/.test(normalizedName);
    });

    const rack3DList: Rack3D[] = await Promise.all(
      racks.map(async (rack) => {
        if (!rack.id) {
          return {
            id: 0,
            name: rack.name ?? null,
            bayCount: 0,
            levelCount: 0,
            bays: []
          };
        }

        const rawBinResponse = await this.api.invoke(binRackIdGet, { id: rack.id });
        const rackBins: BinSummaryDto[] = Array.isArray(rawBinResponse)
          ? rawBinResponse
          : (rawBinResponse as { items?: BinSummaryDto[] })?.items 
            ?? (rawBinResponse ? [rawBinResponse as BinSummaryDto] : []);

        const normalizedRackName = (rack.name ?? '').toLowerCase().replace(/[^a-z0-9]+/g, ' ').trim();
        const isCrossDocking = /cross\s*dock|crossdock|cross docking/.test(normalizedRackName);
        const isMetalShelving = /metal\s*shelv|shelving/.test(normalizedRackName);

        const bayNumbersSet = new Set<number>();
        const levelNumbersSet = new Set<number>();

        rackBins.forEach((bin) => {
          const bayNum = this.extractNumber(bin.bay);
          const levelNum = isCrossDocking ? 1 : this.extractNumber(bin.level);
          if (bayNum !== null) bayNumbersSet.add(bayNum);
          if (levelNum !== null) levelNumbersSet.add(levelNum);
        });

        const sortedBayNumbers = Array.from(bayNumbersSet).sort((a, b) => a - b);
        const sortedLevelNumbers = isCrossDocking ? [1] : Array.from(levelNumbersSet).sort((a, b) => a - b);

        const bay3DList: Bay3D[] = sortedBayNumbers.map((bayNum) => {
          const level3DList: Level3D[] = sortedLevelNumbers.map((levelNum) => {
            const levelBins: Bin3D[] = rackBins
              .filter((b) => {
                const bBay = this.extractNumber(b.bay);
                const bLevel = isCrossDocking ? 1 : this.extractNumber(b.level);
                return bBay === bayNum && (isCrossDocking || bLevel === levelNum);
              })
              .map((bin) => ({
                id: bin.id ?? 0,
                binName: bin.binName ?? null,
                binHashCode: bin.binHashCode ?? null,
                rack: bin.rack ?? rack.name ?? null,
                bay: bin.bay ?? null,
                level: bin.level ?? null,
                warehouse: bin.warehouse ?? null,
                dateAdded: bin.dateAdded ?? null
              }));

            return {
              id: levelNum,
              levelNumber: levelNum,
              bins: levelBins
            };
          });

          return {
            id: bayNum,
            bayNumber: bayNum,
            levels: level3DList
          };
        });

        return {
          id: rack.id,
          name: rack.name ?? null,
          bayCount: sortedBayNumbers.length,
          levelCount: isCrossDocking ? 1 : sortedLevelNumbers.length,
          bays: bay3DList,
          isCrossDocking,
          isMetalShelving
        };
      })
    );

    return { racks: rack3DList };
  }

  async preloadBinInventory(racks: Rack3D[], concurrency = 8): Promise<void> {
    const seenBinIds = new Set<number>();
    const bins = racks
      .flatMap((rack) => rack.bays.flatMap((bay) => bay.levels.flatMap((level) => level.bins)))
      .filter((bin) => {
        if (bin.id <= 0 || seenBinIds.has(bin.id)) return false;
        seenBinIds.add(bin.id);
        return true;
      });
    let nextBinIndex = 0;

    const workers = Array.from({ length: Math.min(Math.max(1, concurrency), bins.length) }, async () => {
      while (nextBinIndex < bins.length) {
        const bin = bins[nextBinIndex++];
        try {
          const items = await firstValueFrom(this.fetchBinInventory(bin.id));
          bin.isOccupied = items.length > 0;
        } catch (err) {
          console.error(`Unable to preload stock status for bin ${bin.id}:`, err);
        }
      }
    });

    await Promise.all(workers);
  }

  /**
   * Fetches checked-in stock inside a bin using the generated getBinStockById API with local caching.
   */
  fetchBinInventory(binId: number, forceRefresh = false): Observable<ItemLocationSummaryDto[]> {
    if (!forceRefresh && this.inventoryCache.has(binId)) {
      return of(this.inventoryCache.get(binId)!);
    }

    return from(this.api.invoke(getBinStockById, { BinId: binId })).pipe(
      map((checkIns) => {
        const items = checkIns.flatMap((checkIn) =>
          (checkIn.receivedProducts ?? []).map((product) => ({
            checkInId: checkIn.id,
            productName: product.name ?? null,
            quantity: product.quantity,
            receivedProductId: product.id,
            receivingSeries: product.receivingSeries ?? null,
            typeOfPackage: product.typeOfPackage ?? null
          }))
        );
        this.inventoryCache.set(binId, items);
        return items;
      }),
      catchError((err) => {
        console.error(`Error fetching items for bin ${binId}:`, err);
        return throwError(() => err);
      })
    );
  }

  private extractNumber(str: string | null | undefined): number | null {
    if (!str) return null;
    const match = str.match(/\d+/);
    return match ? parseInt(match[0], 10) : null;
  }
}