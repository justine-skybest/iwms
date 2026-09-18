import { Injectable, inject } from '@angular/core';
import { Api } from '../../api/generated/api';
import {
  rackV2WarehouseIdGet,
  binRackIdGet
} from '../../api/generated/functions';
import {
  RackSummaryDto,
  BinSummaryDto
} from '../../api/generated/models';
import { WarehouseService } from '../../lib/services/warehouse.service';

export interface Warehouse3DData {
  racks: Rack3D[];
}

export interface Rack3D {
  id: number;
  name: string | null;
  bayCount: number;
  levelCount: number;
  bays: Bay3D[];
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
}

@Injectable({
  providedIn: 'root'
})
export class Warehouse3DViewerService {
  private api = inject(Api);
  private warehouseService = inject(WarehouseService);

  /**
   * 1. Fetches all racks for the active warehouse.
   * 2. Fetches all bins per rack by rack.id.
   * 3. Dynamically builds the Bay & Level hierarchy per rack based on BinSummaryDto metadata.
   */
  async fetchWarehouse3DData(): Promise<Warehouse3DData> {
    const warehouseId = await this.warehouseService.ensureInitialized();

    if (!warehouseId) {
      throw new Error('No warehouse selected. Please select a warehouse from the dropdown.');
    }

    // Step 1: Get all racks by warehouseId
    const racksResponse = await this.api.invoke(rackV2WarehouseIdGet, {
      id: warehouseId,
      page: 1,
      pageSize: 1000
    });
    const racks = (racksResponse.items ?? []) as RackSummaryDto[];

    // Step 2 & 3: For each rack, get bins by rackId and dynamically map hierarchy
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

        // Fetch all bins associated with this rack
        const rawBinResponse = await this.api.invoke(binRackIdGet, { id: rack.id });
        const rackBins: BinSummaryDto[] = Array.isArray(rawBinResponse)
          ? rawBinResponse
          : (rawBinResponse as { items?: BinSummaryDto[] })?.items 
            ?? (rawBinResponse ? [rawBinResponse as BinSummaryDto] : []);

        // Discover unique Bay numbers and Level numbers present in this rack's bins
        const bayNumbersSet = new Set<number>();
        const levelNumbersSet = new Set<number>();

        rackBins.forEach((bin) => {
          const bayNum = this.extractNumber(bin.bay);
          const levelNum = this.extractNumber(bin.level);
          if (bayNum !== null) bayNumbersSet.add(bayNum);
          if (levelNum !== null) levelNumbersSet.add(levelNum);
        });

        // Sort bay and level numbers sequentially (e.g. 1, 2, 3...)
        const sortedBayNumbers = Array.from(bayNumbersSet).sort((a, b) => a - b);
        const sortedLevelNumbers = Array.from(levelNumbersSet).sort((a, b) => a - b);

        // Build Bays -> Levels -> Bins hierarchy derived strictly from BinSummaryDto values
        const bay3DList: Bay3D[] = sortedBayNumbers.map((bayNum) => {
          const level3DList: Level3D[] = sortedLevelNumbers.map((levelNum) => {
            const levelBins: Bin3D[] = rackBins
              .filter(
                (b) =>
                  this.extractNumber(b.bay) === bayNum &&
                  this.extractNumber(b.level) === levelNum
              )
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
          levelCount: sortedLevelNumbers.length,
          bays: bay3DList
        };
      })
    );

    console.log(rack3DList)

    return { racks: rack3DList };
  }

  /**
   * Fetches all racks for the active warehouse
   */
  async fetchRacks(): Promise<RackSummaryDto[]> {
    const warehouseId = await this.warehouseService.ensureInitialized();

    if (!warehouseId) {
      throw new Error('No warehouse selected');
    }

    const response = await this.api.invoke(rackV2WarehouseIdGet, {
      id: warehouseId,
      page: 1,
      pageSize: 1000
    });

    return (response.items ?? []) as RackSummaryDto[];
  }

  private extractNumber(str: string | null | undefined): number | null {
    if (!str) return null;
    const match = str.match(/\d+/);
    return match ? parseInt(match[0], 10) : null;
  }
}