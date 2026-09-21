import { Component, EventEmitter, Input, Output, inject, ChangeDetectorRef, ElementRef, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../../api/generated/api';
import { WarehouseService } from '../../../lib/services/warehouse.service';
import { CreateReceivingDto, PalletLocationDto, ProductSummaryDto, ProductSummaryDtoPaginatedResponse, ReceivedProductDetailsDto } from '../../../api/generated/models';
import { locatePalletByQrCode, productV2Get, receivingPost } from '../../../api/generated/functions';
import { QrScannerComponent } from '../../../shared/components/qr-scanner/qr-scanner.component';
import { LucideAngularModule, Trash2, Search, ChevronDown, X, Loader2, Check } from 'lucide-angular';
import { ToastService } from '../../../lib/services/toast.service';

type ItemType = 'individual' | 'palletized';

export type StagedProductItem = ReceivedProductDetailsDto & {
  productName?: string;
  typeOfPackage?: string;
  measurement?: string;
};

@Component({
  selector: 'app-receiving-create',
  standalone: true,
  imports: [CommonModule, FormsModule, LucideAngularModule, QrScannerComponent],
  templateUrl: './receiving-create.component.html',
})
export class ReceivingCreateComponent {
  readonly TrashIcon = Trash2;
  readonly SearchIcon = Search;
  readonly ChevronDownIcon = ChevronDown;
  readonly XIcon = X;
  readonly LoaderIcon = Loader2;
  readonly CheckIcon = Check;

  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);
  private elementRef = inject(ElementRef);
  public warehouseService = inject(WarehouseService);
  private toastService = inject(ToastService)

  @Input() isOpen = false;
  @Output() close = new EventEmitter<void>();
  @Output() created = new EventEmitter<void>();

  isSaving = false;
  isLocatingPallet = false;
  palletError = '';
  validationError = '';

  newReceiving: CreateReceivingDto = this.getInitialForm();
  stagedItems: StagedProductItem[] = [];
  itemType: ItemType = 'individual';
  isBoxed = false;

  palletQrCodeInput = '';
  scannedPallet: PalletLocationDto | null = null;
  productDraft: StagedProductItem = this.getInitialProductDraft();

  // --- PRODUCT COMBOBOX STATE ---
  productSearchQuery = '';
  searchedProducts: ProductSummaryDto[] = [];
  isSearchingProducts = false;
  isProductDropdownOpen = false;
  selectedProduct: ProductSummaryDto | null = null;
  private searchDebounceTimer: any;

  @HostListener('document:click', ['$event'])
  onClickOutside(event: Event): void {
    if (!this.elementRef.nativeElement.contains(event.target)) {
      this.isProductDropdownOpen = false;
    }
  }

  private generateDefaultSeries(): string {
    const currentYearSuffix = new Date().getFullYear().toString().slice(-2);
    return `SLCWH-00001-${currentYearSuffix}`;
  }

  private getInitialForm(): CreateReceivingDto {
    const now = new Date();
    const today = now.toISOString().split('T')[0];
    const currentTime = now.toTimeString().split(' ')[0].substring(0, 5);

    return {
      series: this.generateDefaultSeries(),
      driverName: '',
      plateNumber: '',
      warehouseId: this.warehouseService.selectedWarehouseId() ?? undefined,
      dateReceived: today,
      dateAdded: now.toISOString(),
      dateTime: now.toISOString(),
      timeStart: currentTime,
      timeEnd: currentTime,
      transportCompany: '',
      shipper: '',
      consignee: '',
      reference: '',
      checkerName: '',
      clientRepresentative: '',
      products: []
    };
  }

  private getInitialProductDraft(): StagedProductItem {
    return {
      productId: undefined,
      productName: '',
      typeOfPackage: '',
      measurement: '',
      palletId: null,
      quantity: 1,
      cbm: '',
      totalWeight: '',
      expirationDate: new Date().toISOString().split('T')[0],
      remarks: '',
      containerName: ''
    };
  }

  // --- PRODUCT COMBOBOX METHODS ---
  onProductSearchInput(): void {
    this.isProductDropdownOpen = true;
    clearTimeout(this.searchDebounceTimer);

    this.searchDebounceTimer = setTimeout(() => {
      void this.searchProducts();
    }, 300);
  }

  async openProductDropdown(): Promise<void> {
    this.isProductDropdownOpen = true;
    if (this.searchedProducts.length === 0) {
      await this.searchProducts();
    }
  }

  async searchProducts(): Promise<void> {
    this.isSearchingProducts = true;
    this.cd.markForCheck();

    try {
      const response = await this.api.invoke(productV2Get, {
        search: this.productSearchQuery.trim(),
        pageSize: 20
      }) as ProductSummaryDtoPaginatedResponse;

      this.searchedProducts = response.items ?? [];
    } catch (err) {
      console.error('Failed to search products:', err);
      this.searchedProducts = [];
    } finally {
      this.isSearchingProducts = false;
      this.cd.markForCheck();
    }
  }

  selectProduct(product: ProductSummaryDto): void {
    this.selectedProduct = product;
    this.productDraft.productId = product.id;
    this.productDraft.productName = product.name || '';
    this.productDraft.typeOfPackage = (product as any).typeOfPackage || (product as any).packageType || '';
    this.productDraft.measurement = (product as any).measurement || '';
    this.productSearchQuery = product.name || `Product #${product.id}`;
    this.isProductDropdownOpen = false;
    this.cd.markForCheck();
  }

  clearProductSelection(): void {
    this.selectedProduct = null;
    this.productDraft.productId = undefined;
    this.productDraft.productName = '';
    this.productDraft.typeOfPackage = '';
    this.productDraft.measurement = '';
    this.productSearchQuery = '';
    this.searchedProducts = [];
    this.isProductDropdownOpen = false;
    this.cd.markForCheck();
  }

  // --- PALLET LOOKUP & STAGING ---
  onItemTypeChange(): void {
    this.clearScannedPallet();
  }

  onQrScanned(decodedText: string): void {
    this.palletQrCodeInput = decodedText;
    this.cd.markForCheck();
    void this.scanAndLocatePallet();
  }

  async scanAndLocatePallet(): Promise<void> {
    const hashCode = Number(this.palletQrCodeInput.trim());
    const warehouseId = this.warehouseService.selectedWarehouseId();

    if (!hashCode || isNaN(hashCode)) {
      this.palletError = 'Invalid QR code. Expected numeric HashCode.';
      return;
    }

    if (!warehouseId) {
      this.palletError = 'Please select a warehouse first.';
      return;
    }

    this.isLocatingPallet = true;
    this.palletError = '';
    this.cd.markForCheck();

    try {
      const pallet = await this.api.invoke(locatePalletByQrCode, { hashCode, warehouseId }) as PalletLocationDto;
      if (pallet && pallet.palletId) {
        this.scannedPallet = pallet;
        this.productDraft.palletId = pallet.palletId;
      } else {
        this.palletError = pallet?.message || 'Pallet not found for scanned QR code.';
      }
    } catch (err) {
      console.error('Pallet lookup failed:', err);
      this.palletError = 'Unable to locate pallet. Check QR and Warehouse context.';
    } finally {
      this.isLocatingPallet = false;
      this.cd.markForCheck();
    }
  }

  clearScannedPallet(): void {
    this.scannedPallet = null;
    this.palletQrCodeInput = '';
    this.productDraft.palletId = null;
    this.palletError = '';
    this.isBoxed = false;
    this.productDraft.containerName = '';
    this.productDraft.cbm = '';
    this.productDraft.totalWeight = '';
    this.cd.markForCheck();
  }

  addProductItem(): void {
    this.validationError = '';

    if (!this.productDraft.productId) {
      this.validationError = 'Please search and select a Product.';
      return;
    }

    if ((this.productDraft.quantity ?? 0) <= 0) {
      this.validationError = 'Product quantity must be greater than 0.';
      return;
    }

    if (this.itemType === 'palletized' && !this.productDraft.palletId) {
      this.validationError = 'Please scan/locate a valid Pallet first for palletized items.';
      return;
    }

    this.stagedItems.push({ ...this.productDraft });
    this.newReceiving.products = this.stagedItems;

    this.productDraft = this.getInitialProductDraft();
    this.clearProductSelection();
    this.scannedPallet = null;
    this.palletQrCodeInput = '';
    this.isBoxed = false;
    this.cd.markForCheck();
  }

  removeProductItem(index: number): void {
    this.stagedItems.splice(index, 1);
    this.newReceiving.products = this.stagedItems;
    this.cd.markForCheck();
  }

  clearAllStagedItems(): void {
    if (confirm('Are you sure you want to remove all staged items?')) {
      this.stagedItems = [];
      this.newReceiving.products = [];
      this.cd.markForCheck();
    }
  }

  // --- DTO VALIDATION METHOD ---
  private validateForm(): string | null {
    const warehouseId = this.warehouseService.selectedWarehouseId();
    if (!warehouseId) return 'Warehouse context is required. Please select a warehouse.';

    if (!this.newReceiving.series?.trim()) return 'Series Number is required.';
    if (this.newReceiving.series.trim().length > 15) return 'Series Number cannot exceed 15 characters.';

    if (!this.newReceiving.transportCompany?.trim()) return 'Transport Company is required.';
    if (this.newReceiving.transportCompany.trim().length > 85) return 'Transport Company cannot exceed 85 characters.';

    if (!this.newReceiving.shipper?.trim()) return 'Shipper / Exporter is required.';
    if (this.newReceiving.shipper.trim().length > 85) return 'Shipper cannot exceed 85 characters.';

    if (this.newReceiving.consignee && this.newReceiving.consignee.length > 85) {
      return 'Consignee cannot exceed 85 characters.';
    }

    if (!this.newReceiving.reference?.trim()) return 'Reference / DR Ref No. is required.';
    if (this.newReceiving.reference.trim().length > 35) return 'Reference No. cannot exceed 35 characters.';

    if (!this.newReceiving.plateNumber?.trim()) return 'Plate Number is required.';
    if (this.newReceiving.plateNumber.trim().length > 25) return 'Plate Number cannot exceed 25 characters.';

    if (!this.newReceiving.driverName?.trim()) return 'Driver Name is required.';
    if (this.newReceiving.driverName.trim().length > 50) return 'Driver Name cannot exceed 50 characters.';

    if (this.newReceiving.clientRepresentative && this.newReceiving.clientRepresentative.length > 50) {
      return 'Client Representative cannot exceed 50 characters.';
    }

    if (this.newReceiving.checkerName && this.newReceiving.checkerName.length > 50) {
      return 'Checker Name cannot exceed 50 characters.';
    }

    if (!this.stagedItems || this.stagedItems.length === 0) {
      return 'At least one received product item must be added.';
    }

    return null;
  }

  private toIsoDateTime(dateStr?: string, timeStr?: string): string {
    const baseDate = dateStr || new Date().toISOString().split('T')[0];
    if (!timeStr) {
      return new Date(baseDate).toISOString();
    }
    const formattedTime = timeStr.length === 5 ? `${timeStr}:00` : timeStr;
    return new Date(`${baseDate}T${formattedTime}`).toISOString();
  }

  async saveReceiving(): Promise<void> {
    const error = this.validateForm();
    if (error) {
      this.validationError = error;
      this.cd.markForCheck();
      return;
    }

    this.validationError = '';
    this.isSaving = true;

    const payload: CreateReceivingDto = {
      ...this.newReceiving,
      warehouseId: this.warehouseService.selectedWarehouseId()!,
      series: this.newReceiving.series?.trim() ?? '',
      transportCompany: this.newReceiving.transportCompany?.trim() ?? '',
      shipper: this.newReceiving.shipper?.trim() ?? '',
      consignee: this.newReceiving.consignee?.trim() || undefined,
      reference: this.newReceiving.reference?.trim() ?? '',
      plateNumber: this.newReceiving.plateNumber?.trim() ?? '',
      driverName: this.newReceiving.driverName?.trim() ?? '',
      checkerName: this.newReceiving.checkerName?.trim() || undefined,
      clientRepresentative: this.newReceiving.clientRepresentative?.trim() || undefined,
      dateReceived: this.toIsoDateTime(this.newReceiving.dateReceived),
      dateAdded: new Date().toISOString(),
      dateTime: new Date().toISOString(),
      timeStart: this.toIsoDateTime(this.newReceiving.dateReceived, this.newReceiving.timeStart),
      timeEnd: this.toIsoDateTime(this.newReceiving.dateReceived, this.newReceiving.timeEnd),
      products: this.stagedItems
    };

    try {
      await this.api.invoke(receivingPost, { body: payload });
      this.toastService.success(`Receiving ${payload.series} successfully submitted`)
      this.created.emit();
      this.onClose();
    } catch (err) {
      console.error('Failed to create receiving:', err);
      this.toastService.error(`Failed to create receiving: ${err}`)
      this.validationError = 'Failed to save receiving receipt. Please check server connection.';
    } finally {
      this.isSaving = false;
      this.cd.markForCheck();
    }
  }

  onClose(): void {
    this.newReceiving = this.getInitialForm();
    this.stagedItems = [];
    this.productDraft = this.getInitialProductDraft();
    this.clearProductSelection();
    this.scannedPallet = null;
    this.palletQrCodeInput = '';
    this.palletError = '';
    this.validationError = '';
    this.close.emit();
  }
}