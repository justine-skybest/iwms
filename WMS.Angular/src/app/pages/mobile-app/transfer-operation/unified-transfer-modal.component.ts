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
  locatePalletByQrCode,
  locatePalletByNumber,
  transferPallet,
  transferItem,
  getItemsInBin,
  binV2Get,
} from '../../../api/generated/functions';
import {
  PalletLocationDto,
  BinSummaryDto,
  BinSummaryDtoPaginatedResponse,
  ItemLocationSummaryDto,
} from '../../../api/generated/models';
import { WarehouseService } from '../../../lib/services/warehouse.service';
import { ToastService } from '../../../lib/services/toast.service';
import { IconComponent } from '../../../shared/components/icon/icon.component';
import { QrScannerComponent } from '../../../shared/components/qr-scanner/qr-scanner.component';
import { SearchableSelectComponent, SelectOption } from '../../check-in/components/select/select.component';

export type DetectedTransferType = 'PALLET' | 'ITEM' | 'NONE';

@Component({
  selector: 'app-unified-transfer-modal',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    IconComponent,
    QrScannerComponent,
    SearchableSelectComponent,
  ],
  templateUrl: './unified-transfer-modal.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UnifiedTransferModalComponent implements OnChanges {
  @Input() isOpen = false;
  @Output() closed = new EventEmitter<void>();
  @Output() created = new EventEmitter<void>();

  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);
  private warehouseService = inject(WarehouseService);
  private toastService = inject(ToastService);

  // Statuses
  isSubmitting = false;
  isLocating = false;
  errorMessage = '';

  // Auto-Detected Mode State
  transferType: DetectedTransferType = 'NONE';
  searchQuery = '';

  // Pallet Mode Data
  locatedPallet: PalletLocationDto | null = null;

  // Item Mode Data
  locatedBin: BinSummaryDto | null = null;
  itemsInBin: ItemLocationSummaryDto[] = [];
  selectedItem: ItemLocationSummaryDto | null = null;

  // Destination Bin State
  selectedDestinationBinOption: SelectOption<BinSummaryDto>[] = [];
  notes = '';

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['isOpen'] && this.isOpen) {
      this.resetForm();
    }
  }

  resetForm(): void {
    this.searchQuery = '';
    this.transferType = 'NONE';
    this.locatedPallet = null;
    this.locatedBin = null;
    this.itemsInBin = [];
    this.selectedItem = null;
    this.selectedDestinationBinOption = [];
    this.notes = '';
    this.errorMessage = '';
    this.isSubmitting = false;
    this.isLocating = false;
    this.cd.markForCheck();
  }

  closeModal(): void {
    this.closed.emit();
  }

  /**
   * Universal Smart Scan / Search Handler
   */
  async processSmartScan(code: string): Promise<void> {
    const trimmed = code.trim();
    if (!trimmed) return;

    this.searchQuery = trimmed;
    const warehouseId = this.warehouseService.selectedWarehouseId();

    if (!warehouseId) {
      this.errorMessage = 'Please select a specific warehouse location first.';
      this.cd.markForCheck();
      return;
    }

    const numValue = Number(trimmed);
    if (isNaN(numValue)) {
      this.errorMessage = 'QR code / Barcode must be a numeric value.';
      this.cd.markForCheck();
      return;
    }

    this.isLocating = true;
    this.errorMessage = '';
    this.transferType = 'NONE';
    this.locatedPallet = null;
    this.locatedBin = null;
    this.itemsInBin = [];
    this.selectedItem = null;
    this.cd.markForCheck();

    try {
      // 1. Try detecting as a PALLET
      let palletResult = (await this.api.invoke(locatePalletByQrCode, {
        hashCode: numValue,
        warehouseId: warehouseId,
      })) as PalletLocationDto;

      if (!palletResult || !palletResult.palletId) {
        palletResult = (await this.api.invoke(locatePalletByNumber, {
          palletNumber: numValue,
          warehouseId: warehouseId,
        })) as PalletLocationDto;
      }

      if (palletResult && palletResult.palletId) {
        this.transferType = 'PALLET';
        this.locatedPallet = palletResult;
        this.toastService.success(`Detected Pallet #${palletResult.palletNumber}`);
        return;
      }

      // 2. Try detecting as a BIN containing ITEMS
      const binResponse = (await this.api.invoke(binV2Get, {
        pageSize: 1,
        search: trimmed,
        warehouseId: warehouseId,
      })) as BinSummaryDtoPaginatedResponse;

      const matchedBin = binResponse?.items?.[0];

      if (matchedBin && matchedBin.id) {
        const items = (await this.api.invoke(getItemsInBin, {
          binId: matchedBin.id,
        })) as ItemLocationSummaryDto[];

        if (items && items.length > 0) {
          this.transferType = 'ITEM';
          this.locatedBin = matchedBin;
          this.itemsInBin = items;
          this.toastService.success(`Detected Bin "${matchedBin.binName ?? matchedBin.id}" with ${items.length} item(s)`);
          return;
        } else {
          this.errorMessage = `Found Bin #${matchedBin.id}, but it has no individually checked-in items to transfer.`;
          return;
        }
      }

      // 3. No match found
      this.errorMessage = `No checked-in Pallet or Bin found for QR code "${trimmed}".`;
    } catch (err: any) {
      console.error('Smart lookup error:', err);
      this.errorMessage = 'An error occurred during lookup. Please try again.';
    } finally {
      this.isLocating = false;
      this.cd.markForCheck();
    }
  }

  /**
   * Search Bins for Destination Select
   */
  searchBins = async (term: string): Promise<SelectOption<BinSummaryDto>[]> => {
    const warehouseId = this.warehouseService.selectedWarehouseId();
    if (!warehouseId) return [];

    try {
      const response = (await this.api.invoke(binV2Get, {
        pageSize: 50,
        search: term.trim() || undefined,
        warehouseId: warehouseId,
      })) as BinSummaryDtoPaginatedResponse;

      const items = response.items ?? [];
      return items.map((bin) => {
        const locationHierarchy = [bin.rack, bin.bay, bin.level].filter(Boolean).join(' / ');

        return {
          id: bin.id!,
          label: `${bin.binName ?? `Bin #${bin.id}`}${bin.binHashCode ? ` (${bin.binHashCode})` : ''}`,
          sublabel: locationHierarchy || bin.warehouse || undefined,
          raw: bin,
        };
      });
    } catch (err) {
      return [];
    }
  };

  /**
   * Destination Bin Selection Changes
   */
  onDestinationBinSelectChange(options: SelectOption<BinSummaryDto>[]): void {
    this.selectedDestinationBinOption = options;
    this.errorMessage = '';
    this.cd.markForCheck();
  }

  /**
   * Destination Bin Camera Scanner
   */
  async onDestinationBinQrScanned(scannedText: string): Promise<void> {
    const trimmed = scannedText.trim();
    if (!trimmed) return;

    const matches = await this.searchBins(trimmed);
    if (matches.length > 0) {
      this.onDestinationBinSelectChange([matches[0]]);
      this.toastService.success(`Destination Bin "${matches[0].label}" selected.`);
    } else {
      const parsedId = Number(trimmed);
      if (!isNaN(parsedId)) {
        const fallbackOption: SelectOption<BinSummaryDto> = {
          id: parsedId,
          label: `Bin #${parsedId}`,
          raw: { id: parsedId },
        };
        this.onDestinationBinSelectChange([fallbackOption]);
        this.toastService.info(`Selected Destination Bin #${parsedId}`);
      } else {
        this.toastService.error(`Destination bin "${trimmed}" not found.`);
      }
    }
  }

  /**
   * Submit Appropriate Transfer
   */
  async onSubmitTransfer(): Promise<void> {
    this.errorMessage = '';

    const destinationBinId = this.selectedDestinationBinOption[0]?.id;
    if (!destinationBinId) {
      this.errorMessage = 'Please select or scan a destination bin location.';
      this.cd.markForCheck();
      return;
    }

    this.isSubmitting = true;
    this.cd.markForCheck();

    try {
      if (this.transferType === 'PALLET' && this.locatedPallet?.palletId) {
        const res = (await this.api.invoke(transferPallet, {
          body: {
            palletId: this.locatedPallet.palletId,
            toBinId: destinationBinId,
            notes: this.notes.trim() || undefined,
          },
        })) as { success?: boolean; message?: string };

        if (res.success) {
          this.toastService.success(res.message || 'Pallet transferred successfully.');
          this.created.emit();
          this.closeModal();
        } else {
          this.errorMessage = res.message || 'Transfer failed. Destination bin may be occupied.';
        }
      } else if (this.transferType === 'ITEM' && this.selectedItem) {
        if (!this.selectedItem.checkInId || !this.selectedItem.receivedProductId) {
          this.errorMessage = 'Invalid item selection record.';
          return;
        }

        const res = (await this.api.invoke(transferItem, {
          body: {
            fromCheckInId: this.selectedItem.checkInId,
            receivedProductId: this.selectedItem.receivedProductId,
            toBinId: destinationBinId,
            notes: this.notes.trim() || undefined,
          },
        })) as { success?: boolean; message?: string };

        if (res.success) {
          this.toastService.success(res.message || 'Item transferred successfully.');
          this.created.emit();
          this.closeModal();
        } else {
          this.errorMessage = res.message || 'Item transfer failed. Destination bin may be occupied.';
        }
      }
    } catch (err: any) {
      console.error('Transfer execution error:', err);
      this.errorMessage = err?.message || 'An error occurred during transfer.';
      this.toastService.error(this.errorMessage);
    } finally {
      this.isSubmitting = false;
      this.cd.markForCheck();
    }
  }
}