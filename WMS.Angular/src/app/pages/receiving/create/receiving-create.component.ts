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
import { LucideAngularModule, Trash2, Search, ChevronDown, X, Loader2, Check, QrCode, Box, Plus, AlertTriangle, ShieldCheck, FileSpreadsheet, PackageCheck, Printer, Layers } from 'lucide-angular';
import { ToastService } from '../../../lib/services/toast.service';
import { formatDate } from '../../../lib/utils/format-date';
import { generateQrCodeDataUrl } from '../../../lib/utils/qr-code.util';
import { Subject } from 'rxjs';
import { debounceTime, takeUntil } from 'rxjs/operators';
import { ConfirmDialogComponent } from '../../../shared/components/dialog/confirm-dialog.component';

export interface ReceivingFormDraft {
  newReceiving: CreateReceivingDto;
  stagedItems: StagedProductItem[];
  selectedIncoming: IncomingResponseDto | null;
  availableIncomingProducts: SelectableIncomingProduct[];
  incomingSearchQuery: string;
  savedAt: string;
}

export interface SelectableIncomingProduct {
  id?: number;
  productId: number;
  productName?: string;
  originalQuantity?: number;
  quantity?: number;
  remainingQuantity?: number;
  cbm?: number;
  totalCBm?: number;
  weight?: number;
  totalWeight?: number;
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

  expectedProductName?: string;
  expectedQuantity?: number;
  expectedCbm?: number;
  expectedTotalWeight?: number;
  expectedExpirationDate?: string;
  
  cbm?: number;
  containerName?: string;
  expirationDate?: string;
  id?: number;
  incomingProductId?: number;
  lotNumber?: string;
  name?: string;
  palletId?: number;
  productId?: number;
  quantity?: number;
  weight?: number;
  remarks?: string;
  supplier?: string;
  totalAmount?: number;

  unitPrice?: number;
};

export interface PalletGroupSummary {
  palletId: number;
  items: StagedProductItem[];
  totalQuantity: number;
  calculatedCbm: number;
  calculatedWeight: number;
}

export interface PalletLabelPrintData {
  palletId: number;
  palletNumber: string;
  palletHashCode: number;
  productName: string;
  code: string;
  quantity: number;
  weight: string;
  cbm: string;
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
export class ReceivingCreateComponent implements OnInit, OnDestroy {
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
  readonly LayersIcon = Layers;

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
  private fieldDebounce$ = new Subject<void>();
  private destroy$ = new Subject<void>();
  
  hasRestoredDraft = false;

  newReceiving: CreateReceivingDto = this.getInitialForm();
  stagedItems: StagedProductItem[] = [];

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

  // State to hold pallet-level overrides independently without modifying line item values
  palletOverrides = new Map<number, { manualCbm?: number; manualWeight?: number }>();
  palletCbmDrafts: Record<number, string> = {};
  palletWeightDrafts: Record<number, string> = {};

