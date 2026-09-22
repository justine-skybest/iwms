import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../api/generated/api';
import { warehouseV2Get } from '../../api/generated/functions';
import { WarehouseDetailsDto, WarehouseDetailsDtoPaginatedResponse } from '../../api/generated/models';

import { WarehouseService } from '../../lib/services/warehouse.service';
import { Router } from '@angular/router';
import { BoxIcon, ChevronLeft, ChevronRight, LucideAngularModule, PlusIcon, SearchIcon } from 'lucide-angular';
import { PageHeaderComponent } from '../../shared/layout/page-header/page-header.component';

@Component({
  selector: 'app-warehouses-list',
  standalone: true,
  imports: [CommonModule, FormsModule, LucideAngularModule, PageHeaderComponent],
  templateUrl: './warehouses-list.component.html',
})
export class WarehousesListComponent implements OnInit {
  Math = Math;
  readonly searchIcon = SearchIcon;
  readonly plus = PlusIcon;
  readonly chevronLeft = ChevronLeft;
  readonly chevronRight = ChevronRight;
  readonly boxIcon = BoxIcon;

  formatDate(dateStr?: string): string {
    if (!dateStr) return '—';
    try {
      return new Date(dateStr).toLocaleDateString('en-US', {
        month: 'short',
        day: '2-digit',
        year: 'numeric'
      });
    } catch {
      return dateStr;
    }
  }

  warehouses: WarehouseDetailsDto[] = [];
  isLoading = true;
  error = '';
  search = '';
  page = 1;
  pageSize = 10;
  totalCount = 0;
  totalPages = 0;

  constructor(
    private api: Api,
    private cd: ChangeDetectorRef,
    private router: Router,
    private warehouseService: WarehouseService
  ) {}

  ngOnInit(): void {
    // Explicit fetch on load, not chained through async/await in ngOnInit,
    // so a slow/failed request can't delay Angular's initial render.
    void this.loadWarehouses();
  }

  async loadWarehouses(): Promise<void> {
    this.isLoading = true;
    this.error = '';
    this.cd.markForCheck();

    // NOTE: confirm the actual query param name your generated warehouseV2Get
    // function expects for a text search (commonly `search`, `name`, or
    // `filterText`) and rename the key below to match. If the backend instead
    // exposes a separate filtered endpoint (like productV2FilterTextGet for
    // products), import and call that one when `search` is non-empty instead.
    const params: { page?: number; pageSize?: number; search?: string } = {
      page: this.page,
      pageSize: this.pageSize,
    };

    const trimmedSearch = this.search.trim();
    if (trimmedSearch) {
      params.search = trimmedSearch;
    }

    try {
      const response: WarehouseDetailsDtoPaginatedResponse = await this.api.invoke(
        warehouseV2Get,
        params
      );

      this.warehouses = response.items ?? [];
      this.totalCount = response.totalCount ?? 0;
      this.totalPages = response.totalPages ?? 0;

      if (this.warehouses.length === 0) {
        console.debug('loadWarehouses: request succeeded but returned 0 items', { params, response });
      }
    } catch (err) {
      this.error = 'Unable to load warehouses. Please try again.';
      console.error('Failed to load warehouses:', { params, search: this.search, err });
    } finally {
      this.isLoading = false;
      // Ensures the view updates even under OnPush change detection or a
      // zoneless setup, where mutating plain properties after an `await`
      // does not automatically trigger a re-render.
      this.cd.markForCheck();
    }
  }

  view3D(warehouse: WarehouseDetailsDto): void {
      if (warehouse.id !== undefined) {
        this.warehouseService.setWarehouse(warehouse.id);

        const url = this.router.serializeUrl(
          this.router.createUrlTree(['/warehouse-3d'], {
            queryParams: { warehouseId: warehouse.id }
          })
        );
        window.open(url);
      }
  }

  onSearch(): void {
    this.page = 1;
    void this.loadWarehouses();
  }

  goToPage(nextPage: number): void {
    this.page = Math.max(1, Math.min(nextPage, this.totalPages || 1));
    void this.loadWarehouses();
  }

  changePageSize(event: Event): void {
    this.pageSize = Number((event.target as HTMLSelectElement).value);
    this.page = 1;
    void this.loadWarehouses();
  }
}