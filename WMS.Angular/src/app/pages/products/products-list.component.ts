import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../api/generated/api';
import { productV2Get } from '../../api/generated/functions';
import { ProductSummaryDto, ProductSummaryDtoPaginatedResponse } from '../../api/generated/models';
import { IconComponent } from '../../shared/components/icon/icon.component';

@Component({
  selector: 'app-products-list',
  standalone: true,
  imports: [CommonModule, FormsModule, IconComponent],
  templateUrl: './products-list.component.html',
})
export class ProductsListComponent implements OnInit {
  Math = Math;

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
  products: ProductSummaryDto[] = [];
  isLoading = true;
  error = '';
  search = '';
  page = 1;
  pageSize = 10;
  totalCount = 0;
  totalPages = 0;

  constructor(private api: Api, private cd: ChangeDetectorRef) {}

  ngOnInit(): void {
    // Explicit unfiltered fetch on load — does not depend on the search
    // branch in loadProducts(), so a future change to that logic can't
    // accidentally suppress the initial load again.
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

      if (this.products.length === 0) {
        // Helps distinguish "genuinely no products" from "request failed silently"
        console.debug('loadProducts: request succeeded but returned 0 items', { params, response });
      }
    } catch (err) {
      this.error = 'Unable to load products. Please try again.';
      console.error('Failed to load products:', { params, search: this.search, err });
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