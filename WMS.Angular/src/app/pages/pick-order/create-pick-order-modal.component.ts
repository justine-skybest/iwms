import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  SimpleChanges,
  inject,
  ChangeDetectorRef,
  Output,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IconComponent } from '../../shared/components/icon/icon.component';
import { QrScannerComponent } from '../../shared/components/qr-scanner/qr-scanner.component';
import { Api } from '../../api/generated/api';
import { WarehouseService } from '../../lib/services/warehouse.service';
import {
  BinSummaryDto,
  CheckedInProductSumamryDto,
  CreateManualPickingDto,
  PickedProductDetailsDto,
} from '../../api/generated/models';
import {
  getBinStockById,
  getCheckedInBinByQrCode,
  manualpickingPost,
} from '../../api/generated/functions';
import { ToastService } from '../../lib/services/toast.service';

@Component({
  selector: 'app-create-pick-order-modal',
  standalone: true,
  imports: [CommonModule, FormsModule, IconComponent, QrScannerComponent],
  templateUrl: './create-pick-order-modal.component.html',
})
export class CreatePickOrderModalComponent implements OnChanges {
  protected readonly Math = Math;
  @Input() isOpen = false;
  @Output() closed = new EventEmitter<void>();
  @Output() created = new EventEmitter<void>();

  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);
  public warehouseService = inject(WarehouseService);
  private toastService = inject(ToastService);

  isSubmitting = false;
  isScanning = false;
  isLoadingItems = false;
  errorMessage = '';

  scannedBin: BinSummaryDto | null = null;
  binNumber = '';
  selectedCheckInId: number | null = null;

  binItems: CheckedInProductSumamryDto[] = [];
  selectedItems: { item: CheckedInProductSumamryDto; quantity: number }[] = [];
  isSelectAll = false;

  notes = '';
  pickingDate = this.today();

  get warehouseName(): string | null {
    return this.warehouseService.activeWarehouse()?.name ?? null;
  }

  get totalSelectedQuantity(): number {
    return this.selectedItems.reduce((sum, sel) => sum + sel.quantity, 0);
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['isOpen'] && this.isOpen) {
      this.resetForm();
    }
  }

  async onBinQrScanned(decodedText: string): Promise<void> {
    const hashCode = Number(decodedText.trim());
    const warehouseId = this.warehouseService.selectedWarehouseId();

    if (!hashCode || isNaN(hashCode)) {
      this.errorMessage = 'Invalid Bin QR code. Expected numeric HashCode.';
      this.cd.markForCheck();
      return;
    }

    if (!warehouseId) {
      this.errorMessage = 'Please select a warehouse first.';
      this.cd.markForCheck();
      return;
    }

    this.isScanning = true;
    this.errorMessage = '';
    this.cd.markForCheck();

    try {
      const bin = (await this.api.invoke(getCheckedInBinByQrCode, {
        BinHashCode: hashCode,
        WarehouseId: warehouseId,
      })) as BinSummaryDto;

      if (bin && bin.id && bin.id !== 0) {
        this.scannedBin = bin;
        this.binNumber = this.formatBinNumber(bin);
        await this.loadBinItems(bin.id);
      } else {
        this.errorMessage = bin?.warehouse || 'Scanned bin does not exist or has no stock.';
      }
    } catch (err) {
      console.error('Bin QR lookup failed:', err);
      this.errorMessage = 'Unable to locate bin for the scanned QR code.';
    } finally {
      this.isScanning = false;
      this.cd.markForCheck();
    }
  }

  async loadBinItems(binId: number): Promise<void> {
    this.isLoadingItems = true;
    this.cd.markForCheck();

    try {
      const response = await this.api.invoke(getBinStockById, { BinId: binId });
      const checkIns = (Array.isArray(response) ? response : response ? [response] : []) as any[];

      if (checkIns.length > 0) {
        this.selectedCheckInId = checkIns[0]?.id ?? null;
        const products = checkIns.flatMap((checkIn) => checkIn.receivedProducts || []);

        this.binItems = products;
        this.selectedItems = this.binItems.map((item) => ({
          item,
          quantity: 0,
        }));
        this.isSelectAll = false;
      } else {
        this.selectedCheckInId = null;
        this.binItems = [];
        this.selectedItems = [];
        this.isSelectAll = false;
      }
    } catch (err) {
      console.error('Failed to load bin items:', err);
      this.errorMessage = 'Failed to load items for the selected bin.';
    } finally {
      this.isLoadingItems = false;
      this.cd.markForCheck();
    }
  }

  /**
   * Toggles picking full quantities for all items in the bin
   */
  toggleSelectAll(event: Event): void {
    const isChecked = (event.target as HTMLInputElement).checked;
    this.isSelectAll = isChecked;

    this.selectedItems.forEach((sel) => {
      sel.quantity = isChecked ? (sel.item.quantity ?? 0) : 0;
    });

    this.cd.markForCheck();
  }

  onQuantityChange(index: number, event: Event): void {
    const value = Number((event.target as HTMLInputElement).value);
    const maxQuantity = this.selectedItems[index].item.quantity ?? 0;

    if (!isNaN(value) && value >= 0) {
      this.selectedItems[index].quantity = Math.min(value, maxQuantity);
    } else {
      this.selectedItems[index].quantity = 0;
    }

    this.updateSelectAllState();
  }

  incrementQuantity(index: number): void {
    const item = this.selectedItems[index];
    if (!item) return;
    const maxQuantity = item.item.quantity ?? 0;
    if (item.quantity < maxQuantity) {
      item.quantity++;
      this.updateSelectAllState();
    }
  }

  decrementQuantity(index: number): void {
    const item = this.selectedItems[index];
    if (!item) return;
    if (item.quantity > 0) {
      item.quantity--;
      this.updateSelectAllState();
    }
  }

  private updateSelectAllState(): void {
    if (this.selectedItems.length === 0) {
      this.isSelectAll = false;
      return;
    }

    this.isSelectAll = this.selectedItems.every(
      (sel) => sel.quantity === (sel.item.quantity ?? 0) && (sel.item.quantity ?? 0) > 0
    );
    this.cd.markForCheck();
  }

  async submitCreatePickOrder(): Promise<void> {
    const validationError = this.validate();
    if (validationError) {
      this.errorMessage = validationError;
      this.cd.markForCheck();
      return;
    }

    this.isSubmitting = true;
    this.errorMessage = '';
    this.cd.markForCheck();

    try {
      const validItems = this.selectedItems.filter((sel) => sel.quantity > 0);
      const checkInId = this.selectedCheckInId ?? 0;

      const pickedProducts: PickedProductDetailsDto[] = validItems.map((sel) => ({
        receivedProductId: sel.item.id,
        quantityPicked: sel.quantity,
        datePicked: this.pickingDate,
      }));

      const dto: CreateManualPickingDto = {
        checkInId,
        binId: this.scannedBin!.id,
        warehouseId: this.warehouseService.selectedWarehouseId() ?? undefined,
        notes: this.notes.trim() || null,
        pickingDate: this.pickingDate,
        pickedProducts,
      };

      await this.api.invoke(manualpickingPost, { body: dto });
      this.toastService.success(`New Pick-order successfully submitted`);
      this.resetForm();
      this.created.emit();
      this.closed.emit();
    } catch (err) {
      this.errorMessage = 'Failed to create pick order. Please try again.';
      this.toastService.error(`Failed to create pick order. Please try again.`);
      console.error('Failed to create pick order:', err);
    } finally {
      this.isSubmitting = false;
      this.cd.markForCheck();
    }
  }

  closeModal(): void {
    this.resetForm();
    this.closed.emit();
  }

  private validate(): string | null {
    if (!this.scannedBin) {
      return 'Please scan a bin QR code first.';
    }
    if (this.warehouseService.selectedWarehouseId() === null) {
      return 'Please select a warehouse first.';
    }
    if (this.totalSelectedQuantity === 0) {
      return 'Please select at least one item with a quantity > 0 to pick.';
    }
    return null;
  }

  public formatBinNumber(bin: BinSummaryDto): string {
    const cleanBinName = (bin.binName || '').replace(/Bin/gi, '').replace(/\s+/g, '');
    return `${bin.warehouse || ''}${bin.rack || ''}B${bin.bay || ''}L${bin.level || ''}-B${cleanBinName}`;
  }

  private resetForm(): void {
    this.errorMessage = '';
    this.isSubmitting = false;
    this.isScanning = false;
    this.isLoadingItems = false;
    this.scannedBin = null;
    this.binNumber = '';
    this.selectedCheckInId = null;
    this.binItems = [];
    this.selectedItems = [];
    this.isSelectAll = false;
    this.notes = '';
    this.pickingDate = this.today();
  }

  private today(): string {
    return new Date().toISOString().split('T')[0];
  }
}