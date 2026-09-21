import { ChangeDetectorRef, Component, OnInit, inject, effect } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../api/generated/api';
import { palletV2Get } from '../../api/generated/functions';
import { PalletSummaryDto, PalletSummaryDtoPaginatedResponse } from '../../api/generated/models';
import { IconComponent } from '../../shared/components/icon/icon.component';
import { WarehouseService } from '../../lib/services/warehouse.service';
import { generateQrCodeDataUrl } from '../../lib/utils/qr-code.util';
import { LucideAngularModule, ChevronLeft, ChevronRight, PlusIcon, SearchIcon } from 'lucide-angular';
import { PageHeaderComponent } from '../../shared/layout/page-header/page-header.component';
import { CreatePalletDialogComponent } from './create/create-pallet-dialog.component';

export type PalletWithQr = PalletSummaryDto & { qrCodeUrl?: string };

@Component({
  selector: 'app-pallets-list',
  standalone: true,
  imports: [
    CommonModule, 
    FormsModule, 
    IconComponent, 
    LucideAngularModule, 
    PageHeaderComponent, 
    CreatePalletDialogComponent
  ],
  templateUrl: './pallets-list.component.html',
})
export class PalletsListComponent implements OnInit {
  Math = Math;
  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);
  private warehouseService = inject(WarehouseService);

  readonly chevronLeft = ChevronLeft;
  readonly chevronRight = ChevronRight;
  readonly plus = PlusIcon;
  readonly searchIcon = SearchIcon;

  pallets: PalletWithQr[] = [];
  isLoading = true;
  error = '';
  search = '';
  page = 1;
  pageSize = 10;
  totalCount = 0;
  totalPages = 0;

  // Dialog State
  isCreateDialogOpen = false;
  palletToEdit?: PalletSummaryDto;

  // Enlarged QR preview modal state
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
    } catch (err) {
      this.error = 'Unable to load pallets. Please try again.';
      console.error('Failed to load pallets:', { params, search: this.search, err });
    }
    finally {
      this.isLoading = false;
      this.cd.markForCheck();
    }
  }

  // Dialog Control
  openCreateDialog(): void {
    this.palletToEdit = undefined;
    this.isCreateDialogOpen = true;
    this.cd.markForCheck();
  }

  openEditDialog(pallet: PalletSummaryDto): void {
    this.palletToEdit = pallet;
    this.isCreateDialogOpen = true;
    this.cd.markForCheck();
  }

  closeCreateDialog(): void {
    this.isCreateDialogOpen = false;
    this.palletToEdit = undefined;
    this.cd.markForCheck();
  }

  onPalletSaved(): void {
    void this.loadPallets();
  }

  // QR Preview
  openQrPreview(pallet: PalletWithQr): void {
    this.selectedPalletForQr = pallet;
  }

  closeQrPreview(): void {
    this.selectedPalletForQr = null;
  }

  // Helpers & Actions
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