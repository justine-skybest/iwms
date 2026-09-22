import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../api/generated/api';
import { CreatePickOrderModalComponent } from './create-pick-order-modal.component';
import { manualpickingV2Get } from '../../api/generated/functions';
import { ManualPickingSummaryDto, ManualPickingSummaryDtoPaginatedResponse, PickedProductSummaryDto } from '../../api/generated/models';
import { Eye, EyeIcon, LucideAngularModule, PencilIcon, Plus, Search, Trash2Icon } from 'lucide-angular';
import { PickOrderDetailsDrawerComponent } from './details/pick-order-details-drawer.component';
import { PageHeaderComponent } from '../../shared/layout/page-header/page-header.component';

@Component({
  selector: 'app-pick-order-list',
  standalone: true,
  imports: [CommonModule, FormsModule, CreatePickOrderModalComponent, LucideAngularModule, PickOrderDetailsDrawerComponent, PageHeaderComponent],
  templateUrl: './pick-order-list.component.html',
})
export class PickOrderListComponent implements OnInit {
  readonly pencilIcon = PencilIcon;
  readonly trashIcon = Trash2Icon;
  readonly eyeIcon = Eye;
  readonly plusIcon = Plus;
  readonly searchIcon = Search;
  showDetailsDrawer = false;
  selectedPickOrder: ManualPickingSummaryDto | null = null;
  pickOrders: ManualPickingSummaryDto[] = [];
  isLoading = true;
  error = '';
  search = '';
  page = 1;
  pageSize = 10;
  totalCount = 0;
  totalPages = 0;
  showCreateModal = false;

  get endItemCount(): number {
    return Math.min(this.page * this.pageSize, this.totalCount);
  }

  constructor(private api: Api, private cd: ChangeDetectorRef) {}

  ngOnInit(): void {
    // Explicit fetch on load, not chained through async/await in ngOnInit,
    // so a slow/failed request can't delay Angular's initial render.
    void this.loadPickOrders();
  }

  async loadPickOrders(): Promise<void> {
    this.isLoading = true;
    this.error = '';
    this.cd.markForCheck();

    const trimmedSearch = this.search.trim();
    const params = {
      page: this.page,
      pageSize: this.pageSize,
      ...(trimmedSearch ? { search: trimmedSearch } : {}),
    };

    try {
      const response = await this.api.invoke(manualpickingV2Get, params) as ManualPickingSummaryDtoPaginatedResponse;

      this.pickOrders = response.items ?? [];
      this.totalCount = response.totalCount ?? 0;
      this.totalPages = response.totalPages ?? 0;

      if (this.pickOrders.length === 0) {
        console.debug('loadPickOrders: request succeeded but returned 0 items', { params, response });
      }
    } catch (err) {
      this.error = 'Unable to load pick orders. Please try again.';
      console.error('Failed to load pick orders:', { params, search: this.search, err });
    } finally {
      this.isLoading = false;
      // Ensures the view updates even under OnPush change detection or a
      // zoneless setup, where mutating plain properties after an `await`
      // does not automatically trigger a re-render.
      this.cd.markForCheck();
    }
  }

  onSearch(): void {
    this.page = 1;
    void this.loadPickOrders();
  }

  goToPage(nextPage: number): void {
    this.page = Math.max(1, Math.min(nextPage, this.totalPages || 1));
    void this.loadPickOrders();
  }

  changePageSize(event: Event): void {
    this.pageSize = Number((event.target as HTMLSelectElement).value);
    this.page = 1;
    void this.loadPickOrders();
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

  // Open drawer on table action
  openDetails(order: ManualPickingSummaryDto): void {
    this.selectedPickOrder = order;
    this.showDetailsDrawer = true;
  }

  // Close drawer handler
  onDetailsDrawerClosed(): void {
    this.showDetailsDrawer = false;
    this.selectedPickOrder = null;
  }

  getTotalQuantity(products: PickedProductSummaryDto[] | null | undefined): number {
    if (!products?.length) return 0;
    return products.reduce((sum, item) => sum + (item.quantityPicked ?? 0), 0);
  }

  openCreateModal(): void {
    this.showCreateModal = true;
  }

  onCreateOrderCreated(): void {
    this.showCreateModal = false;
    // Refresh list after successful creation
    void this.loadPickOrders();
  }

  onCreateModalClosed(): void {
    this.showCreateModal = false;
  }
}