import { ChangeDetectorRef, Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../api/generated/api';
import { productV2Get } from '../../api/generated/functions';
import { ProductSummaryDto, ProductSummaryDtoPaginatedResponse } from '../../api/generated/models';
import { LucideAngularModule, PlusIcon, SearchIcon, ChevronLeft, ChevronRight } from 'lucide-angular';
import { PageHeaderComponent } from '../../shared/layout/page-header/page-header.component';
import { CreateProductDialogComponent } from './create/create-product-dialog.component';

@Component({
  selector: 'app-products-list',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    LucideAngularModule,
    PageHeaderComponent,
    CreateProductDialogComponent,
  ],
  templateUrl: './products-list.component.html',
})
export class ProductsListComponent implements OnInit {
  Math = Math;
  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);

  readonly plus = PlusIcon;
  readonly searchIcon = SearchIcon;
  readonly chevronLeft = ChevronLeft;
  readonly chevronRight = ChevronRight;

  products: ProductSummaryDto[] = [];
  isLoading = true;
  error = '';
  search = '';
  page = 1;
  pageSize = 10;
  totalCount = 0;
  totalPages = 0;

  // Dialog State
  isCreateOpen = false;
  productToEdit?: ProductSummaryDto;

  ngOnInit(): void {
    void this.loadProducts();
  }

  // Dialog Controls
  openCreateDialog(): void {
    this.productToEdit = undefined;
    this.isCreateOpen = true;
    this.cd.markForCheck();
  }

  openEditDialog(product: ProductSummaryDto): void {
    this.productToEdit = product;
    this.isCreateOpen = true;
    this.cd.markForCheck();
  }

  closeCreateDialog(): void {
    this.isCreateOpen = false;
    this.productToEdit = undefined;
    this.cd.markForCheck();
  }

  onProductSaved(): void {
    void this.loadProducts();
  }

  async loadProducts(): Promise<void> {
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
      const response = await this.api.invoke(productV2Get, params) as ProductSummaryDtoPaginatedResponse;

      this.products = response.items ?? [];
      this.totalCount = response.totalCount ?? 0;
      this.totalPages = response.totalPages ?? 0;
    } catch (err) {
      this.error = 'Unable to load products. Please try again.';
      console.error('Failed to load products:', { params, search: this.search, err });
    } finally {
      this.isLoading = false;
      this.cd.markForCheck();
    }
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

  onSearch(): void {
    this.page = 1;
    void this.loadProducts();
  }

  goToPage(nextPage: number): void {
    this.page = Math.max(1, Math.min(nextPage, this.totalPages || 1));
    void this.loadProducts();
  }

  changePageSize(event: Event): void {
    this.pageSize = Number((event.target as HTMLSelectElement).value);
    this.page = 1;
    void this.loadProducts();
  }

  formatWeight(weight?: number): string {
    return weight == null ? '—' : `${weight} kg`;
  }
}