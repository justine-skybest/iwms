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
  getCheckedInBinByQrCode,
  getPalletStockById,
} from '../../../api/generated/functions';
import {
  BinSummaryDto,
  DisplayCheckInProductsDto,
} from '../../../api/generated/models';
import { WarehouseService } from '../../../lib/services/warehouse.service';
import { ToastService } from '../../../lib/services/toast.service';
import { IconComponent } from '../../../shared/components/icon/icon.component';
import { QrScannerComponent } from '../../../shared/components/qr-scanner/qr-scanner.component';

export type InspectionMode = 'bin' | 'pallet';

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

  inspectionMode: InspectionMode = 'bin';
  searchQuery = '';
  isLoading = false;
  errorMessage = '';

  binInfo: BinSummaryDto | null = null;
  palletInfo: { palletId: number; palletNumber?: string } | null = null;
  checkIns: DisplayCheckInProductsDto[] = [];

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['isOpen'] && this.isOpen) {
      this.resetModal();
    }
  }

  setMode(mode: InspectionMode): void {
    if (this.inspectionMode === mode) return;
    this.inspectionMode = mode;
    this.clearSearch();
  }

  resetModal(): void {
    this.inspectionMode = 'bin';
    this.searchQuery = '';
    this.binInfo = null;
    this.palletInfo = null;
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

    // Auto-switch mode if a scanned QR string starts with 'PALLET:'
    if (trimmed.toUpperCase().startsWith('PALLET:')) {
      this.inspectionMode = 'pallet';
    }

    if (this.inspectionMode === 'pallet') {
      await this.inspectPallet(trimmed);
    } else {
      await this.inspectBin(trimmed);
    }
  }

  private async inspectBin(code: string): Promise<void> {
    const warehouseId = this.warehouseService.selectedWarehouseId();

    if (!warehouseId) {
      this.toastService.error('Please select a specific warehouse location first.');
      return;
    }

    const numValue = Number(code);
    if (isNaN(numValue)) {
      this.errorMessage = 'QR code / Bin hash code must be a valid numeric value.';
      this.cd.markForCheck();
      return;
    }

    this.startSearchState();

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
        this.errorMessage = binResponse?.warehouse ?? `No checked-in Bin found matching QR code "${code}".`;
      }
    } catch (err: any) {
      console.error('Bin inspection error:', err);
      this.errorMessage = err?.message || 'An error occurred while inspecting bin inventory.';
      this.toastService.error(this.errorMessage);
    } finally {
      this.endSearchState();
    }
  }

  private async inspectPallet(code: string): Promise<void> {
    const palletId = this.parsePalletId(code);

    if (!palletId || palletId <= 0) {
      this.errorMessage = 'Invalid Pallet ID format. Expected numeric ID or "PALLET:#123".';
      this.cd.markForCheck();
      return;
    }

    this.startSearchState();

    try {
      // Fetch available stock by Pallet ID
      const res = (await this.api.invoke(getPalletStockById, {
        PalletId: palletId - 100000,
      })) as any;

      const data = (Array.isArray(res) ? res : [res]) as DisplayCheckInProductsDto[];

      if (data && data.length > 0) {
        this.checkIns = data;
        const detectedPalletNo = data[0]?.palletNumber || `Pallet #${palletId}`;
        this.palletInfo = { palletId, palletNumber: detectedPalletNo };
        this.toastService.success(`Inspected ${detectedPalletNo}`);
      } else {
        this.palletInfo = { palletId, palletNumber: `Pallet #${palletId}` };
        this.checkIns = [];
        this.errorMessage = `No active checked-in inventory found for Pallet ID #${palletId}.`;
      }
    } catch (err: any) {
      console.error('Pallet inspection error:', err);
      this.errorMessage = err?.message || `Failed to fetch stock for Pallet ID #${palletId}.`;
      this.toastService.error(this.errorMessage);
    } finally {
      this.endSearchState();
    }
  }

  private parsePalletId(code: string): number | null {
    const trimmed = code.trim();
    if (/^\d+$/.test(trimmed)) return Number(trimmed);

    // Matches formats like "PALLET:#123|SKU:..." or "PALLET:123"
    const match = trimmed.match(/PALLET:#?(\d+)/i);
    if (match && match[1]) return Number(match[1]);

    return null;
  }

  private startSearchState(): void {
    this.isLoading = true;
    this.errorMessage = '';
    this.binInfo = null;
    this.palletInfo = null;
    this.checkIns = [];
    this.cd.markForCheck();
  }

  private endSearchState(): void {
    this.isLoading = false;
    this.cd.markForCheck();
  }

  clearSearch(): void {
    this.searchQuery = '';
    this.binInfo = null;
    this.palletInfo = null;
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