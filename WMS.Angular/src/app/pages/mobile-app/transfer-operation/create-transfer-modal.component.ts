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
  transferBinContents,
  binV2Get,
  getCheckedInBinByQrCode,
  transferPalletV2,
  transferItemV2,
  getBinStockById,
  getBinByHashCode,
} from '../../../api/generated/functions';
import {
  BinSummaryDto,
  BinSummaryDtoPaginatedResponse,
  TransferResultDto,
  DisplayCheckInProductsDto,
  BinDetailsDto,
} from '../../../api/generated/models';
import { WarehouseService } from '../../../lib/services/warehouse.service';
import { ToastService } from '../../../lib/services/toast.service';
import { IconComponent } from '../../../shared/components/icon/icon.component';
import { QrScannerComponent } from '../../../shared/components/qr-scanner/qr-scanner.component';
import { SearchableSelectComponent, SelectOption } from '../../check-in/components/select/select.component';

export type SourceType = 'BIN' | 'NONE';
export type BinTransferMode = 'ALL' | 'BATCH';

@Component({
  selector: 'app-create-transfer-modal',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    IconComponent,
    QrScannerComponent,
    SearchableSelectComponent,
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

  // Statuses
  isSubmitting = false;
  isLocating = false;
  isLoadingItems = false;
  errorMessage = '';

  // Smart Search & Source State
  searchQuery = '';
  sourceType: SourceType = 'NONE';
  sourceBin: BinSummaryDto | null = null;

  // Bin Transfer Options
  binTransferMode: BinTransferMode = 'ALL';
  checkInsInBin: DisplayCheckInProductsDto[] = [];
  selectedCheckIn: DisplayCheckInProductsDto | null = null;

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
    this.sourceType = 'NONE';
    this.sourceBin = null;
    this.binTransferMode = 'ALL';
    this.checkInsInBin = [];
    this.selectedCheckIn = null;
    this.selectedDestinationBinOption = [];
    this.notes = '';
    this.errorMessage = '';
    this.isSubmitting = false;
    this.isLocating = false;
    this.isLoadingItems = false;
    this.cd.markForCheck();
  }

  closeModal(): void {
    this.closed.emit();
  }

  /**
   * Directly scans and resolves the Source Bin QR Code
   */
  async processSmartScan(code: string): Promise<void> {
    const trimmed = code.trim();
    if (!trimmed) return;

    this.searchQuery = trimmed;
    const warehouseId = this.warehouseService.selectedWarehouseId();

    if (!warehouseId) {
      this.toastService.error('Please select a specific warehouse location first.');
      return;
    }

    const binHashCode = Number(trimmed);
    if (isNaN(binHashCode)) {
      this.errorMessage = 'Bin QR code / Hash must be a valid numeric value.';
      this.cd.markForCheck();
      return;
    }

    this.isLocating = true;
    this.errorMessage = '';
    this.sourceType = 'NONE';
    this.sourceBin = null;
    this.checkInsInBin = [];
    this.selectedCheckIn = null;
    this.cd.markForCheck();

    try {
      // Direct Bin lookup by Hash Code & Warehouse ID
      const binResponse = (await this.api.invoke(getCheckedInBinByQrCode, {
        BinHashCode: binHashCode,
        WarehouseId: warehouseId,
      })) as BinSummaryDto;

      if (binResponse?.id) {
        this.sourceType = 'BIN';
        this.sourceBin = binResponse;
        this.binTransferMode = 'ALL'; // Default to Bulk Bin Transfer
        this.toastService.success(`Source Bin "${binResponse.binName || binResponse.id}" selected.`);

        // Fetch check-in batches stored in this bin
        await this.fetchItemsInBin(binResponse.id);
        return;
      }

      this.errorMessage = `No checked-in Bin found matching QR code "${trimmed}".`;
    } catch (err: any) {
      console.error('Bin lookup error:', err);
      this.errorMessage = 'An error occurred while resolving the bin location. Please try again.';
    } finally {
      this.isLocating = false;
      this.cd.markForCheck();
    }
  }

  /**
   * Fetch structured check-in batches stored in a source bin
   */
  private async fetchItemsInBin(binId: number): Promise<void> {
    this.isLoadingItems = true;
    this.cd.markForCheck();

    try {
      const res = (await this.api.invoke(getBinStockById, { BinId: binId })) as DisplayCheckInProductsDto[];

      this.checkInsInBin = (Array.isArray(res) ? res : [res]) as DisplayCheckInProductsDto[];
    } catch (err) {
      console.error('Failed to fetch items in bin:', err);
      this.checkInsInBin = [];
    } finally {
      this.isLoadingItems = false;
      this.cd.markForCheck();
    }
  }

  /**
   * Toggle between Bulk Bin transfer or Batch/Pallet transfer
   */
  setBinTransferMode(mode: BinTransferMode): void {
    this.binTransferMode = mode;
    if (mode === 'ALL') {
      this.selectedCheckIn = null;
    }
    this.cd.markForCheck();
  }

  /**
   * Async Search Function for Destination Bins
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

  onDestinationBinSelectChange(options: SelectOption<BinSummaryDto>[]): void {
    this.selectedDestinationBinOption = options;
    this.errorMessage = '';
    this.cd.markForCheck();
  }

async onDestinationBinQrScanned(scannedText: string): Promise<void> {
  const trimmed = scannedText.trim();
  if (!trimmed) return;

  const warehouseId = this.warehouseService.selectedWarehouseId();
  if (!warehouseId) {
    this.toastService.error('Please select a specific warehouse location first.');
    return;
  }

  const hashCode = Number(trimmed);
  if (isNaN(hashCode)) {
    this.toastService.error('Scanned bin code must be a valid numeric hash code.');
    return;
  }

  try {
    const bin = (await this.api.invoke(getBinByHashCode, {
      hashCode: hashCode,
      warehouseId: warehouseId,
    })) as any;

    const resolvedId = bin?.id ?? bin?.binId;

    if (bin && resolvedId) {
      const option: SelectOption<BinSummaryDto> = {
        id: resolvedId,
        label: bin.binName ? `${bin.binName}${bin.binHashCode ? ` (${bin.binHashCode})` : ''}` : `Bin #${resolvedId}${bin.binHashCode ? ` (${bin.binHashCode})` : ''}`,
        sublabel: [
          bin.rack ? `${bin.rack}` : null,
          bin.bay ? `Bay ${bin.bay}` : null,
          bin.level ? `Level ${bin.level}` : null,
        ].filter(Boolean).join(' / ') || 'Warehouse Bin',
        raw: {
          id: resolvedId,
          binHashCode: bin.binHashCode?.toString(),
          binName: bin.binName ?? `Bin #${resolvedId}`,
          rack: bin.rack,
          bay: bin.bay,
          level: bin.level,
        },
      };

      this.onDestinationBinSelectChange([option]);
      this.toastService.success(`Destination Bin #${resolvedId} selected.`);
    } else {
      this.toastService.error(`Destination bin with QR hash "${trimmed}" not found.`);
    }
  } catch (err: any) {
    console.error('Error scanning destination bin:', err);
    this.toastService.error(
      err?.message || `Destination bin with QR hash "${trimmed}" not found in this warehouse.`
    );
  }
}

  /**
   * Execute Transfer
   */
  async onSubmitTransfer(): Promise<void> {
    this.errorMessage = '';

    const toBinId = this.selectedDestinationBinOption[0]?.id;
    if (!toBinId) {
      this.errorMessage = 'Please select or scan a destination bin location.';
      this.cd.markForCheck();
      return;
    }

    if (this.sourceBin?.id === toBinId) {
      this.errorMessage = 'Destination bin must be different from source bin.';
      this.cd.markForCheck();
      return;
    }

    this.isSubmitting = true;
    this.cd.markForCheck();

    try {
      let res: TransferResultDto = {};

      if (this.sourceType === 'BIN' && this.sourceBin?.id) {
        // Mode 1: Bulk Transfer All CheckIns
        if (this.binTransferMode === 'ALL') {
          res = (await this.api.invoke(transferBinContents, {
            body: {
              fromBinId: this.sourceBin.id,
              toBinId: toBinId,
              notes: this.notes.trim() || undefined,
            },
          })) as TransferResultDto;

        // Mode 2: Specific Batch Transfer
        } else if (this.binTransferMode === 'BATCH' && this.selectedCheckIn) {
          if (this.selectedCheckIn.palletNumber && this.selectedCheckIn.receivedProducts?.length) {
            // Pallet check-in batch
            const palletIdStr = this.selectedCheckIn.receivedProducts[0].palletId;
            const palletId = palletIdStr ? Number(palletIdStr) : null;

            if (!palletId) throw new Error('Pallet ID missing from check-in record.');

            res = (await this.api.invoke(transferPalletV2, {
              body: { palletId, toBinId, notes: this.notes.trim() || undefined },
            })) as TransferResultDto;
          } else {
            // Loose item check-in batch
            const items = this.selectedCheckIn.receivedProducts || [];

            for (const item of items) {
              res = (await this.api.invoke(transferItemV2, {
                body: {
                  fromCheckInId: this.selectedCheckIn.id!,
                  receivedProductId: item.id!,
                  toBinId: toBinId,
                  notes: this.notes.trim() || undefined,
                },
              })) as TransferResultDto;

              if (!res.success) {
                throw new Error(`Failed to transfer item ${item.name}: ${res.message}`);
              }
            }
            res = { success: true, message: 'Loose batch transferred successfully.' };
          }
        } else {
          throw new Error('Please select a batch to transfer.');
        }
      }

      if (res.success) {
        this.toastService.success(res.message || 'Transfer executed successfully.');
        this.created.emit();
        this.closeModal();
      } else {
        this.errorMessage = res.message || 'Transfer failed. Destination bin may be occupied.';
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
