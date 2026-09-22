import { ChangeDetectorRef, Component, OnInit, inject, effect } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../api/generated/api';
import { checkinV2Get } from '../../api/generated/functions';
import { CheckInSummaryDto, CheckInSummaryDtoPaginatedResponse } from '../../api/generated/models';
import { WarehouseService } from '../../lib/services/warehouse.service';
import { CreateCheckInModalComponent } from './components/create/create-check-in-modal.component';
import { CheckInDetailsDrawerComponent } from './components/details-drawer/check-in-details-drawer.component';
import { ChevronLeft, ChevronRight, EyeIcon, LucideAngularModule, PencilIcon, PlusIcon, Search, SearchIcon, TrashIcon } from 'lucide-angular';
import { PageHeaderComponent } from '../../shared/layout/page-header/page-header.component';

@Component({
  selector: 'app-check-in-list',
  standalone: true,
  imports: [CommonModule, FormsModule, CreateCheckInModalComponent, CheckInDetailsDrawerComponent, LucideAngularModule, PageHeaderComponent],
  templateUrl: './check-in-list.component.html',
})
export class CheckInListComponent implements OnInit {
  Math = Math;

  readonly pencilIcon = PencilIcon;
  readonly trashIcon = TrashIcon;
  readonly eyeIcon = EyeIcon;
  readonly chevronRight = ChevronRight;
  readonly chevronLeft = ChevronLeft;
  readonly searchIcon = SearchIcon;
  readonly plusIcon = PlusIcon;

  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);
  private warehouseService = inject(WarehouseService);

  checkIns: CheckInSummaryDto[] = [];
  isLoading = true;
  error = '';
  search = '';
  page = 1;
  pageSize = 10;
  totalCount = 0;
  totalPages = 0;

  showCreateModal = false;

  showDetailsDrawer = false;
  selectedCheckIn: CheckInSummaryDto | null = null;

  constructor() {
    effect(() => {
      this.warehouseService.selectedWarehouseId();
      this.page = 1;
      void this.loadCheckIns();
    });
  }

  ngOnInit(): void {
    void this.loadCheckIns();
  }

  async loadCheckIns(): Promise<void> {
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
      const response = (await this.api.invoke(checkinV2Get, params)) as CheckInSummaryDtoPaginatedResponse;

      this.checkIns = response.items ?? [];
      this.totalCount = response.totalCount ?? 0;
      this.totalPages = response.totalPages ?? 0;
    } catch (err) {
      this.error = 'Unable to load check-in transactions. Please try again.';
      console.error('Failed to load check-ins:', { params, search: this.search, err });
    } finally {
      this.isLoading = false;
      this.cd.markForCheck();
    }
  }

  openCreateModal(): void {
    this.showCreateModal = true;
  }

  closeCreateModal(): void {
    this.showCreateModal = false;
  }

  viewDetails(checkIn: CheckInSummaryDto): void {
    this.selectedCheckIn = checkIn;
    this.showDetailsDrawer = true;
  }

  closeDetailsDrawer(): void {
    this.showDetailsDrawer = false;
    // Clear after the close transition would run, if one is ever added;
    // for now it's safe to clear immediately since the drawer is *ngIf-gated.
    this.selectedCheckIn = null;
  }

  onSearch(): void {
    this.page = 1;
    void this.loadCheckIns();
  }

  goToPage(nextPage: number): void {
    this.page = Math.max(1, Math.min(nextPage, this.totalPages || 1));
    void this.loadCheckIns();
  }

  changePageSize(event: Event): void {
    this.pageSize = Number((event.target as HTMLSelectElement).value);
    this.page = 1;
    void this.loadCheckIns();
  }

  formatCheckInType(type?: string | null): string {
    if (!type) return '—';
    return type.charAt(0).toUpperCase() + type.slice(1);
  }

  formatDate(dateStr?: string): string {
    if (!dateStr) return '—';
    try {
      return new Date(dateStr).toLocaleDateString('en-US', {
        month: 'short',
        day: '2-digit',
        year: 'numeric',
      });
    } catch {
      return dateStr;
    }
  }
}