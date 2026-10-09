import { Component, EventEmitter, OnChanges, OnInit, OnDestroy, SimpleChanges, Input, Output, inject, ChangeDetectorRef, ElementRef, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Subject } from 'rxjs';
import { debounceTime, takeUntil } from 'rxjs/operators';
import { Api } from '../../../api/generated/api';
import { WarehouseService } from '../../../lib/services/warehouse.service';
import { 
  CreateReceivingDto, 
  IncomingResponseDto, 
  PalletLocationDto, 
  ReceivedProductDetailsDto, 
  ReceivingDetailsDto
} from '../../../api/generated/models';
import { updateReceiving, getReceiving, locatePalletByQrCode, getUnreceivedIncomingById, getIncomingById } from '../../../api/generated/functions';
import { QrScannerComponent } from '../../../shared/components/qr-scanner/qr-scanner.component';
import { LucideAngularModule, Trash2, Search, ChevronDown, X, Loader2, Check, QrCode, Box, Plus, AlertTriangle, ShieldCheck, FileSpreadsheet, PackageCheck, Printer, Layers } from 'lucide-angular';
import { ToastService } from '../../../lib/services/toast.service';
import { formatDate } from '../../../lib/utils/format-date';
import { generateQrCodeDataUrl } from '../../../lib/utils/qr-code.util';
import { ConfirmDialogComponent } from '../../../shared/components/dialog/confirm-dialog.component';

export type EditStagedProductItem = {
  id?: number;
  productId: number;
  incomingProductId?: number;

  productName?: string;
  expectedProductName?: string;

  quantity: number;

  expectedQuantity?: number;
  cbm?: number;
  expectedCbm?: number;
  weight?: number;
  expectedTotalWeight?: number;
  expirationDate?: string;
  expectedExpirationDate?: string;

  supplier?: string;
  unitPrice?: number;
  totalAmount?: number;
  typeOfPackage?: string;
  remarks?: string;
  palletId?: number;
  containerName?: string;
  lotNumber?: string;
};

export interface SelectableIncomingProduct {
  id?: number;
  productId: number;
  productName?: string;
  originalQuantity?: number;
  quantity?: number;
  remainingQuantity?: number;
  cbm?: number;
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
  isPreSelected?: boolean;
}

export interface PalletGroupSummary {
  palletId: number;
  items: EditStagedProductItem[];
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
  uom: string;
  lotNumber: string;
  expirationDate: string;
  dateReceived: string;
  qrUrl: string;
}

@Component({
  selector: 'app-edit-receiving',
  standalone: true,
  imports: [CommonModule, FormsModule, LucideAngularModule, QrScannerComponent, ConfirmDialogComponent],
  templateUrl: './edit-receiving.component.html',
})
export class EditReceivingComponent implements OnChanges, OnInit, OnDestroy {
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
  @Input() selectedReceiving: ReceivingDetailsDto | null = null;
  @Output() close = new EventEmitter<void>();
  @Output() updated = new EventEmitter<void>();

  @ViewChild('thermalPrintContainer') thermalPrintContainer!: ElementRef<HTMLDivElement>;

  isSaving = false;
  isLoadingDetails = false;
  validationError = '';
  isConfirmCloseOpen = false;

  newReceiving: CreateReceivingDto = this.getInitialForm();
  stagedItems: EditStagedProductItem[] = [];
  selectedIncoming: IncomingResponseDto | null = null;

  isProductDropdownOpen = false;
  productFilterQuery = '';
  availableIncomingProducts: SelectableIncomingProduct[] = [];

  palletGroups: PalletGroupSummary[] = [];
  palletCbmDrafts: Record<number, string> = {};
  palletWeightDrafts: Record<number, string> = {};

  isPalletModalOpen = false;
  activeRowIndexForPallet: number | null = null;
  palletQrCodeInput = '';
  scannedPallet: PalletLocationDto | null = null;
  isLocatingPallet = false;
  palletError = '';

