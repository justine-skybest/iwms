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
import { IconComponent } from '../../../../shared/components/icon/icon.component';
import { QrScannerComponent } from '../../../../shared/components/qr-scanner/qr-scanner.component';
import { Api } from '../../../../api/generated/api';
import { WarehouseService } from '../../../../lib/services/warehouse.service';
import {
  CreateCheckInDto,
  PalletToBeCheckInDto,
  BinSummaryDto,
  ToCheckInProducts,
  PalletLocationDto,
} from '../../../../api/generated/models';
import {
  checkinPost,
  palletV2ToBeCheckInWarehouseIdGet,
  binV2Get,
  receivedProductV2ToCheckInProductsWarehouseIdGet,
  locatePalletByQrCode,
  binQrCodeBinHashCodeWarehouseIdGet,
} from '../../../../api/generated/functions';
import { SearchableSelectComponent, SelectOption } from '../select/select.component';
import { ToastService } from '../../../../lib/services/toast.service';

type CheckInType = 'Pallet' | 'Item';

@Component({
  selector: 'app-create-check-in-modal',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    IconComponent,
    SearchableSelectComponent,
    QrScannerComponent,
  ],
  templateUrl: './create-check-in-modal.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CreateCheckInModalComponent implements OnChanges {
  @Input() isOpen = false;
  @Output() closed = new EventEmitter<void>();
  @Output() created = new EventEmitter<void>();

  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);
  private warehouseService = inject(WarehouseService);
  private toastService = inject(ToastService)

  isSubmitting = false;
  isLocatingPallet = false;
  isLocatingBin = false;
  createError = '';

  checkInType: CheckInType = 'Pallet';
  checkInDate = this.today();
  notes = '';

  selectedPallet: SelectOption<PalletToBeCheckInDto>[] = [];
  selectedProducts: SelectOption<ToCheckInProducts>[] = [];
  selectedBins: SelectOption<BinSummaryDto>[] = [];

  private productsPromise: Promise<SelectOption<ToCheckInProducts>[]> | null = null;
  private binsPromise: Promise<SelectOption<BinSummaryDto>[]> | null = null;

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['isOpen'] && this.isOpen) {
      this.resetForm();
    }
  }

  onTypeChange(type: CheckInType): void {
    if (this.checkInType === type) {
      return;
    }
    this.checkInType = type;
    this.selectedPallet = [];
    this.selectedProducts = [];
    this.createError = '';
  }

  // --- PALLET QR SCANNER HANDLER ----------------------------------------

  async onPalletQrScanned(decodedText: string): Promise<void> {
    const hashCode = Number(decodedText.trim());
    const warehouseId = this.warehouseService.selectedWarehouseId();

    if (!hashCode || isNaN(hashCode)) {
      this.createError = 'Invalid Pallet QR code. Expected numeric HashCode.';
      this.cd.markForCheck();
      return;
    }

    if (!warehouseId) {
      this.createError = 'Please select a warehouse first.';
      this.cd.markForCheck();
      return;
    }

    this.isLocatingPallet = true;
    this.createError = '';
    this.cd.markForCheck();

    try {
      const pallet = (await this.api.invoke(locatePalletByQrCode, {
        hashCode,
        warehouseId,
      })) as PalletLocationDto;

      if (pallet && pallet.palletId) {
        this.selectedPallet = [
          {
            id: pallet.palletId,
            label: `Pallet #${pallet.palletNumber ?? pallet.palletId}`,
            sublabel: pallet.currentBinLocation ? `Location: ${pallet.currentBinLocation}` : undefined,
            raw: {
              id: pallet.palletId,
              palletNumber: pallet.palletNumber,
              warehouse: undefined,
            } as PalletToBeCheckInDto,
          },
        ];
      } else {
        this.createError = pallet?.message || 'Pallet not found for scanned QR code.';
      }
    } catch (err) {
      console.error('Pallet QR lookup failed:', err);
      this.createError = 'Unable to locate pallet for the scanned QR code.';
    } finally {
      this.isLocatingPallet = false;
      this.cd.markForCheck();
    }
  }

  // --- BIN QR SCANNER HANDLER -------------------------------------------

  async onBinQrScanned(decodedText: string): Promise<void> {
    const hashCode = Number(decodedText.trim());
    const warehouseId = this.warehouseService.selectedWarehouseId();

    if (!hashCode || isNaN(hashCode)) {
      this.createError = 'Invalid Bin QR code. Expected numeric HashCode.';
      this.cd.markForCheck();
      return;
    }

    if (!warehouseId) {
      this.createError = 'Please select a warehouse first.';
      this.cd.markForCheck();
      return;
    }

    this.isLocatingBin = true;
    this.createError = '';
    this.cd.markForCheck();

    try {
      const bin = (await this.api.invoke(binQrCodeBinHashCodeWarehouseIdGet, {
        binHashCode: hashCode,
        warehouseId: warehouseId,
      })) as BinSummaryDto;

      if (bin && bin.id) {
        const binOption: SelectOption<BinSummaryDto> = {
          id: bin.id,
          label: bin.binName ?? `Bin #${bin.id}`,
          sublabel: [bin.rack, bin.level, bin.bay].filter(Boolean).join(' / '),
          raw: bin,
        };

        // Add to multi-select bin array without duplicates
        if (!this.selectedBins.some((b) => b.id === binOption.id)) {
          this.selectedBins = [...this.selectedBins, binOption];
        }
      } else {
        this.createError = `Error: ${bin.warehouse?? "something went wrong."}`;
      }
    } catch (err) {
      console.error('Bin QR lookup failed:', err);
      this.createError = 'Unable to locate bin for the scanned QR code.';
    } finally {
      this.isLocatingBin = false;
      this.cd.markForCheck();
    }
  }

  // --- SEARCH FUNCTIONS --------------------------------------------------

  searchPallets = async (term: string): Promise<SelectOption<PalletToBeCheckInDto>[]> => {
    const res = await this.api.invoke(palletV2ToBeCheckInWarehouseIdGet, {
      WarehouseId: this.warehouseService.selectedWarehouseId()!,
      search: term,
      page: 1,
      pageSize: 20,
    });
    return (res?.items ?? [])
      .filter((p): p is PalletToBeCheckInDto & { id: number } => p.id != null)
      .map((p) => ({
        id: p.id,
        label: p.palletNumber!,
        sublabel: p.warehouse ?? undefined,
        raw: p,
      }));
  };

  searchProducts = async (term: string): Promise<SelectOption<ToCheckInProducts>[]> => {
    const options = await this.loadProducts();
    return this.filterByLabel(options, term);
  };

  searchBins = async (term: string): Promise<SelectOption<BinSummaryDto>[]> => {
    const options = await this.loadBins();
    return this.filterByLabel(options, term);
  };

  private filterByLabel<T>(options: SelectOption<T>[], term: string): SelectOption<T>[] {
    const q = term.trim().toLowerCase();
    if (!q) {
      return options;
    }
    return options.filter(
      (o) => o.label.toLowerCase().includes(q) || o.sublabel?.toLowerCase().includes(q)
    );
  }

  private loadProducts(): Promise<SelectOption<ToCheckInProducts>[]> {
    if (!this.productsPromise) {
      this.productsPromise = this.api
        .invoke(receivedProductV2ToCheckInProductsWarehouseIdGet, {
          WarehouseId: this.warehouseService.selectedWarehouseId()!,
          page: 1,
          pageSize: 200,
        })
        .then((res) =>
          (res?.items ?? [])
            .filter((p): p is ToCheckInProducts & { id: number } => p.id != null)
            .map((p) => ({
              id: p.id,
              label: p.name ?? `Product #${p.id}`,
              sublabel: [p.receivingSeries, p.quantity != null ? `Qty: ${p.quantity}` : null]
                .filter(Boolean)
                .join(' \u00b7 '),
              raw: p,
            }))
        )
        .catch((err) => {
          this.productsPromise = null;
          throw err;
        });
    }
    return this.productsPromise;
  }

  private loadBins(): Promise<SelectOption<BinSummaryDto>[]> {
    if (!this.binsPromise) {
      this.binsPromise = this.api
        .invoke(binV2Get, {
          warehouseId: this.warehouseService.selectedWarehouseId()!,
          page: 1,
          pageSize: 200,
        })
        .then((res) =>
          (res?.items ?? [])
            .filter((b): b is BinSummaryDto & { id: number } => b.id != null)
            .map((b) => ({
              id: b.id,
              label: `${b.rack} / Bay ${b.bay} / Level ${b.level} / ${b.binName}`,
              sublabel: '',
              raw: b,
            }))
        )
        .catch((err) => {
          this.binsPromise = null;
          throw err;
        });
    }
    return this.binsPromise;
  }

  closeModal(): void {
    this.resetForm();
    this.closed.emit();
  }

  private today(): string {
    return new Date().toISOString().split('T')[0];
  }

  private resetForm(): void {
    this.createError = '';
    this.isLocatingPallet = false;
    this.isLocatingBin = false;
    this.checkInType = 'Pallet';
    this.checkInDate = this.today();
    this.notes = '';
    this.selectedPallet = [];
    this.selectedProducts = [];
    this.selectedBins = [];
    this.productsPromise = null;
    this.binsPromise = null;
  }

  private validate(): string | null {
    if (this.checkInType === 'Pallet' && this.selectedPallet.length === 0) {
      return 'Please select or scan a pallet.';
    }
    if (this.checkInType === 'Item' && this.selectedProducts.length === 0) {
      return 'Please select at least one product.';
    }
    if (this.selectedBins.length === 0) {
      return 'Please select or scan at least one bin location.';
    }
    return null;
  }

  async submitCreateCheckIn(): Promise<void> {
    const validationError = this.validate();
    if (validationError) {
      this.createError = validationError;
      this.cd.markForCheck();
      return;
    }

    this.isSubmitting = true;
    this.createError = '';
    this.cd.markForCheck();

    const baseDto: CreateCheckInDto = {
      palletId: this.checkInType === 'Pallet' ? this.selectedPallet[0]?.raw.id ?? null : null,
      checkInType: this.checkInType,
      checkInDate: this.checkInDate,
      notes: this.notes?.trim() || null,
      binIds: this.selectedBins.map((b) => b.id),
      receivedProductIds: this.checkInType === 'Item' ? this.selectedProducts.map((p) => p.id) : [],
    };

    const dto = this.warehouseService.withWarehouse(baseDto);

    try {
      await this.api.invoke(checkinPost, { body: dto });
      this.toastService.success(`New Checkin successfully submitted`)
      this.resetForm();
      this.created.emit();
      this.closed.emit();
    } catch (err) {
      this.createError = 'Failed to create check-in transaction. Please try again.';
      this.toastService.error(`Failed to create check-in transaction. Please try again.`)
      console.error('Failed to create check-in:', { dto, err });
    } finally {
      this.isSubmitting = false;
      this.cd.markForCheck();
    }
  }
}