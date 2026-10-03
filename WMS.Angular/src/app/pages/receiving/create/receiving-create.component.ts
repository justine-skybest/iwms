import { Component, EventEmitter, OnInit, OnDestroy, Input, Output, inject, ChangeDetectorRef, HostListener, ElementRef, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../../api/generated/api';
import { WarehouseService } from '../../../lib/services/warehouse.service';
import { 
  CreateReceivingDto, 
  IncomingResponseDto, 
  IncomingResponseDtoPaginatedResponse, 
  PalletLocationDto, 
  ReceivedProductDetailsDto, 
  ReceivingDetailsDto
} from '../../../api/generated/models';
import { createReceiving, getReceiving, getUnreceivedIncomings, locatePalletByQrCode } from '../../../api/generated/functions';
import { QrScannerComponent } from '../../../shared/components/qr-scanner/qr-scanner.component';
import { LucideAngularModule, Trash2, Search, ChevronDown, X, Loader2, Check, QrCode, Box, Plus, AlertTriangle, ShieldCheck, FileSpreadsheet, PackageCheck, Printer } from 'lucide-angular';
import { ToastService } from '../../../lib/services/toast.service';
import { formatDate } from '../../../lib/utils/format-date';
import { generateQrCodeDataUrl } from '../../../lib/utils/qr-code.util';
import { Subject } from 'rxjs';
import { debounceTime, takeUntil } from 'rxjs/operators';
import { ConfirmDialogComponent } from '../../../shared/components/dialog/confirm-dialog.component';

// Interface defining the exact state to preserve
export interface ReceivingFormDraft {
  newReceiving: CreateReceivingDto;
  stagedItems: StagedProductItem[];
  selectedIncoming: IncomingResponseDto | null;
  availableIncomingProducts: SelectableIncomingProduct[];
  incomingSearchQuery: string;
  savedAt: string;
}

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
  id?: number;
  productId: number;
  productName?: string;
  quantity?: number;
  remainingQuantity?: number;
  cbm?: string;
  totalWeight?: string;
  expirationDate?: string;
  supplier?: string;
  unitPrice?: number;
  totalAmount?: number;
  remarks?: string;
  typeOfPackage?: string;
  status?: string;
  selected: boolean;
}

export type StagedProductItem = {
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
  cbm?: string;
  containerName?: string;
  expirationDate?: string;
  id?: number;
  incomingProductId?: number;
  lotNumber?: string;
  name?: string;
  palletId?: number;
  productId?: number;
  quantity?: number;
  remarks?: string;
  supplier?: string;
  totalAmount?: number;
  totalWeight?: string;
  unitPrice?: number;
};

export interface DiscrepancySummary {
  matchedCount: number;
  flaggedCount: number;
  totalItems: number;
  totalQuantityShortage: number;
  totalQuantityExcess: number;
  categoryCounts: Record<DiscrepancyCategory, number>;
}

export interface PalletLabelPrintData {
  palletId: number;
  palletNumber: string;
  palletHashCode: number;
  productName: string;
  code: string;
  quantity: number;
  weight: string;
  uom: string;
  lotNumber: string;
  expirationDate: string;
  dateReceived: string;
  qrUrl: string;
}