  isPrintModalOpen = false;
  generatedPalletLabels: PalletLabelPrintData[] = [];

  private fieldDebounce$ = new Subject<void>();
  private destroy$ = new Subject<void>();

  ngOnInit(): void {
    this.fieldDebounce$
      .pipe(
        debounceTime(300),
        takeUntil(this.destroy$)
      )
      .subscribe(() => {
        this.updatePalletGroups();
        this.cd.markForCheck();
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['isOpen'] && this.isOpen && this.selectedReceiving) {
      void this.loadAndPopulateForm(this.selectedReceiving);
    } else if (changes['selectedReceiving'] && this.isOpen && this.selectedReceiving) {
      void this.loadAndPopulateForm(this.selectedReceiving);
    }
  }

  trackByPalletId(index: number, group: PalletGroupSummary): number {
    return group.palletId;
  }

  private formatDateForInput(dateStr?: string | null): string {
    if (!dateStr) return new Date().toISOString().split('T')[0];
    return dateStr.split('T')[0];
  }

  private formatTimeForInput(timeStr?: string | null): string {
    if (!timeStr) return '00:00';
    if (timeStr.includes('T')) {
      const timePart = timeStr.split('T')[1];
      return timePart.substring(0, 5);
    }
    return timeStr.substring(0, 5);
  }

  private getInitialForm(): CreateReceivingDto {
    const now = new Date();
    const today = now.toISOString().split('T')[0];
    const currentTime = now.toTimeString().split(' ')[0].substring(0, 5);

    return {
      series: '',
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

  private async loadAndPopulateForm(receiving: ReceivingDetailsDto): Promise<void> {
    this.isLoadingDetails = true;
    this.validationError = '';
    this.cd.markForCheck();

    try {
      const freshReceiving = receiving.id 
        ? (await this.api.invoke(getReceiving, { id: receiving.id }) as ReceivingDetailsDto) 
        : receiving;

      this.newReceiving = {
        series: freshReceiving.series ?? '',
        driverName: freshReceiving.driverName ?? '',
        incomingId: freshReceiving.incomingId ?? this.selectedReceiving?.incomingId!,
        plateNumber: freshReceiving.plateNumber ?? '',
        warehouseId: freshReceiving.warehouseId ?? this.warehouseService.selectedWarehouseId() ?? undefined,
        dateReceived: this.formatDateForInput(freshReceiving.dateReceived),
        dateAdded: freshReceiving.dateTime ?? new Date().toISOString(),
        dateTime: freshReceiving.dateTime ?? new Date().toISOString(),
        timeStart: this.formatTimeForInput(freshReceiving.timeStart),
        timeEnd: this.formatTimeForInput(freshReceiving.timeEnd),
        transportCompany: freshReceiving.transportCompany ?? '',
        shipper: freshReceiving.shipper ?? '',
        consignee: freshReceiving.consignee ?? '',
        reference: freshReceiving.reference ?? '',
        checkerName: freshReceiving.checkerName ?? '',
        clientRepresentative: freshReceiving.clientRepresentative ?? '',
        products: []
      };

      // Load linked Incoming shipment via getUnreceivedIncomingById
      if (freshReceiving.incomingId) {
        try {
          this.selectedIncoming = await this.api.invoke(getUnreceivedIncomingById, { id: freshReceiving.incomingId }) as IncomingResponseDto;
        } catch {
          this.selectedIncoming = await this.api.invoke(getIncomingById, { id: freshReceiving.incomingId }) as IncomingResponseDto;
        }
      } else {
        this.selectedIncoming = null;
      }

      // Build staged line items
      if (freshReceiving.products && freshReceiving.products.length > 0) {
        this.stagedItems = freshReceiving.products.map(p => ({
          id: p.id,
          productId: p.productId!,
          incomingProductId: p.incomingProductId ?? undefined,

          expectedProductName: p.expectedProductName || p.name || '',
          expectedQuantity: p.expectedQuantity ?? p.quantity ?? 0,
          expectedCbm: p.expectedCBM || p.cbm || 0,
          expectedTotalWeight: p.expectedTotalWeight ?? p.totalWeight ?? 0,
          expectedExpirationDate: p.expectedExpirationDate ? this.formatDateForInput(p.expectedExpirationDate) : '',

          productName: p.name || p.expectedProductName || '',
          quantity: p.quantity ?? 0,

          cbm: p.cbm || 0,
          weight: p.weight ?? this.getLegacyUnitWeight(p),
          expirationDate: p.expirationDate ? this.formatDateForInput(p.expirationDate) : '',

          supplier: p.supplier || undefined,
          unitPrice: p.unitPrice ?? undefined,
          totalAmount: p.totalAmount ?? undefined,
          typeOfPackage: p.typeOfPackage!,
          remarks: p.remarks || '',
          palletId: p.palletId ?? undefined,
          containerName: p.containerName || '',
          lotNumber: p.lotNumber || undefined
        }));
      } else {
        this.stagedItems = [];
      }

    // Populate available incoming products list for adding additional SKUs
    if (this.selectedIncoming?.products) {
    this.availableIncomingProducts = this.selectedIncoming.products
        .map(p => {
        // Calculate actual remaining unreceived balance
        const remaining = (p.remainingQuantity !== undefined && p.remainingQuantity !== null)
            ? p.remainingQuantity
            : ((p.quantity || 0) - (p.receivedQuantity || 0));

        // ✅ STRICT MATCHING: Check by incomingProductId (p.id) first to avoid duplicate SKU collisions
        const stagedItem = this.stagedItems.find(s => 
            (p.id && s.incomingProductId && s.incomingProductId === p.id) ||
            (!s.incomingProductId && s.productId === p.productId)
        );

        const isAlreadyStaged = !!stagedItem;
        const activeBalance = Math.max(0, remaining);

        return {
            id: p.id, // Unique IncomingProduct.Id
            productId: p.productId!,
            productName: p.productName || '',
            originalQuantity: p.quantity || 0,
            quantity: activeBalance,
            remainingQuantity: activeBalance,
            cbm: p.cbm || 0,
            weight: p.weight ?? this.getLegacyUnitWeight(p),
            totalWeight: (p.weight ?? this.getLegacyUnitWeight(p)) * activeBalance,
            expirationDate: p.expirationDate || new Date().toISOString().split('T')[0],
            supplier: p.supplier || '',
            unitPrice: p.unitPrice ?? undefined,
            totalAmount: p.totalAmount ?? undefined,
            remarks: p.remarks || '',
            typeOfPackage: p.typeOfPackage!,
            status: p.status,
            selected: isAlreadyStaged && activeBalance <= 0, // ✅ Pre-select items that are already staged and have no remaining balance
            isPreSelected: isAlreadyStaged && activeBalance <= 0 // ✅ ONLY lock items that are ALREADY in stagedItems table
        };
        })
        // Show items if they have remaining balance > 0 OR are currently staged in this receipt
        .filter(p => p.remainingQuantity > 0 || p.selected);
    }

      this.updatePalletGroups();
    } catch (err) {
      console.error('Failed to load edit receiving context:', err);
      this.toastService.error('Failed to load receiving receipt details.');
    } finally {
      this.isLoadingDetails = false;
      this.cd.markForCheck();
    }
  }

  toggleProductDropdown(event?: Event): void {
    if (event) event.stopPropagation();
    this.isProductDropdownOpen = !this.isProductDropdownOpen;
  }

toggleProductSelection(product: SelectableIncomingProduct, forceState?: boolean): void {
  if (product.isPreSelected) return;

  const newState = forceState !== undefined ? forceState : !product.selected;
  if (product.selected === newState) return; // No change needed
  
  product.selected = newState;

  // 1. Check if the product already exists in stagedItems (match strictly by productId)
  const existingRow = this.stagedItems.find(s => s.productId === product.productId);

  if (existingRow) {
    // 2. If it exists, just add or deduct the quantity (No new row created)
    if (product.selected) {
      existingRow.quantity = (existingRow.quantity || 0) + (product.quantity || 0);
    } else {
      existingRow.quantity = Math.max(0, (existingRow.quantity || 0) - (product.quantity || 0));
    }
    
    // Auto-recalculate CBM and Weight based on the new total quantity
    this.onItemQuantityChange(existingRow);
  } else {
    // 3. If it doesn't exist, handle adding or removing the row normally
    if (product.selected) {
      const prodName = product.productName || '';
      const qty = product.quantity || 0;
      const cbmVal = product.cbm || 0;
      const weightVal = product.weight ?? this.getLegacyUnitWeight(product);
      const expiryVal = product.expirationDate || new Date().toISOString().split('T')[0];

      this.stagedItems.push({
        incomingProductId: product.id,
        productId: product.productId,
        expectedProductName: prodName,
        expectedQuantity: qty,
        expectedCbm: cbmVal,
        expectedTotalWeight: product.totalWeight ?? this.getTotalWeight({ weight: weightVal, quantity: qty }),
        expectedExpirationDate: expiryVal,

        productName: prodName,
        quantity: qty,
        cbm: cbmVal,
        weight: weightVal,
        expirationDate: expiryVal,

        supplier: product.supplier || undefined,
        unitPrice: product.unitPrice ?? undefined,
        totalAmount: product.totalAmount ?? undefined,

        typeOfPackage: product.typeOfPackage || 'CS GLASS',
        remarks: product.remarks || '',
        palletId: undefined,
        containerName: ''
      });
    } else {
      // Remove the row if unselected and it drops to 0 matches
      const idx = this.stagedItems.findIndex(s => s.productId === product.productId);
      if (idx > -1) {
        this.stagedItems.splice(idx, 1);
      }
    }
  }

  this.updatePalletGroups();
  this.cd.markForCheck();
}

toggleSelectAllProducts(event: Event): void {
  const isChecked = (event.target as HTMLInputElement).checked;

  this.availableIncomingProducts.forEach(p => {
    // Only toggle items that are NOT locked and need changing
    if (!p.isPreSelected && p.selected !== isChecked) {
      this.toggleProductSelection(p, isChecked);
    }
  });
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

  getTotalWeight(item: { weight?: number; quantity?: number }): number {
    return Number(((item.weight ?? 0) * (item.quantity ?? 0)).toFixed(2));
  }

  private getLegacyUnitWeight(item: { weight?: number | null; totalWeight?: number | string; quantity?: number }): number {
    if (item.weight !== undefined && item.weight !== null && Number.isFinite(item.weight)) return item.weight;
    const totalWeight = Number(item.totalWeight ?? 0);
    const quantity = item.quantity ?? 0;
    return Number.isFinite(totalWeight) && quantity > 0 ? totalWeight / quantity : 0;
  }

  onItemQuantityChange(item: EditStagedProductItem): void {
    if (item.incomingProductId && this.availableIncomingProducts.length > 0) {
      const parent = this.availableIncomingProducts.find(p => p.id === item.incomingProductId);
      if (parent && parent.originalQuantity && parent.originalQuantity > 0) {
        const origCbm = parent.cbm || 0;
        const actQty = item.quantity ?? 0;

        const newCbm = (origCbm / parent.originalQuantity) * actQty;

        item.cbm = newCbm > 0 ? Number(newCbm.toFixed(4)) : 0;
        item.weight = this.getLegacyUnitWeight(parent);
      }
    }

    this.fieldDebounce$.next();
  }

  onItemFieldChange(): void {
    this.fieldDebounce$.next();
  }

  updatePalletGroups(): void {
    const groupsMap = new Map<number, EditStagedProductItem[]>();

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
        const val = i.cbm || 0;
        return sum + (Number.isFinite(val) ? val : 0);
      }, 0);

      const calcWeight = items.reduce((sum, i) => {
        return sum + this.getTotalWeight(i);
      }, 0);

      result.push({
        palletId,
        items,
        totalQuantity: totalQty,
        calculatedCbm: parseFloat(calcCbm.toFixed(4)),
        calculatedWeight: parseFloat(calcWeight.toFixed(2))
      });
    }

    this.palletGroups = result;
  }

  /**
   * Baseline-Weighted Tail Allocation for Pallet Overrides
   */
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

  private distributePalletScaleOverride(
    items: EditStagedProductItem[],
    overrideCbm?: number,
    overrideWeight?: number
  ): void {
    if (items.length === 0) return;

    // 1. Distribute Target CBM based on Baseline CBM Ratios
    if (overrideCbm !== undefined && overrideCbm >= 0) {
      const totalBaselineCbm = items.reduce((sum, i) => sum + (i.cbm || 0), 0);

      if (totalBaselineCbm >= 0) {
        let accumulatedCbm = 0;

        for (let i = 0; i < items.length; i++) {
          const item = items[i];
          const isLastItem = i === items.length - 1;

          if (isLastItem) {
            const exactCbm = Math.max(0, overrideCbm - accumulatedCbm);
            item.cbm = Number(exactCbm.toFixed(4));
          } else {
            const itemBaselineCbm = item.cbm || 0;
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

  applyPalletCbmOverride(group: PalletGroupSummary, newTotalCbm: number): void {
    if (!group || !Number.isFinite(newTotalCbm) || newTotalCbm < 0) return;
    const roundedCbm = Number(newTotalCbm.toFixed(4));
    this.distributePalletScaleOverride(group.items, roundedCbm, undefined);
    this.updatePalletGroups();
    this.fieldDebounce$.next();
  }

  applyPalletWeightOverride(group: PalletGroupSummary, newTotalWeight: number): void {
    if (!group || !Number.isFinite(newTotalWeight) || newTotalWeight < 0) return;
    this.distributePalletScaleOverride(group.items, undefined, newTotalWeight);
    this.updatePalletGroups();
    this.fieldDebounce$.next();
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
    this.updatePalletGroups();
    this.closePalletModal();
  }

removeProductItem(index: number): void {
  const removedItem = this.stagedItems[index];
  this.stagedItems.splice(index, 1);

  if (removedItem) {
    // Uncheck and unlock ALL matching SKUs in the dropdown so they can be re-added if needed
    const targets = this.availableIncomingProducts.filter(p => p.productId === removedItem.productId);
    targets.forEach(t => {
      t.selected = false;
      t.isPreSelected = false; 
    });
  }

  this.updatePalletGroups();
  this.cd.markForCheck();
}

  private validateForm(): string | null {
    const warehouseId = this.warehouseService.selectedWarehouseId();
    if (!warehouseId) return 'Warehouse context is required.';
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
      if (item.quantity < 0) {
        return `Quantity for line item #${i + 1} (${item.productName}) cannot be negative.`;
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
    if (!this.selectedReceiving?.id) return;

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
      productId: item.productId,
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
      await this.api.invoke(updateReceiving, { id: this.selectedReceiving.id, body: payload });
      this.toastService.success(`Receiving ${payload.series} successfully updated`);
      this.updated.emit();
      this.forceCloseAndReset();
    } catch (err) {
      console.error('Failed to update receiving:', err);
      this.toastService.error(`Failed to update receiving: ${err}`);
      this.validationError = 'Failed to update receiving receipt. Please check server connection.';
    } finally {
      this.isSaving = false;
      this.cd.markForCheck();
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

  onClose(): void {
    this.forceCloseAndReset();
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
    this.newReceiving = this.getInitialForm();
    this.stagedItems = [];
    this.palletGroups = [];
    this.selectedReceiving = null;
    this.selectedIncoming = null;
    this.closePalletModal();
    this.isPrintModalOpen = false;
    this.generatedPalletLabels = [];
    this.validationError = '';
    this.close.emit();
    this.cd.markForCheck();
  }
}