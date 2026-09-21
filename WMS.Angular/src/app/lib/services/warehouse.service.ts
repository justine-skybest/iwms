import { Injectable, signal, computed, effect } from '@angular/core';
import { Api } from '../../api/generated/api';
import { warehouseV2Get } from '../../api/generated/functions';
import { WarehouseDetailsDto, WarehouseDetailsDtoPaginatedResponse } from '../../api/generated/models';

export const ALL_WAREHOUSES_OPTION: WarehouseDetailsDto = {
  name: 'All Warehouses',
  address: 'All locations'
};

@Injectable({
  providedIn: 'root'
})
export class WarehouseService {
  private readonly STORAGE_KEY = 'active_warehouse_id';

  warehouses = signal<WarehouseDetailsDto[]>([]);
  selectedWarehouseId = signal<number | null>(this.getInitialWarehouseId());
  isLoading = signal<boolean>(false);
  error = signal<string | null>(null);

  private initPromise: Promise<void> | null = null;

  activeWarehouse = computed<WarehouseDetailsDto>(() => {
    const id = this.selectedWarehouseId();
    if (id === null) {
      return ALL_WAREHOUSES_OPTION;
    }
    return this.warehouses().find((w) => w.id === id) ?? ALL_WAREHOUSES_OPTION;
  });

  constructor(private api: Api) {
    this.initPromise = this.fetchWarehouses();

    effect(() => {
      const id = this.selectedWarehouseId();
      if (id !== null && id !== undefined && !isNaN(id)) {
        localStorage.setItem(this.STORAGE_KEY, id.toString());
      } else {
        localStorage.removeItem(this.STORAGE_KEY);
      }
    });
  }

  /**
   * Ensures the initial API fetch finishes and returns a valid selected warehouse ID
   */
  async ensureInitialized(): Promise<number | null> {
    if (this.initPromise) {
      await this.initPromise;
    }
    return this.selectedWarehouseId();
  }

  async fetchWarehouses(): Promise<void> {
    this.isLoading.set(true);
    this.error.set(null);

    try {
      // Pass pageSize to ensure all items are fetched for the selector
      const response = (await this.api.invoke(warehouseV2Get, {
        pageSize: 1000
      })) as WarehouseDetailsDtoPaginatedResponse;

      // Unpack the items array from the paginated response wrapper
      const list = response?.items ?? [];
      this.warehouses.set(list);

      const currentId = this.selectedWarehouseId();
      
      // 'null' is a valid selection representing "All Warehouses"
      const isValid = currentId === null || list.some((w) => w.id === currentId);

      // Only fallback to list[0] if currentId is a non-null ID that no longer exists in the list
      if (!isValid && list.length > 0 && list[0].id !== undefined) {
        this.setWarehouse(list[0].id);
      }
    } catch (err) {
      console.error('Failed to load warehouses:', err);
      this.error.set('Unable to load warehouses.');
    } finally {
      this.isLoading.set(false);
    }
  }

  setWarehouse(id: number | null): void {
    if (this.selectedWarehouseId() !== id) {
      this.selectedWarehouseId.set(id);
    }
    // Direct sync write to avoid async signal effect delays during navigation
    if (id !== null && id !== undefined && !isNaN(id)) {
      localStorage.setItem(this.STORAGE_KEY, id.toString());
    } else {
      localStorage.removeItem(this.STORAGE_KEY);
    }
  }

  withWarehouse<T extends object>(dto: T): T & { warehouseId: number | undefined } {
    const id = this.selectedWarehouseId();
    return {
      ...dto,
      warehouseId: id ?? undefined
    };
  }

  private getInitialWarehouseId(): number | null {
    const saved = localStorage.getItem(this.STORAGE_KEY);
    if (!saved || saved === 'null' || saved === 'undefined') return null;
    const parsed = Number(saved);
    return isNaN(parsed) ? null : parsed;
  }
}