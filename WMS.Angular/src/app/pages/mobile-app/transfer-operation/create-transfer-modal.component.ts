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
  binV2Get,
} from '../../../api/generated/functions';
import { PalletLocationDto, BinSummaryDto, BinSummaryDtoPaginatedResponse } from '../../../api/generated/models';
import { WarehouseService } from '../../../lib/services/warehouse.service';
import { ToastService } from '../../../lib/services/toast.service';
import { IconComponent } from '../../../shared/components/icon/icon.component';
import { QrScannerComponent } from '../../../shared/components/qr-scanner/qr-scanner.component';
import { SearchableSelectComponent, SelectOption } from '../../check-in/components/select/select.component';

@Component({
  selector: 'app-create-transfer-modal',
  standalone: true,
  imports: [
    CommonModule, 
    FormsModule, 
    IconComponent, 
    QrScannerComponent, 
    SearchableSelectComponent
  ],
  templateUrl: './create-transfer-modal.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CreateTransferModalComponent implements OnChanges {
  @Input() isOpen = false;
  @Output() closed = new EventEmitter<void>();
  @Output() created = new EventEmitter<void>();

  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);
  private warehouseService = inject(WarehouseService);
  private toastService = inject(ToastService);

  // States
  isSubmitting = false;
  errorMessage = '';

  // Selected Option States for SearchableSelectComponent
  selectedPalletOption: SelectOption<PalletLocationDto>[] = [];
  selectedBinOption: SelectOption<BinSummaryDto>[] = [];

  locatedPallet: PalletLocationDto | null = null;
  selectedToBinId: number | null = null;
  notes = '';

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['isOpen'] && this.isOpen) {
      this.resetForm();
    }
  }

  resetForm(): void {
    this.selectedPalletOption = [];
    this.selectedBinOption = [];
    this.locatedPallet = null;
    this.selectedToBinId = null;
    this.notes = '';
    this.errorMessage = '';
    this.isSubmitting = false;
    this.cd.markForCheck();
  }

  closeModal(): void {
    this.closed.emit();
  }

  /**
   * Search function for Pallets (passed to <app-searchable-select>)
   */
  searchPallets = async (term: string): Promise<SelectOption<PalletLocationDto>[]> => {
    const warehouseId = this.warehouseService.selectedWarehouseId();
    if (!warehouseId || !term.trim()) return [];

    const numValue = Number(term.trim());
    if (isNaN(numValue)) return [];

    try {
      // 1. Try search by QR Hash Code
      let result = (await this.api.invoke(locatePalletByQrCode, {
        hashCode: numValue,
        warehouseId: warehouseId,
      })) as PalletLocationDto;

      // 2. Fallback to Pallet Number
      if (!result || !result.palletId) {
        result = (await this.api.invoke(locatePalletByNumber, {
          palletNumber: numValue,
          warehouseId: warehouseId,
        })) as PalletLocationDto;
      }

      if (result && result.palletId) {
        return [{
          id: result.palletId,
          label: `Pallet #${result.palletNumber}`,
          sublabel: `Hash: ${result.palletHashCode} | ${result.currentBinLocation || 'Not checked in'}`,
          raw: result,
        }];
      }
      return [];
    } catch (err) {
      console.error('Error searching pallet:', err);
      return [];
    }
  };

  /**
   * Search function for Bins using BinSummaryDto
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
      console.error('Error searching bins:', err);
      return [];
    }
  };

  /**
   * Selection changes from Pallet SearchableSelect
   */
  onPalletSelectChange(options: SelectOption<PalletLocationDto>[]): void {
    this.selectedPalletOption = options;
    if (options.length > 0) {
      this.locatedPallet = options[0].raw;
      this.errorMessage = '';
    } else {
      this.locatedPallet = null;
    }
    this.cd.markForCheck();
  }

  /**
   * Selection changes from Bin SearchableSelect
   */
  onBinSelectChange(options: SelectOption<BinSummaryDto>[]): void {
    this.selectedBinOption = options;
    if (options.length > 0) {
      this.selectedToBinId = options[0].id;
      this.errorMessage = '';
    } else {
      this.selectedToBinId = null;
    }
    this.cd.markForCheck();
  }

  /**
   * QR Camera scanner handler for Pallets
   */
  async onPalletQrScanned(scannedText: string): Promise<void> {
    const warehouseId = this.warehouseService.selectedWarehouseId();
    if (!warehouseId) {
      this.toastService.error('Please select a specific warehouse first.');
      return;
    }

    const numValue = Number(scannedText.trim());
    if (isNaN(numValue)) {
      this.toastService.error('Scanned code is not a valid numeric value.');
      return;
    }

    try {
      let result = (await this.api.invoke(locatePalletByQrCode, {
        hashCode: numValue,
        warehouseId: warehouseId,
      })) as PalletLocationDto;

      if (!result || !result.palletId) {
        result = (await this.api.invoke(locatePalletByNumber, {
          palletNumber: numValue,
          warehouseId: warehouseId,
        })) as PalletLocationDto;
      }

      if (result && result.palletId) {
        const option: SelectOption<PalletLocationDto> = {
          id: result.palletId,
          label: `Pallet #${result.palletNumber}`,
          sublabel: `Hash: ${result.palletHashCode} | ${result.currentBinLocation || 'Not checked in'}`,
          raw: result,
        };
        this.onPalletSelectChange([option]);
        this.toastService.success(`Found Pallet #${result.palletNumber}`);
      } else {
        this.toastService.error('Scanned pallet not found in active warehouse.');
      }
    } catch (err) {
      this.toastService.error('Error locating scanned pallet.');
    }
  }

  /**
   * QR Camera scanner handler for Destination Bins
   */
  async onBinQrScanned(scannedText: string): Promise<void> {
    const trimmed = scannedText.trim();
    if (!trimmed) return;

    // Trigger dynamic search to find the matching bin object from API
    const matches = await this.searchBins(trimmed);
    if (matches.length > 0) {
      this.onBinSelectChange([matches[0]]);
      this.toastService.success(`Destination Bin "${matches[0].label}" selected.`);
    } else {
      const parsedValue = Number(trimmed);
      if (!isNaN(parsedValue)) {
        const fallbackOption: SelectOption<BinSummaryDto> = {
          id: parsedValue,
          label: `Bin #${parsedValue}`,
          raw: { id: parsedValue, binName: `Bin #${parsedValue}` },
        };
        this.onBinSelectChange([fallbackOption]);
        this.toastService.info(`Selected Bin #${parsedValue}`);
      } else {
        this.toastService.error(`Bin "${trimmed}" not found in current warehouse.`);
      }
    }
  }

  /**
   * Execute Pallet Transfer
   */
  async onSubmitTransfer(): Promise<void> {
    this.errorMessage = '';

    if (!this.locatedPallet?.palletId) {
      this.errorMessage = 'Please select a valid checked-in pallet first.';
      this.cd.markForCheck();
      return;
    }

    if (!this.selectedToBinId) {
      this.errorMessage = 'Please select or scan a destination bin.';
      this.cd.markForCheck();
      return;
    }

    this.isSubmitting = true;
    this.cd.markForCheck();

    try {
      const response = (await this.api.invoke(transferPallet, {
        body: {
          palletId: this.locatedPallet.palletId,
          toBinId: this.selectedToBinId,
          notes: this.notes.trim() || undefined,
        },
      })) as { success?: boolean; message?: string };

      if (response.success) {
        this.toastService.success(response.message || 'Pallet transferred successfully.');
        this.created.emit();
        this.closeModal();
      } else {
        this.errorMessage = response.message || 'Transfer failed. Destination bin may be occupied.';
      }
    } catch (err: any) {
      console.error('Pallet transfer failed:', err);
      this.errorMessage = err?.message || 'An error occurred during transfer.';
      this.toastService.error(this.errorMessage);
    } finally {
      this.isSubmitting = false;
      this.cd.markForCheck();
    }
  }
}