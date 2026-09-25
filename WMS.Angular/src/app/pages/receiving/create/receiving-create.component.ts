import { Component, EventEmitter, Input, Output, inject, ChangeDetectorRef, HostListener, ElementRef, ViewChild } from '@angular/core';
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
  typeOfPackage?: string;
  received?: boolean;
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
  cbm?: string | null;
  containerName?: string | null;
  expectedCBM?: string | null;
  expirationDate?: string | null;
  id?: number;
  lotNumber?: string | null;
  name?: string | null;
  palletId?: number | null;
  productId?: number;
  quantity?: number;
  remarks?: string | null;
  supplier?: string | null;
  totalAmount?: number;
  totalWeight?: string | null;
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
  imports: [CommonModule, FormsModule, LucideAngularModule, QrScannerComponent],
  templateUrl: './receiving-create.component.html',
  styles: [`
    @media print {
      @page {
        size: 4in 6in;
        margin: 0 !important;
      }

      body {
        margin: 0 !important;
        padding: 0 !important;
        background: #ffffff !important;
      }

      body * {
        visibility: hidden !important;
      }

      .printable-thermal-labels, .printable-thermal-labels * {
        visibility: visible !important;
      }

      .printable-thermal-labels {
        display: block !important;
        position: fixed !important;
        left: 0 !important;
        top: 0 !important;
        width: 4in !important;
        height: 6in !important;
        margin: 0 !important;
        padding: 0 !important;
        z-index: 999999 !important;
        background: #ffffff !important;
      }

      .thermal-label-page {
        width: 4in !important;
        height: 6in !important;
        padding: 0.25in !important;
        margin: 0 !important;
        page-break-after: always !important;
        break-after: page !important;
        display: flex !important;
        flex-direction: column !important;
        justify-content: space-between !important;
        box-sizing: border-box !important;
        background: #ffffff !important;
        color: #000000 !important;
        font-family: Arial, sans-serif !important;
        overflow: hidden !important;
      }
    }
  `]
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
  private elementRef = inject(ElementRef);
  public warehouseService = inject(WarehouseService);
  private toastService = inject(ToastService);

  public formatDate = formatDate;

  @Input() isOpen = false;
  @Output() close = new EventEmitter<void>();
  @Output() created = new EventEmitter<void>();
  @ViewChild('thermalPrintContainer') thermalPrintContainer!: ElementRef<HTMLDivElement>;

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

  isPrintModalOpen = false;
  generatedPalletLabels: PalletLabelPrintData[] = [];

  private incomingSearchDebounce: any;

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
        typeOfPackage: p.typeOfPackage || 'CS GLASS',
        received: p.received || false,
        selected: false
      }));

    this.syncStagedItemsFromSelection();
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

          typeOfPackage: p.typeOfPackage || 'CS GLASS',
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
        typeOfPackage: item.typeOfPackage,

        productName: item.productName,
        quantity: item.quantity ?? 0,
        cbm: item.cbm || '0',
        totalWeight: item.totalWeight || '0',
        expirationDate: item.expirationDate as any,
        totalAmount: item.totalAmount,
        unitPrice: item.unitPrice,

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
      const createdReceiving = await this.api.invoke(createReceiving, { body: payload }) as any;
      this.toastService.success(`Receiving ${payload.series} successfully submitted`);
      this.created.emit();

      const createdId = createdReceiving?.id;
      const hasPalletizedItems = this.stagedItems.some(p => !!p.palletId);

      if (createdId && hasPalletizedItems) {
        // Fetch server details to get exact server-generated Lot Numbers for thermal printing
        await this.preparePalletLabelsForPrinting(createdId);
      } else {
        this.onClose();
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

 private async preparePalletLabelsForPrinting(receivingId: number): Promise<void> {
    try {
      const receiving = await this.api.invoke(getReceiving, { id: receivingId }) as ReceivingDetailsDto;
      const items = (receiving?.products || []).filter(p => !!p.palletId);

      console.log(items)

      if (items.length === 0) {
        this.onClose();
        return;
      }

      // 1. Group strongly-typed DTO items by Pallet ID
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
        
        // 2. Safe numeric weight sum
        const totalWeightVal = groupItems.reduce((acc, curr) => {
          const parsed = parseFloat(curr.totalWeight || '0');
          return acc + (isNaN(parsed) ? 0 : parsed);
        }, 0);

        const firstItem = groupItems[0];

        // 3. FIX: ReceivedProductDetailsDto uses `name` for Product Name
        const primaryName = firstItem.name || firstItem.expectedProductName || '—';
        const prodName = groupItems.length === 1 
          ? primaryName 
          : `${primaryName} (+${groupItems.length - 1} items)`;

        // 4. FIX: Use Product ID for single SKU code instead of CBM
        const codeVal = groupItems.length === 1 
          ? (firstItem.productId ? `#${firstItem.productId}` : '—') 
          : 'MULTI-SKU';

        // 5. Clean server-generated Lot Number extraction
        const lotVal = Array.from(
          new Set(
            groupItems
              .map(i => i.lotNumber?.trim())
              .filter((lot): lot is string => !!lot && lot !== '')
          )
        ).join(', ') || '—';

        // 6. Aggregate up to 3 distinct UOMs (typeOfPackage)
        const uomList = Array.from(
          new Set(
            groupItems
              .map(i => i.typeOfPackage?.trim())
              .filter((uom): uom is string => !!uom && uom !== '')
          )
        );
        const uomVal = uomList.slice(0, 3).join(', ') || 'CS GLASS';

        // 7. HashCode fallback
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

    // Create a temporary hidden iframe at document root
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

    // Trigger print after iframe renders images
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
    this.onClose();
  }

  onClose(): void {
    this.newReceiving = this.getInitialForm();
    this.stagedItems = [];
    this.clearIncomingSelection();
    this.closePalletModal();
    this.isPrintModalOpen = false;
    this.generatedPalletLabels = [];
    this.validationError = '';
    this.close.emit();
  }
}