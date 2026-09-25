import { Component, EventEmitter, Input, Output, inject, ChangeDetectorRef, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../../api/generated/api';
import { WarehouseService } from '../../../lib/services/warehouse.service';
import { 
  CreateReceivingDto, 
  IncomingResponseDto, 
  IncomingResponseDtoPaginatedResponse, 
  PalletLocationDto, 
  ReceivedProductDetailsDto 
} from '../../../api/generated/models';
import { createReceiving, getUnreceivedIncomings, locatePalletByQrCode } from '../../../api/generated/functions';
import { QrScannerComponent } from '../../../shared/components/qr-scanner/qr-scanner.component';
import { LucideAngularModule, Trash2, Search, ChevronDown, X, Loader2, Check, QrCode, Box, Plus, AlertTriangle, ShieldCheck, FileSpreadsheet, PackageCheck } from 'lucide-angular';
import { ToastService } from '../../../lib/services/toast.service';
import { formatDate } from '../../../lib/utils/format-date';

export type DiscrepancyCategory = 
  | 'QUANTITY' 
  | 'DESCRIPTION' 
  | 'EXPIRY' 
  | 'WEIGHT' 
  | 'CBM' 
  | 'DAMAGED' 
  | 'OTHER';

export interface DiscrepancyOption {
  key: DiscrepancyCategory;
  label: string;
}

export interface SelectableIncomingProduct {
  productId: number;
  productName?: string;
  quantity?: number;
  cbm?: string;
  totalWeight?: string;
  expirationDate?: string;
  supplier?: string;
  remarks?: string;
  received?: boolean;
  selected: boolean;
}

export type StagedProductItem = ReceivedProductDetailsDto & {
  productName?: string;
  typeOfPackage?: string;
  measurement?: string;

  isMatched: boolean;
  discrepancies: DiscrepancyCategory[];
  
  expectedProductName?: string;
  expectedQuantity?: number;
  expectedCbm?: string;
  expectedTotalWeight?: string;
  expectedExpirationDate?: string;
};

export interface DiscrepancySummary {
  matchedCount: number;
  flaggedCount: number;
  totalItems: number;
  totalQuantityShortage: number;
  totalQuantityExcess: number;
  categoryCounts: Record<DiscrepancyCategory, number>;
}

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
  readonly QrIcon = QrCode;
  readonly BoxIcon = Box;
  readonly PlusIcon = Plus;
  readonly AlertIcon = AlertTriangle;
  readonly ShieldCheckIcon = ShieldCheck;
  readonly SummaryIcon = FileSpreadsheet;
  readonly PackageCheckIcon = PackageCheck;

  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);
  public warehouseService = inject(WarehouseService);
  private toastService = inject(ToastService);

  public formatDate = formatDate;

  @Input() isOpen = false;
  @Output() close = new EventEmitter<void>();
  @Output() created = new EventEmitter<void>();

  isSaving = false;
  validationError = '';

  newReceiving: CreateReceivingDto = this.getInitialForm();
  stagedItems: StagedProductItem[] = [];

  readonly discrepancyOptions: DiscrepancyOption[] = [
    { key: 'QUANTITY', label: 'Qty Variance' },
    { key: 'DESCRIPTION', label: 'Spelling/Desc' },
    { key: 'EXPIRY', label: 'Expiry Date' },
    { key: 'WEIGHT', label: 'Weight Diff' },
    { key: 'CBM', label: 'CBM Diff' },
    { key: 'DAMAGED', label: 'Damaged Goods' },
    { key: 'OTHER', label: 'Other Issue' }
  ];

  incomingSearchQuery = '';
  searchedIncomings: IncomingResponseDto[] = [];
  isSearchingIncomings = false;
  isIncomingDropdownOpen = false;
  selectedIncoming: IncomingResponseDto | null = null;


  isProductDropdownOpen = false;
  productFilterQuery = '';
  availableIncomingProducts: SelectableIncomingProduct[] = [];

  isPalletModalOpen = false;
  activeRowIndexForPallet: number | null = null;
  palletQrCodeInput = '';
  scannedPallet: PalletLocationDto | null = null;
  isLocatingPallet = false;
  palletError = '';

  private incomingSearchDebounce: any;

  // Global document click listener closes open dropdowns
  @HostListener('document:click')
  onDocumentClick(): void {
    this.isIncomingDropdownOpen = false;
    this.isProductDropdownOpen = false;
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

  // --- INCOMING SHIPMENT SELECTION ---
  onIncomingSearchInput(event?: Event): void {
    if (event) event.stopPropagation();
    this.isIncomingDropdownOpen = true;
    clearTimeout(this.incomingSearchDebounce);
    this.incomingSearchDebounce = setTimeout(() => { void this.searchIncomings(); }, 300);
  }

  async openIncomingDropdown(event?: Event): Promise<void> {
    if (event) event.stopPropagation();
    this.isIncomingDropdownOpen = true;
    if (this.searchedIncomings.length === 0) { await this.searchIncomings(); }
  }

  async searchIncomings(): Promise<void> {
    this.isSearchingIncomings = true;
    this.cd.markForCheck();
    const warehouseId = this.warehouseService.selectedWarehouseId();

    try {
      const response = await this.api.invoke(getUnreceivedIncomings, {
        search: this.incomingSearchQuery.trim(),
        warehouseId: warehouseId ?? undefined,
        pageSize: 15
      }) as IncomingResponseDtoPaginatedResponse;

      this.searchedIncomings = response.items ?? [];
    } catch (err) {
      console.error('Failed to search incomings:', err);
      this.searchedIncomings = [];
    } finally {
      this.isSearchingIncomings = false;
      this.cd.markForCheck();
    }
  }

  selectIncoming(incoming: IncomingResponseDto): void {
    this.selectedIncoming = incoming;
    this.incomingSearchQuery = `#${incoming.id} — ${incoming.shipper}`;
    this.isIncomingDropdownOpen = false;

    this.newReceiving.shipper = incoming.shipper || '';
    this.newReceiving.consignee = incoming.consignee || '';
    if (incoming.warehouseId) {
      this.newReceiving.warehouseId = incoming.warehouseId;
    }

    // Populate available unreceived products for inline combobox (Default to zero selected)
    this.availableIncomingProducts = (incoming.products || [])
      .filter(p => !p.received)
      .map(p => ({
        productId: p.productId!,
        productName: p.productName || '',
        quantity: p.quantity || 0,
        cbm: p.cbm || '0',
        totalWeight: p.totalWeight || '0',
        expirationDate: p.expirationDate || new Date().toISOString().split('T')[0],
        supplier: p.supplier || '',
        remarks: p.remarks || '',
        received: p.received || false,
        selected: false
      }));

    this.syncStagedItemsFromSelection();
  }

  // --- INLINE PRODUCT COMBOBOX HANDLERS ---
  toggleProductDropdown(event?: Event): void {
    if (event) event.stopPropagation();
    this.isProductDropdownOpen = !this.isProductDropdownOpen;
  }

  toggleProductSelection(product: SelectableIncomingProduct): void {
    product.selected = !product.selected;
    this.syncStagedItemsFromSelection();
  }

  toggleSelectAllProducts(event: Event): void {
    const isChecked = (event.target as HTMLInputElement).checked;
    this.availableIncomingProducts.forEach(p => p.selected = isChecked);
    this.syncStagedItemsFromSelection();
  }

  get isAllProductsSelected(): boolean {
    return this.availableIncomingProducts.length > 0 && this.availableIncomingProducts.every(p => p.selected);
  }

  get filteredAvailableProducts(): SelectableIncomingProduct[] {
    if (!this.productFilterQuery.trim()) return this.availableIncomingProducts;
    const query = this.productFilterQuery.toLowerCase().trim();
    return this.availableIncomingProducts.filter(p => 
      p.productName?.toLowerCase().includes(query) ||
      p.supplier?.toLowerCase().includes(query)
    );
  }

  syncStagedItemsFromSelection(): void {
    const selectedProducts = this.availableIncomingProducts.filter(p => p.selected);

    const updatedStagedItems: StagedProductItem[] = [];

    for (const p of selectedProducts) {
      const existing = this.stagedItems.find(s => s.productId === p.productId);
      if (existing) {
        updatedStagedItems.push(existing);
      } else {
        const prodName = p.productName || '';
        const qty = p.quantity || 0;
        const cbmVal = p.cbm || '0';
        const weightVal = p.totalWeight || '0';
        const expiryVal = p.expirationDate || new Date().toISOString().split('T')[0];

        updatedStagedItems.push({
          productId: p.productId,
          expectedProductName: prodName,
          expectedQuantity: qty,
          expectedCbm: cbmVal,
          expectedTotalWeight: weightVal,
          expectedExpirationDate: expiryVal,

          productName: prodName,
          quantity: qty,
          cbm: cbmVal,
          totalWeight: weightVal,
          expirationDate: expiryVal,

          supplier: p.supplier || '',
          remarks: p.remarks || '',
          palletId: null,
          containerName: '',

          isMatched: true,
          discrepancies: []
        });
      }
    }

    this.stagedItems = updatedStagedItems;
    this.newReceiving.products = this.stagedItems;
    this.cd.markForCheck();
  }

  clearIncomingSelection(): void {
    this.selectedIncoming = null;
    this.incomingSearchQuery = '';
    this.searchedIncomings = [];
    this.availableIncomingProducts = [];
    this.isIncomingDropdownOpen = false;
    this.isProductDropdownOpen = false;
    this.productFilterQuery = '';
    this.stagedItems = [];
    this.newReceiving.products = [];
    this.cd.markForCheck();
  }

  toggleItemMatch(item: StagedProductItem): void {
    item.isMatched = !item.isMatched;

    if (item.isMatched) {
      item.quantity = item.expectedQuantity;
      item.cbm = item.expectedCbm;
      item.totalWeight = item.expectedTotalWeight;
      item.expirationDate = item.expectedExpirationDate;
      item.productName = item.expectedProductName;
      item.discrepancies = [];
    } else {
      this.autoDetectDiscrepancies(item);
    }
    this.cd.markForCheck();
  }

  onFieldChange(item: StagedProductItem): void {
    if (!item.isMatched) {
      this.autoDetectDiscrepancies(item);
    }
    this.cd.markForCheck();
  }

  autoDetectDiscrepancies(item: StagedProductItem): void {
    const manualFlags = item.discrepancies.filter(cat => cat === 'DAMAGED' || cat === 'OTHER');
    const detected: DiscrepancyCategory[] = [...manualFlags];

    if ((item.quantity ?? 0) !== (item.expectedQuantity ?? 0)) {
      if (!detected.includes('QUANTITY')) detected.push('QUANTITY');
    }

    if (item.productName?.trim().toLowerCase() !== item.expectedProductName?.trim().toLowerCase()) {
      if (!detected.includes('DESCRIPTION')) detected.push('DESCRIPTION');
    }

    if (item.cbm?.trim() !== item.expectedCbm?.trim()) {
      if (!detected.includes('CBM')) detected.push('CBM');
    }

    if (item.totalWeight?.trim() !== item.expectedTotalWeight?.trim()) {
      if (!detected.includes('WEIGHT')) detected.push('WEIGHT');
    }

    if (item.expirationDate !== item.expectedExpirationDate) {
      if (!detected.includes('EXPIRY')) detected.push('EXPIRY');
    }

    if (detected.length === 0) {
      detected.push('OTHER');
    }

    item.discrepancies = detected;
  }

  toggleDiscrepancyCategory(item: StagedProductItem, category: DiscrepancyCategory): void {
    const idx = item.discrepancies.indexOf(category);
    if (idx > -1) {
      item.discrepancies.splice(idx, 1);
    } else {
      item.discrepancies.push(category);
    }

    if (item.discrepancies.length > 0) {
      item.isMatched = false;
    }
    this.cd.markForCheck();
  }

  hasDiscrepancyCategory(item: StagedProductItem, category: DiscrepancyCategory): boolean {
    return item.discrepancies.includes(category);
  }

  getVariance(item?: { quantity?: number | null; expectedQuantity?: number | null }): number {
    if (!item || item.expectedQuantity === null || item.expectedQuantity === undefined) {
      return 0;
    }
    return (item.quantity ?? 0) - item.expectedQuantity;
  }

  getDiscrepancySummary(): DiscrepancySummary {
    const summary: DiscrepancySummary = {
      matchedCount: 0,
      flaggedCount: 0,
      totalItems: this.stagedItems.length,
      totalQuantityShortage: 0,
      totalQuantityExcess: 0,
      categoryCounts: {
        QUANTITY: 0,
        DESCRIPTION: 0,
        EXPIRY: 0,
        WEIGHT: 0,
        CBM: 0,
        DAMAGED: 0,
        OTHER: 0
      }
    };

    for (const item of this.stagedItems) {
      if (item.isMatched) {
        summary.matchedCount++;
      } else {
        summary.flaggedCount++;

        const variance = this.getVariance(item);
        if (variance < 0) {
          summary.totalQuantityShortage += Math.abs(variance);
        } else if (variance > 0) {
          summary.totalQuantityExcess += variance;
        }

        for (const cat of item.discrepancies) {
          summary.categoryCounts[cat] = (summary.categoryCounts[cat] || 0) + 1;
        }
      }
    }

    return summary;
  }

  // --- PALLET MODAL ---
  openPalletModal(rowIndex: number): void {
    this.activeRowIndexForPallet = rowIndex;
    this.isPalletModalOpen = true;
    this.palletQrCodeInput = '';
    this.scannedPallet = null;
    this.palletError = '';
    this.cd.markForCheck();
  }

  closePalletModal(): void {
    this.isPalletModalOpen = false;
    this.activeRowIndexForPallet = null;
    this.scannedPallet = null;
    this.palletQrCodeInput = '';
    this.palletError = '';
    this.cd.markForCheck();
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
      } else {
        this.palletError = pallet?.message || 'Pallet not found for scanned QR code.';
      }
    } catch (err) {
      console.error('Pallet lookup failed:', err);
      this.palletError = 'Unable to locate pallet. Check QR code and Warehouse context.';
    } finally {
      this.isLocatingPallet = false;
      this.cd.markForCheck();
    }
  }

  applyPalletToRow(): void {
    if (this.activeRowIndexForPallet === null || !this.scannedPallet?.palletId) return;

    this.stagedItems[this.activeRowIndexForPallet].palletId = this.scannedPallet.palletId;
    this.newReceiving.products = this.stagedItems;
    this.toastService.success(`Pallet #${this.scannedPallet.palletNumber || this.scannedPallet.palletId} assigned to line item.`);
    this.closePalletModal();
  }

  removeProductItem(index: number): void {
    const removedItem = this.stagedItems[index];
    this.stagedItems.splice(index, 1);

    if (removedItem) {
      const target = this.availableIncomingProducts.find(p => p.productId === removedItem.productId);
      if (target) target.selected = false;
    }

    this.newReceiving.products = this.stagedItems;
    this.cd.markForCheck();
  }

  // --- SAVE & VALIDATION ---
  private validateForm(): string | null {
    const warehouseId = this.warehouseService.selectedWarehouseId();
    if (!warehouseId) return 'Warehouse context is required.';
    if (!this.selectedIncoming) return 'An Incoming Shipment record must be selected.';
    if (!this.newReceiving.series?.trim()) return 'Series Number is required.';
    if (!this.newReceiving.transportCompany?.trim()) return 'Transport Company is required.';
    if (!this.newReceiving.shipper?.trim()) return 'Shipper is required.';
    if (!this.newReceiving.reference?.trim()) return 'Reference No. is required.';
    if (!this.newReceiving.plateNumber?.trim()) return 'Plate Number is required.';
    if (!this.newReceiving.driverName?.trim()) return 'Driver Name is required.';
    if (!this.stagedItems || this.stagedItems.length === 0) return 'At least one received product item must be staged.';

    for (let i = 0; i < this.stagedItems.length; i++) {
      const item = this.stagedItems[i];
      if (!item.isMatched && item.discrepancies.length === 0 && !item.remarks?.trim()) {
        return `Line Item #${i + 1} (${item.productName}) is marked as having discrepancies, but no category or remark was provided.`;
      }
    }

    return null;
  }

  private toIsoDateTime(dateStr?: string, timeStr?: string): string {
    const baseDate = dateStr || new Date().toISOString().split('T')[0];
    if (!timeStr) return new Date(baseDate).toISOString();
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

    const processedProducts: ReceivedProductDetailsDto[] = this.stagedItems.map(item => {
      let remarksText = item.remarks || '';
      if (!item.isMatched && item.discrepancies.length > 0) {
        const tagString = `[DISCREPANCIES: ${item.discrepancies.join(', ')}]`;
        remarksText = remarksText ? `${tagString} ${remarksText}` : tagString;
      }

      return {
        id: item.id || 0,
        productId: item.productId!,

        expectedProductName: item.expectedProductName,
        expectedQuantity: item.expectedQuantity,
        expectedCbm: item.expectedCbm,
        expectedTotalWeight: item.expectedTotalWeight,
        expectedExpirationDate: item.expectedExpirationDate as any,

        productName: item.productName,
        quantity: item.quantity ?? 0,
        cbm: item.cbm || '0',
        totalWeight: item.totalWeight || '0',
        expirationDate: item.expirationDate as any,

        supplier: item.supplier,
        remarks: remarksText,
        containerName: item.containerName || '',
        palletId: item.palletId
      };
    });

    const payload: CreateReceivingDto = {
      ...this.newReceiving,
      warehouseId: this.warehouseService.selectedWarehouseId()!,
      incomingId: this.selectedIncoming?.id! ?? null,
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
      products: processedProducts
    };

    try {
      await this.api.invoke(createReceiving, { body: payload });
      this.toastService.success(`Receiving ${payload.series} successfully submitted`);
      this.created.emit();
      this.onClose();
    } catch (err) {
      console.error('Failed to create receiving:', err);
      this.toastService.error(`Failed to create receiving: ${err}`);
      this.validationError = 'Failed to save receiving receipt. Please check server connection.';
    } finally {
      this.isSaving = false;
      this.cd.markForCheck();
    }
  }

  onClose(): void {
    this.newReceiving = this.getInitialForm();
    this.stagedItems = [];
    this.clearIncomingSelection();
    this.closePalletModal();
    this.validationError = '';
    this.close.emit();
  }
}