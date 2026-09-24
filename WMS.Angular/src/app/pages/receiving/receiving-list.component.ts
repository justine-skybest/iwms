import { ChangeDetectorRef, Component, OnInit, inject, effect, Output, EventEmitter, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../api/generated/api';
import { receivingV2Get } from '../../api/generated/functions';
import { ReceivingSummaryDto, ReceivingSummaryDtoPaginatedResponse, ReceivedProductSummaryDto } from '../../api/generated/models';
import { WarehouseService } from '../../lib/services/warehouse.service';
import { ReceivingCreateComponent } from './create/receiving-create.component';
import { LucideAngularModule, ChevronLeft, ChevronRight, EyeIcon, SearchIcon, PlusIcon, AlertTriangle, FileSpreadsheet } from 'lucide-angular';
import { SignalRService } from '../../lib/services/signalr.service';
import { Subject, takeUntil } from 'rxjs';
import { PageHeaderComponent } from '../../shared/layout/page-header/page-header.component';
import { formatDate } from '../../lib/utils/format-date';
import { formatTime } from '../../lib/utils/format-time';

export type DiscrepancyCategory = 'QUANTITY' | 'DESCRIPTION' | 'EXPIRY' | 'WEIGHT' | 'CBM' | 'DAMAGED' | 'OTHER';

@Component({
  selector: 'app-receiving-list',
  standalone: true,
  imports: [CommonModule, FormsModule, ReceivingCreateComponent, LucideAngularModule, PageHeaderComponent],
  templateUrl: './receiving-list.component.html',
})
export class ReceivingListComponent implements OnInit, OnDestroy {
  @Output() closed = new EventEmitter<void>();
  Math = Math;
  readonly chevronLeft = ChevronLeft;
  readonly chevronRight = ChevronRight;
  readonly eyeIcon = EyeIcon;
  readonly searchIcon = SearchIcon;
  readonly plus = PlusIcon;
  readonly AlertIcon = AlertTriangle;
  readonly SummaryIcon = FileSpreadsheet;

  public formatDate = formatDate;
  public formatTime = formatTime;

  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);
  public warehouseService = inject(WarehouseService);
  private signalRService = inject(SignalRService);

  private destroy$ = new Subject<void>();

  receivings: ReceivingSummaryDto[] = [];
  isLoading = true;
  error = '';
  search = '';
  page = 1;
  pageSize = 10;
  totalCount = 0;
  totalPages = 0;

  // Drawer states
  isViewOpen = false;
  isCreateOpen = false;
  selectedReceiving: ReceivingSummaryDto | null = null;

  constructor() {
    effect(() => {
      this.warehouseService.selectedWarehouseId();
      this.page = 1;
      void this.loadReceivings();
    });
  }

  ngOnInit(): void {
    void this.loadReceivings();

    this.signalRService.receivingUpdated$
      .pipe(takeUntil(this.destroy$))
      .subscribe(() => {
        void this.loadReceivings();
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  close(): void {
    this.closed.emit();
  }

  async loadReceivings(): Promise<void> {
    this.isLoading = true;
    this.error = '';
    this.cd.markForCheck();

    const trimmedSearch = this.search.trim();
    const baseParams = {
      page: this.page,
      pageSize: this.pageSize,
      ...(trimmedSearch ? { search: trimmedSearch } : {}),
    };

    const params = this.warehouseService.withWarehouse(baseParams);

    try {
      const response = await this.api.invoke(receivingV2Get, params) as ReceivingSummaryDtoPaginatedResponse;
      this.receivings = response.items ?? [];
      this.totalCount = response.totalCount ?? 0;
      this.totalPages = response.totalPages ?? 0;
    } catch (err) {
      this.error = 'Unable to load receiving transactions.';
      console.error('Failed to load receivings:', err);
    } finally {
      this.isLoading = false;
      this.cd.markForCheck();
    }
  }

  openView(receiving: ReceivingSummaryDto): void {
    this.selectedReceiving = receiving;
    this.isViewOpen = true;
  }

  closeView(): void {
    this.isViewOpen = false;
    this.selectedReceiving = null;
  }

  openCreate(): void {
    this.isCreateOpen = true;
  }

  closeCreate(): void {
    this.isCreateOpen = false;
  }

  onSearch(): void {
    this.page = 1;
    void this.loadReceivings();
  }

  goToPage(nextPage: number): void {
    this.page = Math.max(1, Math.min(nextPage, this.totalPages || 1));
    void this.loadReceivings();
  }

  changePageSize(event: Event): void {
    this.pageSize = Number((event.target as HTMLSelectElement).value);
    this.page = 1;
    void this.loadReceivings();
  }

  // --- DISCREPANCY & SUMMARY HELPERS ---

  hasItemDiscrepancy(item: ReceivedProductSummaryDto): boolean {
    return !!item.hasDiscrepancy;
  }

  getVariance(item?: { quantity?: number | null; expectedQuantity?: number | null }): number {
    if (!item || item.expectedQuantity === null || item.expectedQuantity === undefined) {
      return 0; // No expected quantity baseline exists
    }
    return (item.quantity ?? 0) - item.expectedQuantity;
  }

  getDiscrepancySummary(receiving: ReceivingSummaryDto | null) {
    const summary = {
      matchedCount: 0,
      flaggedCount: 0,
      totalItems: receiving?.products?.length || 0,
      totalQuantityShortage: 0,
      totalQuantityExcess: 0,
      categoryCounts: {
        QUANTITY: 0,
        DESCRIPTION: 0,
        EXPIRY: 0,
        WEIGHT: 0,
        CBM: 0,
        DAMAGED: 0,
        OTHER: 0
      } as Record<DiscrepancyCategory, number>
    };

    if (!receiving?.products) return summary;

    for (const item of receiving.products) {
      if (!this.hasItemDiscrepancy(item)) {
        summary.matchedCount++;
      } else {
        summary.flaggedCount++;

        // Track net quantity variance
        const variance = this.getVariance(item);
        if (variance < 0) {
          summary.totalQuantityShortage += Math.abs(variance);
          summary.categoryCounts.QUANTITY++;
        } else if (variance > 0) {
          summary.totalQuantityExcess += variance;
          summary.categoryCounts.QUANTITY++;
        }

        // Tally categories based on exact field mismatches
        if (item.expectedProductName && item.expectedProductName.trim().toLowerCase() !== (item.name)?.trim()?.toLowerCase()) {
            summary.categoryCounts.DESCRIPTION++;
        }
        if (item.expectedCBM && item.expectedCBM !== item.cbm) {
            summary.categoryCounts.CBM++;
        }
        if (item.expectedTotalWeight && item.expectedTotalWeight !== item.totalWeight) {
            summary.categoryCounts.WEIGHT++;
        }
        if (item.expectedExpirationDate && item.expectedExpirationDate !== item.expirationDate) {
            summary.categoryCounts.EXPIRY++;
        }

        // If explicitly flagged with tags via Remarks
        if (item.remarks?.includes('DAMAGED')) summary.categoryCounts.DAMAGED++;
        if (item.remarks?.includes('OTHER')) summary.categoryCounts.OTHER++;
      }
    }

    return summary;
  }
}