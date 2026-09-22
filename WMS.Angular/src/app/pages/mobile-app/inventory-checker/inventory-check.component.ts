import {
  Component,
  EventEmitter,
  Input,
  Output,
  OnChanges,
  SimpleChanges,
  inject,
  ChangeDetectorRef,
  ChangeDetectionStrategy,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../../api/generated/api';
import {
  getBinStockById,
  getCheckedInBinByQrCode
} from '../../../api/generated/functions';
import {
  BinSummaryDto,
  DisplayCheckInProductsDto,
} from '../../../api/generated/models';
import { WarehouseService } from '../../../lib/services/warehouse.service';
import { ToastService } from '../../../lib/services/toast.service';
import { IconComponent } from '../../../shared/components/icon/icon.component';
import { QrScannerComponent } from '../../../shared/components/qr-scanner/qr-scanner.component';

@Component({
  selector: 'app-inventory-check-modal',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    IconComponent,
    QrScannerComponent,
  ],
  templateUrl: './inventory-check-modal.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class InventoryCheckModalComponent implements OnChanges {
  @Input() isOpen = false;
  @Output() closed = new EventEmitter<void>();

  private api = inject(Api);
  private warehouseService = inject(WarehouseService);
  private toastService = inject(ToastService);
  private cd = inject(ChangeDetectorRef);

  searchQuery = '';
  isLoading = false;
  errorMessage = '';

  binInfo: BinSummaryDto | null = null;
  checkIns: DisplayCheckInProductsDto[] = [];

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['isOpen'] && this.isOpen) {
      this.resetModal();
    }
  }

  resetModal(): void {
    this.searchQuery = '';
    this.binInfo = null;
    this.checkIns = [];
    this.errorMessage = '';
    this.isLoading = false;
    this.cd.markForCheck();
  }

  closeModal(): void {
    this.closed.emit();
  }

  async executeInspection(code: string): Promise<void> {
    const trimmed = code.trim();
    if (!trimmed) return;

    this.searchQuery = trimmed;
    const warehouseId = this.warehouseService.selectedWarehouseId();

    if (!warehouseId) {
      this.toastService.error('Please select a specific warehouse location first.');
      return;
    }

    const numValue = Number(trimmed);
    if (isNaN(numValue)) {
      this.errorMessage = 'QR code / Bin hash code must be a valid numeric value.';
      this.cd.markForCheck();
      return;
    }

    this.isLoading = true;
    this.errorMessage = '';
    this.binInfo = null;
    this.checkIns = [];
    this.cd.markForCheck();

    try {
      // 1. Resolve Bin by QR Hash Code
      const binResponse = (await this.api.invoke(getCheckedInBinByQrCode, {
        BinHashCode: numValue,
        WarehouseId: warehouseId,
      })) as BinSummaryDto;

      if (binResponse?.id) {
        this.binInfo = binResponse;

        // 2. Fetch all checked-in stock for this bin
        const res = (await this.api.invoke(getBinStockById, {
          BinId: binResponse.id,
        })) as any;

        this.checkIns = (Array.isArray(res) ? res : [res]) as DisplayCheckInProductsDto[];
        this.toastService.success(`Inspected Bin "${binResponse.binName || binResponse.id}"`);
      } else {
        this.errorMessage = binResponse.warehouse?? `No checked-in Bin found matching QR code "${trimmed}".`;
      }
    } catch (err: any) {
      console.error('Inventory inspection error:', err);
      this.errorMessage = err?.message || 'An error occurred while inspecting inventory.';
      this.toastService.error(this.errorMessage);
    } finally {
      this.isLoading = false;
      this.cd.markForCheck();
    }
  }

  clearSearch(): void {
    this.searchQuery = '';
    this.binInfo = null;
    this.checkIns = [];
    this.errorMessage = '';
    this.cd.markForCheck();
  }

  formatDate(dateStr?: string | null): string {
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

  getTotalProductsCount(): number {
    return this.checkIns.reduce((sum, ci) => sum + (ci.receivedProducts?.length ?? 0), 0);
  }
}