@Component({
  selector: 'app-receiving-create',
  standalone: true,
  imports: [CommonModule, FormsModule, LucideAngularModule, QrScannerComponent, ConfirmDialogComponent],
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
  readonly PrinterIcon = Printer;

  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);
  public warehouseService = inject(WarehouseService);
  private toastService = inject(ToastService);

  public formatDate = formatDate;

  @Input() isOpen = false;
  @Output() close = new EventEmitter<void>();
  @Output() created = new EventEmitter<void>();
  @ViewChild('thermalPrintContainer') thermalPrintContainer!: ElementRef<HTMLDivElement>;

  isSaving = false;
  validationError = '';

  isConfirmCloseOpen = false;

  private readonly DRAFT_STORAGE_KEY = 'warehouse_receiving_draft_v1';
  private draftSave$ = new Subject<void>();
  private destroy$ = new Subject<void>();
  
  hasRestoredDraft = false;

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
  series = '';

  isPrintModalOpen = false;
  generatedPalletLabels: PalletLabelPrintData[] = [];

  private incomingSearchDebounce: any;

  ngOnInit(): void {
    // 1. Setup debounced auto-save (400ms prevents UI lag during fast typing or barcode scanning)
    console.log('Setting up draft auto-save with debounce...');
    this.draftSave$
      .pipe(
        debounceTime(400),
        takeUntil(this.destroy$)
      )
      .subscribe(() => {
        this.saveDraftToStorage();
      });

    // 2. Restore any saved draft on load
    this.restoreDraftFromStorage();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  /**
   * Call this whenever form fields, staged items, or selections change
   */
  triggerDraftSave(): void {
    this.draftSave$.next();
  }

  private saveDraftToStorage(): void {
    // Only save if there is actual progress (staged items or modified header fields)
    if (!this.selectedIncoming && this.stagedItems.length === 0 && !this.newReceiving.reference) {
      return;
    }

    const draft: ReceivingFormDraft = {
      newReceiving: this.newReceiving,
      stagedItems: this.stagedItems,
      selectedIncoming: this.selectedIncoming,
      availableIncomingProducts: this.availableIncomingProducts,
      incomingSearchQuery: this.incomingSearchQuery,
      savedAt: new Date().toISOString()
    };

    try {
      localStorage.setItem(this.DRAFT_STORAGE_KEY, JSON.stringify(draft));
    } catch (err) {
      console.error('Failed to save receiving draft to localStorage:', err);
    }
  }

  private restoreDraftFromStorage(): void {
    const rawData = localStorage.getItem(this.DRAFT_STORAGE_KEY);
    if (!rawData) return;

    try {
      const draft: ReceivingFormDraft = JSON.parse(rawData);
      
      if (draft) {
        this.newReceiving = draft.newReceiving || this.getInitialForm();
        this.stagedItems = draft.stagedItems || [];
        this.selectedIncoming = draft.selectedIncoming || null;
        this.availableIncomingProducts = draft.availableIncomingProducts || [];
        this.incomingSearchQuery = draft.incomingSearchQuery || '';
        this.hasRestoredDraft = true;

        this.toastService.info('Restored unsaved receiving draft.');
        this.cd.markForCheck();
      }
    } catch (err) {
      console.error('Failed to parse receiving draft from storage:', err);
      this.clearDraft();
    }
  }

  public clearDraft(): void {
    localStorage.removeItem(this.DRAFT_STORAGE_KEY);
    this.hasRestoredDraft = false;
  }

  @HostListener('document:click')
  onDocumentClick(): void {
    this.isIncomingDropdownOpen = false;
    this.isProductDropdownOpen = false;
  }

  private generateSeries(externalId: number): string {
    const currentYearSuffix = new Date().getFullYear().toString().slice(-2);
    const formattedId = String(externalId).padStart(5, '0');
    return `SLCWH-INC${formattedId}-${currentYearSuffix}`;
  }

  private getInitialForm(): CreateReceivingDto {
    const now = new Date();
    const today = now.toISOString().split('T')[0];
    const currentTime = now.toTimeString().split(' ')[0].substring(0, 5);

    return {
      series: this.series,
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
  this.newReceiving.series = this.generateSeries(incoming.id!);

  this.newReceiving.shipper = incoming.shipper || '';
  this.newReceiving.consignee = incoming.consignee || '';
  if (incoming.warehouseId) {
    this.newReceiving.warehouseId = incoming.warehouseId;
  }

  this.availableIncomingProducts = (incoming.products || [])
    .filter(p => p.status !== 'RECEIVED')
    .map(p => {
      const remaining = p.remainingQuantity ?? ((p.quantity || 0) - (p.receivedQuantity || 0));
      const activeBalance = remaining > 0 ? remaining : (p.quantity || 0);

      return {
        id: p.id, // ✅ Capture the unique IncomingProduct.Id
        productId: p.productId!,
        productName: p.productName || '',
        quantity: activeBalance,
        remainingQuantity: activeBalance,
        cbm: p.cbm || '0',
        totalWeight: p.totalWeight || '0',
        expirationDate: p.expirationDate || new Date().toISOString().split('T')[0],
        supplier: p.supplier || '',
        unitPrice: p.unitPrice ?? undefined,
        totalAmount: p.totalAmount ?? undefined,
        remarks: p.remarks || '',
        typeOfPackage: p.typeOfPackage || 'CS GLASS',
        status: p.status,
        selected: false
      };
    });

  this.syncStagedItemsFromSelection();
  this.triggerDraftSave();
}

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
    // Match by incomingProductId or productId
    const existing = this.stagedItems.find(s => 
      (p.id && s.incomingProductId === p.id) || s.productId === p.productId
    );

    if (existing) {
      updatedStagedItems.push(existing);
    } else {
      const prodName = p.productName || '';
      const qty = p.quantity || 0;
      const cbmVal = p.cbm || '0';
      const weightVal = p.totalWeight || '0';
      const expiryVal = p.expirationDate || new Date().toISOString().split('T')[0];

      updatedStagedItems.push({
        incomingProductId: p.id, // ✅ Store source IncomingProduct ID
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

        supplier: p.supplier || undefined,
        unitPrice: p.unitPrice ?? undefined,
        totalAmount: p.totalAmount ?? undefined,

        typeOfPackage: p.typeOfPackage || 'CS GLASS',
        remarks: p.remarks || '',
        palletId: undefined,
        containerName: '',

        isMatched: true,
        discrepancies: []
      });
    }
  }

  this.stagedItems = updatedStagedItems;
  this.cd.markForCheck();
  this.triggerDraftSave();
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
    this.cd.markForCheck();
    this.triggerDraftSave();
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
    this.triggerDraftSave();
  }

  onFieldChange(item: StagedProductItem): void {
    if (!item.isMatched) {
      this.autoDetectDiscrepancies(item);
    }
    this.triggerDraftSave();
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
    this.toastService.success(`Pallet #${this.scannedPallet.palletNumber || this.scannedPallet.palletId} assigned to line item.`);
    this.closePalletModal();
    this.triggerDraftSave();
  }

  removeProductItem(index: number): void {
    const removedItem = this.stagedItems[index];
    this.stagedItems.splice(index, 1);

    if (removedItem) {
      const target = this.availableIncomingProducts.find(p => p.productId === removedItem.productId);
      if (target) target.selected = false;
    }

    this.triggerDraftSave();

    this.cd.markForCheck();
  }

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
      if (!item.palletId) {
        return `Each item should be assigned to a specific pallet.`;
      }
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
      incomingProductId: item.incomingProductId ?? undefined,

      expectedProductName: item.expectedProductName,
      expectedQuantity: item.expectedQuantity,
      expectedCbm: item.expectedCbm,
      expectedTotalWeight: item.expectedTotalWeight,
      expectedExpirationDate: item.expectedExpirationDate as any,
      typeOfPackage: item.typeOfPackage,

      productName: item.productName,
      quantity: item.quantity ?? 0,
      cbm: item.cbm || '0',
      totalWeight: item.totalWeight || '0',
      expirationDate: item.expirationDate as any,
      
      supplier: item.supplier || undefined,
      unitPrice: item.unitPrice ?? undefined,
      totalAmount: item.totalAmount ?? undefined,

      remarks: remarksText,
      containerName: item.containerName || '',
      palletId: item.palletId ?? undefined
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
    const createdReceiving = await this.api.invoke(createReceiving, { body: payload }) as any;
    this.toastService.success(`Receiving ${payload.series} successfully submitted`);
    
    // 1. Purge draft from storage
    this.clearDraft();

    // 2. Notify parent component to refresh records
    this.created.emit();

    const createdId = createdReceiving?.id;
    const hasPalletizedItems = this.stagedItems.some(p => !!p.palletId);

    // 3. Prepare print labels if pallets exist; otherwise reset & close form without prompt
    if (createdId && hasPalletizedItems) {
      await this.preparePalletLabelsForPrinting(createdId);
    } else {
      this.forceCloseAndReset();
    }
  } catch (err) {
    console.error('Failed to create receiving:', err);
    this.toastService.error(`Failed to create receiving: ${err}`);
    this.validationError = 'Failed to save receiving receipt. Please check server connection.';
  } finally {
    this.isSaving = false;
    this.cd.markForCheck();
  }
}
  discardDraft(): void {
    this.clearDraft();
    this.newReceiving = this.getInitialForm();
    this.stagedItems = [];
    this.clearIncomingSelection();
    this.toastService.info('Draft discarded.');
  }

  private async preparePalletLabelsForPrinting(receivingId: number): Promise<void> {
    try {
      const receiving = await this.api.invoke(getReceiving, { id: receivingId }) as ReceivingDetailsDto;
      const items = (receiving?.products || []).filter(p => !!p.palletId);

      if (items.length === 0) {
        this.onClose();
        return;
      }

      const groupedByPallet = new Map<number, ReceivedProductDetailsDto[]>();
      for (const item of items) {
        if (!item.palletId) continue;
        if (!groupedByPallet.has(item.palletId)) {
          groupedByPallet.set(item.palletId, []);
        }
        groupedByPallet.get(item.palletId)!.push(item);
      }

      const labels: PalletLabelPrintData[] = [];
      const dateReceivedStr = this.formatDate(receiving.dateReceived || this.newReceiving.dateReceived);

      for (const [palletId, groupItems] of groupedByPallet.entries()) {
        const totalQty = groupItems.reduce((acc, curr) => acc + (curr.quantity || 0), 0);
        
        const totalWeightVal = groupItems.reduce((acc, curr) => {
          const parsed = parseFloat(curr.totalWeight || '0');
          return acc + (isNaN(parsed) ? 0 : parsed);
        }, 0);

        const firstItem = groupItems[0];
        const primaryName = firstItem.name || firstItem.expectedProductName || '—';
        const prodName = groupItems.length === 1 
          ? primaryName 
          : `${primaryName} (+${groupItems.length - 1} items)`;

        const codeVal = groupItems.length === 1 
          ? (firstItem.productId ? `#${firstItem.productId}` : '—') 
          : 'MULTI-SKU';

        const lotVal = Array.from(
          new Set(
            groupItems
              .map(i => i.lotNumber?.trim())
              .filter((lot): lot is string => !!lot && lot !== '')
          )
        ).join(', ') || '—';

        const uomList = Array.from(
          new Set(
            groupItems
              .map(i => i.typeOfPackage?.trim())
              .filter((uom): uom is string => !!uom && uom !== '')
          )
        );
        const uomVal = uomList.slice(0, 3).join(', ') || 'CS GLASS';

        const hashCode = 100000 + palletId;
        const qrDataUrl = await generateQrCodeDataUrl(hashCode, 180);

        const formattedWeight = totalWeightVal > 0 
          ? totalWeightVal.toFixed(2) 
          : (parseFloat(firstItem.totalWeight || '0') || 0).toFixed(2);

        labels.push({
          palletId: palletId,
          palletNumber: `PAL-${palletId}`,
          palletHashCode: hashCode,
          productName: prodName,
          code: codeVal,
          quantity: totalQty,
          weight: formattedWeight,
          uom: uomVal,
          lotNumber: lotVal,
          expirationDate: this.formatDate(firstItem.expirationDate as string),
          dateReceived: dateReceivedStr,
          qrUrl: qrDataUrl
        });
      }

      this.generatedPalletLabels = labels;
      this.isPrintModalOpen = true;
    } catch (err) {
      console.error('Failed to fetch saved receiving details for label printing:', err);
      this.toastService.error('Receipt saved, but failed to fetch server lot numbers for label printing.');
      this.onClose();
    }
  }

  triggerPrint(): void {
    if (!this.thermalPrintContainer?.nativeElement) {
      console.error('Thermal print container not found.');
      return;
    }

    this.cd.detectChanges();
    const printContents = this.thermalPrintContainer.nativeElement.innerHTML;

    const iframe = document.createElement('iframe');
    iframe.style.position = 'fixed';
    iframe.style.right = '0';
    iframe.style.bottom = '0';
    iframe.style.width = '0';
    iframe.style.height = '0';
    iframe.style.border = '0';
    document.body.appendChild(iframe);

    const doc = iframe.contentWindow?.document;
    if (!doc) return;

    doc.open();
    doc.write(`
      <!DOCTYPE html>
      <html>
        <head>
          <title>Pallet QR Thermal Print</title>
          <style>
            @page {
              size: 4in 6in;
              margin: 0 !important;
            }
            html, body {
              width: 4in;
              height: 6in;
              margin: 0 !important;
              padding: 0 !important;
              background: #ffffff !important;
              font-family: Arial, sans-serif !important;
              color: #000000 !important;
            }
            .thermal-label-page {
              width: 4in !important;
              height: 6in !important;
              padding: 0.25in !important;
              margin: 0 !important;
              page-break-after: always !important;
              break-after: page !important;
              page-break-inside: avoid !important;
              break-inside: avoid !important;
              display: flex !important;
              flex-direction: column !important;
              justify-content: space-between !important;
              box-sizing: border-box !important;
              background: #ffffff !important;
              color: #000000 !important;
              font-family: Arial, sans-serif !important;
              overflow: hidden !important;
            }
          </style>
        </head>
        <body>
          ${printContents}
        </body>
      </html>
    `);
    doc.close();

    setTimeout(() => {
      iframe.contentWindow?.focus();
      iframe.contentWindow?.print();
      setTimeout(() => {
        document.body.removeChild(iframe);
      }, 500);
    }, 200);
  }

  closePrintModal(): void {
    this.isPrintModalOpen = false;
    this.generatedPalletLabels = [];
    this.forceCloseAndReset();
  }

  /**
 * Checks if the user has entered any data into the form.
 */
