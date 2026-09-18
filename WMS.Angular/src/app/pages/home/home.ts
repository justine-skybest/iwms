import { Component, OnInit, ChangeDetectorRef, inject, effect, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../api/generated/api';
import {
  warehouseV2Get,
  productV2Get,
  palletV2Get,
  receivingV2Get,
  checkinV2Get,
  manualpickingV2Get
} from '../../api/generated/functions';
import {
  WarehouseDetailsDto,
  WarehouseDetailsDtoPaginatedResponse,
  ProductSummaryDto,
  ProductSummaryDtoPaginatedResponse,
  PalletSummaryDtoPaginatedResponse,
  ReceivingSummaryDto,
  ReceivingSummaryDtoPaginatedResponse,
  CheckInSummaryDto,
  CheckInSummaryDtoPaginatedResponse,
  ManualPickingSummaryDto,
  ManualPickingSummaryDtoPaginatedResponse
} from '../../api/generated/models';
import { StatCardComponent } from '../../shared/components/stat-card/stat-card.component';
import { TableCardComponent } from '../../shared/components/table-card/table-card.component';
import { UtilBarComponent } from '../../shared/components/util-bar/util-bar.component';
import { IconComponent } from '../../shared/components/icon/icon.component';
import { WarehouseService } from '../../lib/services/warehouse.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    StatCardComponent,
    TableCardComponent,
    UtilBarComponent,
    IconComponent
  ],
  templateUrl: './home.html'
})
export class HomeComponent implements OnInit {
  Math = Math;

  private cdr = inject(ChangeDetectorRef);
  private api = inject(Api);
  private warehouseService = inject(WarehouseService);

  get currentDate(): string {
    return new Date().toLocaleDateString('en-US', {
      weekday: 'long',
      year: 'numeric',
      month: 'long',
      day: 'numeric'
    });
  }

  formatDate(dateStr?: string): string {
    if (!dateStr) return 'Unknown';
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

  isLoading = true;
  error = '';

  // KPI signals
  totalPallets = signal(0);
  totalWarehouses = signal(0);
  pendingReceiving = signal(0);
  totalProducts = signal(0);
  totalPalletsSignal = signal(0);
  totalCheckIns = signal(0);

  // Warehouse breakdown
  warehouseBreakdown = signal<Array<{
    warehouse: string;
    pallets: number;
    utilization: number;
    pending: number;
  }>>([]);

  // Recent data
  recentReceivings = signal<Array<{
    series: string;
    warehouse: string | null;
    shipper: string | null;
    dateReceived: string | null;
  }>>([]);

  recentCheckIns = signal<Array<{
    series: string;
    warehouse: string | null;
    dateReceived: string | null;
  }>>([]);

  recentPickOrders = signal<Array<{
    id?: number;
    bin?: string;
    warehouse?: string | null;
    pickingDate?: string | null;
  }>>([]);

  recentProducts = signal<Array<{
    series: string;
    seriesId: string;
    qty: number;
    expiration: string;
    status: string;
  }>>([]);

  // Receiving pagination metadata
  receivingPage = 1;
  receivingPageSize = 5;
  receivingTotalCount = 0;
  receivingTotalPages = 0;

  constructor() {
    // Automatically refetch dashboard data whenever the global warehouse changes
    effect(() => {
      const activeId = this.warehouseService.selectedWarehouseId();
      if (activeId !== null) {
        void this.fetchData();
      }
    });
  }

  ngOnInit(): void {
    void this.fetchData();
  }

  async fetchData(): Promise<void> {
    this.isLoading = true;
    this.error = '';

    const params10 = this.warehouseService.withWarehouse({ page: 1, pageSize: 10 });
    const params5 = this.warehouseService.withWarehouse({ page: 1, pageSize: 5 });

    try {
      const [warehouses, products, pallets, receivings, checkIns, pickOrders] = await Promise.all([
        this.api.invoke(warehouseV2Get, { page: 1, pageSize: 10 }) as Promise<WarehouseDetailsDtoPaginatedResponse>,
        this.api.invoke(productV2Get, params10) as Promise<ProductSummaryDtoPaginatedResponse>,
        this.api.invoke(palletV2Get, params10) as Promise<PalletSummaryDtoPaginatedResponse>,
        this.api.invoke(receivingV2Get, params5) as Promise<ReceivingSummaryDtoPaginatedResponse>,
        this.api.invoke(checkinV2Get, params10) as Promise<CheckInSummaryDtoPaginatedResponse>,
        this.api.invoke(manualpickingV2Get, params10) as Promise<ManualPickingSummaryDtoPaginatedResponse>
      ]);

      // -----------------------------
      // KPI calculations
      // -----------------------------
      this.totalWarehouses.set(warehouses.totalCount ?? 0);
      this.totalProducts.set(products.totalCount ?? 0);
      this.totalPalletsSignal.set(pallets.totalCount ?? 0);
      this.totalPallets.set(pallets.totalCount ?? 0);
      this.pendingReceiving.set(receivings.totalCount ?? 0);
      this.totalCheckIns.set((checkIns.totalCount ?? 0));

      // -----------------------------
      // Warehouse breakdown
      // -----------------------------
      const breakdown = (warehouses.items ?? []).map((warehouse: WarehouseDetailsDto) => ({
        warehouse: warehouse.name ?? 'N/A',
        pallets: 0,
        utilization: 0,
        pending: 0
      }));
      this.warehouseBreakdown.set(breakdown);

      // -----------------------------
      // Recent receivings
      // -----------------------------
      const recentReceivingData = (receivings.items ?? []).map((receiving: ReceivingSummaryDto) => ({
        series: receiving.series || 'N/A',
        warehouse: receiving.warehouse || 'N/A',
        shipper: receiving.shipper ?? null,
        dateReceived: receiving.dateReceived ?? null
      }));
      this.recentReceivings.set(recentReceivingData);

      // -----------------------------
      // Recent check-ins
      // -----------------------------
      const recentCheckInData = (checkIns.items ?? []).map((checkIn: CheckInSummaryDto) => ({
        series: checkIn.palletNumber || 'N/A',
        warehouse: checkIn.bins?.[0]?.warehouse || 'N/A',
        dateReceived: checkIn.checkInDate ?? null
      }));
      this.recentCheckIns.set(recentCheckInData);

      // -----------------------------
      // Recent pick orders
      // -----------------------------
      const recentPickData = (pickOrders.items ?? []).map((pick: ManualPickingSummaryDto) => ({
        id: pick.id,
        bin: pick.bin || 'N/A',
        warehouse: pick.warehouse || 'N/A',
        pickingDate: pick.pickingDate ?? null
      }));
      this.recentPickOrders.set(recentPickData);

      // -----------------------------
      // Recent products
      // -----------------------------
      const recentProductsData = (products.items ?? []).map((product: ProductSummaryDto) => ({
        series: product.name || 'N/A',
        seriesId: product.id?.toString() || 'N/A',
        qty: product.weight ?? 0,
        expiration: 'N/A',
        status: 'ok'
      }));
      this.recentProducts.set(recentProductsData);

      // -----------------------------
      // Pagination metadata
      // -----------------------------
      this.receivingTotalCount = receivings.totalCount ?? 0;
      this.receivingTotalPages = receivings.totalPages ?? 0;

    } catch (error) {
      console.error('Failed to load dashboard data:', error);
      this.error = 'Unable to load dashboard data. Please try again.';
    } finally {
      this.isLoading = false;
      this.cdr.markForCheck();
    }
  }
}