  ngOnInit(): void {
    this.draftSave$
      .pipe(
        debounceTime(400),
        takeUntil(this.destroy$)
      )
      .subscribe(() => {
        this.saveDraftToStorage();
      });

    this.fieldDebounce$
      .pipe(
        debounceTime(500),
        takeUntil(this.destroy$)
      )
      .subscribe(() => {
        this.recalculateItemProRataAndGroups();
      });

    this.restoreDraftFromStorage();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  triggerDraftSave(): void {
    this.draftSave$.next();
  }

  private saveDraftToStorage(): void {
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
        this.stagedItems = (draft.stagedItems || []).map(item => ({
          ...item,
          weight: item.weight ?? this.getLegacyUnitWeight(item)
        }));
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
        const origQty = p.quantity || 1;
        const remainingQty = p.remainingQuantity ?? (origQty - (p.receivedQuantity || 0));
        const activeQty = remainingQty > 0 ? remainingQty : origQty;

        const totalCbm = p.totalCbm ?? 0;
        const weight = p.weight ?? (p.totalWeight ?? 0) / origQty;

        // Pro-rate CBM & Total Weight based on remaining unreceived balance
        const remainingCbm = Number(((totalCbm / origQty) * activeQty).toFixed(4));
        return {
          id: p.id,
          productId: p.productId!,
          productName: p.productName || '',
          originalQuantity: origQty,
          quantity: activeQty,
          remainingQuantity: activeQty,
          cbm: remainingCbm > 0 ? remainingCbm : 0,
          totalCBm: totalCbm,
          weight,
          totalWeight: weight * activeQty,
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
      const existing = this.stagedItems.find(s => 
        (p.id && s.incomingProductId === p.id) || s.productId === p.productId
      );

      if (existing) {
        updatedStagedItems.push(existing);
      } else {
        const prodName = p.productName || '';
        const qty = p.quantity || 0;
        const cbmVal = p.cbm || 0;
        const weightVal = p.weight ?? this.getLegacyUnitWeight(p);
        const expiryVal = p.expirationDate || new Date().toISOString().split('T')[0];

        updatedStagedItems.push({
          incomingProductId: p.id,
          productId: p.productId,
          expectedProductName: prodName,
          expectedQuantity: qty,
          expectedCbm: cbmVal,
          expectedTotalWeight: p.totalWeight ?? this.getTotalWeight({ weight: weightVal, quantity: qty }),
          expectedExpirationDate: expiryVal,

          productName: prodName,
          quantity: qty,
          cbm: cbmVal,
          weight: weightVal,
          expirationDate: expiryVal,

          supplier: p.supplier || undefined,
          unitPrice: p.unitPrice ?? undefined,
          totalAmount: p.totalAmount ?? undefined,

          typeOfPackage: p.typeOfPackage || 'CS GLASS',
          remarks: p.remarks || '',
          palletId: undefined,
          containerName: ''
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

  onItemQuantityChange(item: StagedProductItem): void {
    this.fieldDebounce$.next();
  }

  getTotalWeight(item: { weight?: number; quantity?: number }): number {
    return Number(((item.weight ?? 0) * (item.quantity ?? 0)).toFixed(2));
  }

  private getLegacyUnitWeight(item: { weight?: number | null; totalWeight?: number | string; quantity?: number }): number {
    if (item.weight !== undefined && item.weight !== null && Number.isFinite(item.weight)) return item.weight;
    const totalWeight = Number(item.totalWeight ?? 0);
    const quantity = item.quantity ?? 0;
    return Number.isFinite(totalWeight) && quantity > 0 ? totalWeight / quantity : 0;
  }

  /**
   * Computed getter that dynamically groups staged items by Pallet ID
   */
  palletGroups: PalletGroupSummary[] = [];

  trackByPalletId(index: number, group: PalletGroupSummary): number {
    return group.palletId;
  }

  /**
   * Executes pro-rating math and updates pallet summaries after the 300ms typing debounce
   */
  private recalculateItemProRataAndGroups(): void {
    // 1. Recalculate line-item CBM & Weight pro-rata for changed quantities
    for (const item of this.stagedItems) {
      if (item.incomingProductId && this.availableIncomingProducts.length > 0) {
        const parent = this.availableIncomingProducts.find(p => p.id === item.incomingProductId);
        if (parent && parent.originalQuantity && parent.originalQuantity > 0) {
          const origCbm = parent.totalCBm ?? 0;
          const actQty = item.quantity ?? 0;

          const newCbm = (origCbm / parent.originalQuantity) * actQty;

          item.cbm = newCbm > 0 ? Number(newCbm.toFixed(4)) : 0;
          item.weight = this.getLegacyUnitWeight(parent);
        }
      }
    }

    // 2. Recompute Pallet Group Summaries
    this.updatePalletGroups();

    // 3. Trigger debounced draft auto-save
    this.triggerDraftSave();

    // 4. Mark change detection
    this.cd.markForCheck();
  }

/**
   * Recomputes pallet group objects explicitly
   */
  updatePalletGroups(): void {
    const groupsMap = new Map<number, StagedProductItem[]>();

    for (const item of this.stagedItems) {
      if (!item.palletId) continue;
      if (!groupsMap.has(item.palletId)) {
        groupsMap.set(item.palletId, []);
      }
      groupsMap.get(item.palletId)!.push(item);
    }

    const result: PalletGroupSummary[] = [];

    for (const [palletId, items] of groupsMap.entries()) {
      const totalQty = items.reduce((sum, i) => sum + (i.quantity || 0), 0);
      
      const calcCbm = items.reduce((sum, i) => {
        const val = i.cbm ?? 0;
        return sum + (isNaN(val) ? 0 : val);
      }, 0);

      const calcWeight = items.reduce((sum, i) => {
        return sum + this.getTotalWeight(i);
      }, 0);

      const override = this.palletOverrides.get(palletId);

      result.push({
        palletId,
        items,
        totalQuantity: totalQty,
        calculatedCbm: override?.manualCbm ?? parseFloat(calcCbm.toFixed(4)),
        calculatedWeight: override?.manualWeight ?? parseFloat(calcWeight.toFixed(2))
      });
    }

    this.palletGroups = result;
  }

  getPalletCbmInputValue(group: PalletGroupSummary): string {
    return this.palletCbmDrafts[group.palletId] ?? group.calculatedCbm.toFixed(4);
  }

  getPalletWeightInputValue(group: PalletGroupSummary): string {
    return this.palletWeightDrafts[group.palletId] ?? group.calculatedWeight.toFixed(2);
  }

  updatePalletCbmDraft(group: PalletGroupSummary, value: string): void {
    this.palletCbmDrafts[group.palletId] = value;
  }

  updatePalletWeightDraft(group: PalletGroupSummary, value: string): void {
    this.palletWeightDrafts[group.palletId] = value;
  }

  commitPalletCbmDraft(group: PalletGroupSummary): void {
    const draft = this.palletCbmDrafts[group.palletId]?.trim() ?? '';
    delete this.palletCbmDrafts[group.palletId];
    if (!draft) return;
    const value = Number(draft.replace(',', '.'));
    if (Number.isFinite(value) && value >= 0) this.applyPalletCbmOverride(group, value);
  }

  commitPalletWeightDraft(group: PalletGroupSummary): void {
    const draft = this.palletWeightDrafts[group.palletId]?.trim() ?? '';
    delete this.palletWeightDrafts[group.palletId];
    if (!draft) return;
    const value = Number(draft.replace(',', '.'));
    if (Number.isFinite(value) && value >= 0) this.applyPalletWeightOverride(group, value);
  }

/**
 * Called when the warehouse worker enters a Pallet CBM override
 */
applyPalletCbmOverride(group: PalletGroupSummary, newTotalCbm: number): void {
  if (!group || !Number.isFinite(newTotalCbm) || newTotalCbm < 0) return;
  const roundedCbm = Number(newTotalCbm.toFixed(4));
  this.palletOverrides.set(group.palletId, {
    ...this.palletOverrides.get(group.palletId),
    manualCbm: roundedCbm,
  });

  // Apply tail-end pro-rating directly to the staged items in this pallet group
  this.distributePalletScaleOverride(group.items, roundedCbm, undefined);

  this.updatePalletGroups();
  this.triggerDraftSave();
  this.cd.markForCheck();
}

/**
 * Called when the warehouse worker enters a Pallet Total Weight scale override
 */
applyPalletWeightOverride(group: PalletGroupSummary, newTotalWeight: number): void {
  if (!group || !Number.isFinite(newTotalWeight) || newTotalWeight < 0) return;
  const roundedWeight = Number(newTotalWeight.toFixed(2));
  this.palletOverrides.set(group.palletId, {
    ...this.palletOverrides.get(group.palletId),
    manualWeight: roundedWeight,
  });

  // Apply tail-end pro-rating directly to the staged items in this pallet group
  this.distributePalletScaleOverride(group.items, undefined, roundedWeight);

  this.updatePalletGroups();
  this.triggerDraftSave();
  this.cd.markForCheck();
}

/**
 * Baseline-Weighted Tail Allocation:
 * Pro-rates override target CBM & Weight based on each item's existing CBM/Weight ratio,
 * then assigns the remaining rounding delta to the last item.
 */
private distributePalletScaleOverride(
  items: StagedProductItem[],
  overrideCbm?: number,
  overrideWeight?: number
): void {
  if (items.length === 0) return;

  // 1. Distribute Target CBM based on Baseline CBM Ratios
  if (overrideCbm !== undefined && overrideCbm >= 0) {
    const totalBaselineCbm = items.reduce((sum, i) => sum + i.cbm!, 0);

    if (totalBaselineCbm >= 0) {
      let accumulatedCbm = 0;

      for (let i = 0; i < items.length; i++) {
        const item = items[i];
        const isLastItem = i === items.length - 1;

        if (isLastItem) {
          // Tail item gets exact remaining delta
          const exactCbm = Math.max(0, overrideCbm - accumulatedCbm);
          item.cbm = Number(exactCbm.toFixed(4));
        } else {
          const itemBaselineCbm = item.cbm ?? 0;
          const ratio = totalBaselineCbm > 0 ? itemBaselineCbm / totalBaselineCbm : 1 / items.length;

          const allocatedCbm = Number((overrideCbm * ratio).toFixed(4));
          item.cbm = allocatedCbm;
          accumulatedCbm += allocatedCbm;
        }
      }
    }
  }

  // 2. Distribute Target Weight based on Baseline Weight Ratios
  if (overrideWeight !== undefined && overrideWeight >= 0) {
    const totalBaselineWeight = items.reduce((sum, i) => sum + this.getTotalWeight(i), 0);

    if (totalBaselineWeight >= 0) {
      let accumulatedWeight = 0;

      for (let i = 0; i < items.length; i++) {
        const item = items[i];
        const isLastItem = i === items.length - 1;

        if (isLastItem) {
          // Tail item gets exact remaining delta
          const exactWeight = Math.max(0, overrideWeight - accumulatedWeight);
          item.weight = item.quantity ? exactWeight / item.quantity : 0;
        } else {
          const itemBaselineWeight = this.getTotalWeight(item);
          const ratio = totalBaselineWeight > 0 ? itemBaselineWeight / totalBaselineWeight : 1 / items.length;

          const allocatedWeight = parseFloat((overrideWeight * ratio).toFixed(2));
          item.weight = item.quantity ? allocatedWeight / item.quantity : 0;
          accumulatedWeight += allocatedWeight;
        }
      }
    }
  }
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
  
  // Update pallet group calculation explicitly
  this.updatePalletGroups();
  
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
        return `Line Item #${i + 1} (${item.productName}) must be assigned to a specific pallet.`;
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

    const processedProducts: ReceivedProductDetailsDto[] = this.stagedItems.map(item => ({
      id: item.id || 0,
      productId: item.productId!,
      incomingProductId: item.incomingProductId ?? undefined,

      expectedProductName: item.expectedProductName,
      expectedQuantity: item.expectedQuantity,
      expectedCBM: item.expectedCbm,
      expectedTotalWeight: item.expectedTotalWeight,
      expectedExpirationDate: item.expectedExpirationDate as any,
      typeOfPackage: item.typeOfPackage,

      name: item.productName,
      quantity: item.quantity ?? 0,
      cbm: item.cbm || 0,
      weight: item.weight ?? 0,
      expirationDate: item.expirationDate as any,
      lotNumber: item.lotNumber || undefined,
      
      supplier: item.supplier || undefined,
      unitPrice: item.unitPrice ?? undefined,
      totalAmount: item.totalAmount ?? undefined,

      remarks: item.remarks || '',
      containerName: item.containerName || '',
      palletId: item.palletId ?? undefined
    }));

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
      dateAdded: this.newReceiving.dateAdded || new Date().toISOString(),
      dateTime: new Date().toISOString(),
      timeStart: this.toIsoDateTime(this.newReceiving.dateReceived, this.newReceiving.timeStart),
      timeEnd: this.toIsoDateTime(this.newReceiving.dateReceived, this.newReceiving.timeEnd),
      products: processedProducts
    };

    try {
      const createdReceiving = await this.api.invoke(createReceiving, { body: payload }) as any;
      this.toastService.success(`Receiving ${payload.series} successfully submitted`);
      
      this.clearDraft();
      this.created.emit();

      const createdId = createdReceiving?.id;
      const hasPalletizedItems = this.stagedItems.some(p => !!p.palletId);

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
          return acc + this.getTotalWeight(curr);
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

        const hashCode = palletId;
        const qrDataUrl = await generateQrCodeDataUrl(`Pal-${palletId}`, 180);

        const formattedWeight = totalWeightVal > 0 
          ? totalWeightVal.toFixed(2) 
          : this.getTotalWeight(firstItem).toFixed(2);

        const formattedCbm = groupItems.reduce((acc, curr) => {
          const parsed = curr.cbm ?? 0;
          return acc + (isNaN(parsed) ? 0 : parsed);
        }, 0).toFixed(4);

        labels.push({
          palletId: palletId,
          palletNumber: `PAL-${palletId}`,
          palletHashCode: hashCode,
          productName: prodName,
          code: codeVal,
          quantity: totalQty,
          weight: formattedWeight,
          cbm: formattedCbm,
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

  private hasUnsavedChanges(): boolean {
    if (this.selectedIncoming !== null) return true;
    if (this.stagedItems && this.stagedItems.length > 0) return true;

    const current = this.newReceiving;

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

  onClose(): void {
    if (this.hasUnsavedChanges()) {
      this.isConfirmCloseOpen = true;
      this.cd.markForCheck();
    } else {
      this.forceCloseAndReset();
    }
  }

  onConfirmClose(): void {
    this.isConfirmCloseOpen = false;
    this.forceCloseAndReset();
  }

  onCancelClose(): void {
    this.isConfirmCloseOpen = false;
    this.cd.markForCheck();
  }

  private forceCloseAndReset(): void {
    this.clearDraft();
    this.palletOverrides.clear();
    this.palletGroups = [];
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