private hasUnsavedChanges(): boolean {
  if (this.selectedIncoming !== null) return true;
  if (this.stagedItems && this.stagedItems.length > 0) return true;

  const current = this.newReceiving;
  const initial = this.getInitialForm();

  return !!(
    (current.reference && current.reference.trim() !== '') ||
    (current.driverName && current.driverName.trim() !== '') ||
    (current.plateNumber && current.plateNumber.trim() !== '') ||
    (current.transportCompany && current.transportCompany.trim() !== '') ||
    (current.shipper && current.shipper.trim() !== '') ||
    (current.consignee && current.consignee.trim() !== '') ||
    (current.checkerName && current.checkerName.trim() !== '') ||
    (current.clientRepresentative && current.clientRepresentative.trim() !== '')
  );
}

/**
   * Called when the user clicks '✕', Backdrop, or 'Cancel'
   */
  onClose(): void {
    if (this.hasUnsavedChanges()) {
      this.isConfirmCloseOpen = true;
      this.cd.markForCheck();
    } else {
      this.forceCloseAndReset();
    }
  }

  /**
   * Triggered when the user confirms discarding changes in the dialog
   */
  onConfirmClose(): void {
    this.isConfirmCloseOpen = false;
    this.forceCloseAndReset();
  }

  /**
   * Triggered when the user decides to stay and keep editing
   */
  onCancelClose(): void {
    this.isConfirmCloseOpen = false;
    this.cd.markForCheck();
  }

  /**
   * Clears storage and resets form state completely
   */
  private forceCloseAndReset(): void {
    this.clearDraft();
    this.newReceiving = this.getInitialForm();
    this.stagedItems = [];
    this.clearIncomingSelection();
    this.closePalletModal();
    this.isPrintModalOpen = false;
    this.generatedPalletLabels = [];
    this.validationError = '';
    this.close.emit();
    this.cd.markForCheck();
  }
}