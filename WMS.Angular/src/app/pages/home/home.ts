import { Component, OnInit, ChangeDetectorRef, inject, effect, signal, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Api } from '../../api/generated/api';
import { getDashboardSummary } from '../../api/generated/functions';
import { DashboardSummaryDto } from '../../api/generated/models';
import { StatCardComponent } from '../../shared/components/stat-card/stat-card.component';
import { TableCardComponent } from '../../shared/components/table-card/table-card.component';
import { UtilBarComponent } from '../../shared/components/util-bar/util-bar.component';
import { IconComponent } from '../../shared/components/icon/icon.component';
import { WarehouseService } from '../../lib/services/warehouse.service';
import { PageHeaderComponent } from '../../shared/layout/page-header/page-header.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    StatCardComponent,
    TableCardComponent,
    UtilBarComponent,
    IconComponent,
    PageHeaderComponent
  ],
  templateUrl: './home.html'
})
export class HomeComponent implements OnInit {
  Math = Math;
  private warehouseService = inject(WarehouseService);
  private cdr = inject(ChangeDetectorRef);
  private api = inject(Api);

  summary = signal<DashboardSummaryDto | null>(null);
  isLoading = true;
  error = '';

  // Computed KPI metrics
  binUtilization = computed(() => {
    const data = this.summary();
    if (!data || !data.totalBins) return 0;
    return Math.round(((data.occupiedBins ?? 0) / data.totalBins) * 100);
  });

  totalPendingCheckIns = computed(() => {
    const data = this.summary();
    if (!data) return 0;
    return (data.pendingCheckInPallets ?? 0) + (data.pendingCheckInItems ?? 0);
  });

  constructor() {
    effect(() => {
      // Automatically refetch when selected warehouse changes
      this.warehouseService.selectedWarehouseId();
      void this.fetchData();
    });
  }

  ngOnInit(): void {
    void this.fetchData();
  }

  async fetchData(): Promise<void> {
    this.isLoading = true;
    this.error = '';
    this.cdr.markForCheck();

    const warehouseId = this.warehouseService.selectedWarehouseId() ?? undefined;

    try {
      const data = (await this.api.invoke(getDashboardSummary, { warehouseId })) as DashboardSummaryDto;
      this.summary.set(data);
    } catch (err) {
      console.error('Failed to load dashboard summary:', err);
      this.error = 'Unable to load dashboard metrics. Please try again.';
    } finally {
      this.isLoading = false;
      this.cdr.markForCheck();
    }
  }

  formatDate(dateStr?: string | null): string {
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

  getWarehouseUtilization(occupied = 0, total = 0): number {
    if (!total) return 0;
    return Math.round((occupied / total) * 100);
  }
}