import { ChangeDetectorRef, Component, OnInit, inject, effect } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../api/generated/api';
import { palletV2Get } from '../../api/generated/functions';
import { PalletSummaryDto, PalletSummaryDtoPaginatedResponse } from '../../api/generated/models';
import { IconComponent } from '../../shared/components/icon/icon.component';
import { WarehouseService } from '../../lib/services/warehouse.service';
import { generateQrCodeDataUrl } from '../../lib/utils/qr-code.util';
import { LucideAngularModule, ChevronLeft, ChevronRight } from 'lucide-angular';

export type PalletWithQr = PalletSummaryDto & { qrCodeUrl?: string };

@Component({
  selector: 'app-pallets-list',
  standalone: true,
  imports: [CommonModule, FormsModule, IconComponent, LucideAngularModule],
  templateUrl: './pallets-list.component.html',
})
export class PalletsListComponent implements OnInit {
  Math = Math;
  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);
  private warehouseService = inject(WarehouseService);

  readonly chevronLeftIcon = ChevronLeft;
  readonly chevronRightIcon = ChevronRight;

  pallets: PalletWithQr[] = [];
  isLoading = true;
  error = '';
  search = '';
  page = 1;
  pageSize = 10;
  totalCount = 0;
  totalPages = 0;

  // State for enlarged QR preview modal
  selectedPalletForQr: PalletWithQr | null = null;

  get endItemCount(): number {
    return Math.min(this.page * this.pageSize, this.totalCount);
  }

  constructor() {
    effect(() => {
      this.warehouseService.selectedWarehouseId();
      this.page = 1;
      void this.loadPallets();
    });
  }

  ngOnInit(): void {
    void this.loadPallets();
  }

  async loadPallets(): Promise<void> {
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
      const response = await this.api.invoke(palletV2Get, params) as PalletSummaryDtoPaginatedResponse;
      const rawItems = response.items ?? [];

      // Generate QR data URL for each pallet item in parallel
      this.pallets = await Promise.all(
        rawItems.map(async (pallet) => ({
          ...pallet,
          qrCodeUrl: pallet.palletHashCode
            ? await generateQrCodeDataUrl(pallet.palletHashCode, 100)
            : '',
        }))
      );

      this.totalCount = response.totalCount ?? 0;
      this.totalPages = response.totalPages ?? 0;

      if (this.pallets.length === 0) {
        console.debug('loadPallets: request succeeded but returned 0 items', { params, response });
      }
    } catch (err) {
      this.error = 'Unable to load pallets. Please try again.';
      console.error('Failed to load pallets:', { params, search: this.search, err });
    } finally {
      this.isLoading = false;
      this.cd.markForCheck();
    }
  }

  openQrPreview(pallet: PalletWithQr): void {
    this.selectedPalletForQr = pallet;
  }

  closeQrPreview(): void {
    this.selectedPalletForQr = null;
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
    void this.loadPallets();
  }

  goToPage(nextPage: number): void {
    this.page = Math.max(1, Math.min(nextPage, this.totalPages || 1));
    void this.loadPallets();
  }

  changePageSize(event: Event): void {
    this.pageSize = Number((event.target as HTMLSelectElement).value);
    this.page = 1;
    void this.loadPallets();
  }
}