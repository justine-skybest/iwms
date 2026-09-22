import { ChangeDetectorRef, Component, OnInit, inject, effect, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../api/generated/api';
import { receivingV2Get } from '../../api/generated/functions';
import { ReceivingSummaryDto, ReceivingSummaryDtoPaginatedResponse } from '../../api/generated/models';
import { WarehouseService } from '../../lib/services/warehouse.service';
import { ReceivingCreateComponent } from './create/receiving-create.component';
import { LucideAngularModule, ChevronLeft, ChevronRight, EyeIcon, SearchIcon, PlusIcon } from 'lucide-angular';
import { SignalRService } from '../../lib/services/signalr.service';
import { Subject, takeUntil } from 'rxjs';
import { PageHeaderComponent } from '../../shared/layout/page-header/page-header.component';

@Component({
  selector: 'app-receiving-list',
  standalone: true,
  imports: [CommonModule, FormsModule, ReceivingCreateComponent, LucideAngularModule, PageHeaderComponent],
  templateUrl: './receiving-list.component.html',
})
export class ReceivingListComponent implements OnInit {
  @Output() closed = new EventEmitter<void>();
  Math = Math;
  readonly chevronLeft = ChevronLeft;
  readonly chevronRight = ChevronRight;
  readonly eyeIcon = EyeIcon;
  readonly searchIcon = SearchIcon;
  readonly plus = PlusIcon;

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

  formatTime(timeStr?: string): string {
  if (!timeStr) return '—';
  try {
    const date = new Date(timeStr);
    if (!isNaN(date.getTime())) {
      return date.toLocaleTimeString('en-US', { hour: '2-digit', minute: '2-digit' });
    }
    return timeStr;
  } catch {
    return timeStr;
  }
}
}