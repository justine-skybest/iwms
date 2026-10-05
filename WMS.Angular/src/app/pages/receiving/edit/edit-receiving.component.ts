import { Component, EventEmitter, OnChanges, SimpleChanges, Input, Output, inject, ChangeDetectorRef, ElementRef, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../../api/generated/api';
import { WarehouseService } from '../../../lib/services/warehouse.service';
import { 
  CreateReceivingDto, 
  IncomingResponseDto, 
  PalletLocationDto, 
  ReceivedProductDetailsDto, 
  ReceivingDetailsDto
} from '../../../api/generated/models';
import { updateReceiving, getReceiving, locatePalletByQrCode, getIncomingById } from '../../../api/generated/functions';
import { QrScannerComponent } from '../../../shared/components/qr-scanner/qr-scanner.component';
import { LucideAngularModule, Trash2, Search, ChevronDown, X, Loader2, Check, QrCode, Box, Plus, AlertTriangle, ShieldCheck, FileSpreadsheet, PackageCheck, Printer } from 'lucide-angular';
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
  cbm?: string;
  expectedCbm?: string;
  totalWeight?: string;
  expectedTotalWeight?: string;
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
export class EditReceivingComponent implements OnChanges {
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

  isPalletModalOpen = false;
  activeRowIndexForPallet: number | null = null;
  palletQrCodeInput = '';
  scannedPallet: PalletLocationDto | null = null;
  isLocatingPallet = false;
  palletError = '';

  isPrintModalOpen = false;
  generatedPalletLabels: PalletLabelPrintData[] = [];

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['isOpen'] && this.isOpen && this.selectedReceiving) {
      void this.loadAndPopulateForm(this.selectedReceiving);
      console.log(this.selectedReceiving);
    } else if (changes['selectedReceiving'] && this.isOpen && this.selectedReceiving) {
      void this.loadAndPopulateForm(this.selectedReceiving);
    }
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
      // 1. Fetch fresh receiving receipt details
      const freshReceiving = receiving.id 
        ? (await this.api.invoke(getReceiving, { id: receiving.id }) as ReceivingDetailsDto) 
        : receiving;

      this.newReceiving = {
        series: freshReceiving.series ?? '',
        driverName: freshReceiving.driverName ?? '',
        incomingId: this.selectedReceiving?.incomingId!,
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

      // 2. Load linked Incoming shipment if available
      if (freshReceiving.incomingId) {
        this.selectedIncoming = await this.api.invoke(getIncomingById, { id: freshReceiving.incomingId }) as IncomingResponseDto;
      } else {
        this.selectedIncoming = null;
      }

      // 3. Build staged line items
      if (freshReceiving.products && freshReceiving.products.length > 0) {
        this.stagedItems = freshReceiving.products.map(p => ({
          id: p.id,
          productId: p.productId!,
          incomingProductId: p.incomingProductId ?? undefined,

          expectedProductName: p.expectedProductName || p.name || '',
          expectedQuantity: p.expectedQuantity ?? p.quantity ?? 0,
          expectedCbm: p.expectedCBM || p.cbm || '0',
          expectedTotalWeight: p.expectedTotalWeight || p.totalWeight || '0',
          expectedExpirationDate: p.expectedExpirationDate ? this.formatDateForInput(p.expectedExpirationDate) : '',

          productName: p.name || p.expectedProductName || '',
          quantity: p.quantity ?? 0,

          cbm: p.cbm || '0',
          totalWeight: p.totalWeight || '0',
          expirationDate: p.expirationDate ? this.formatDateForInput(p.expirationDate) : '',

          supplier: p.supplier || undefined,
          unitPrice: p.unitPrice ?? undefined,
          totalAmount: p.totalAmount ?? undefined,
          typeOfPackage: p.typeOfPackage || 'CS GLASS',
          remarks: p.remarks || '',
          palletId: p.palletId ?? undefined,
          containerName: p.containerName || '',
          lotNumber: p.lotNumber || undefined
        }));
      } else {
        this.stagedItems = [];
      }
    } catch (err) {
      console.error('Failed to load edit receiving context:', err);
      this.toastService.error('Failed to load receiving receipt details.');
    } finally {
      this.isLoadingDetails = false;
      this.cd.markForCheck();
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
    this.closePalletModal();
  }

  removeProductItem(index: number): void {
    this.stagedItems.splice(index, 1);
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
      cbm: item.cbm || '0',
      totalWeight: item.totalWeight || '0',
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

    console.log('Submitting update payload:', payload);

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