import { ChangeDetectorRef, Component, OnInit, inject, effect, Output, EventEmitter, OnDestroy, ViewChild, ElementRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../api/generated/api';
import { receivingV2Get, receivingGet, getReceiving } from '../../api/generated/functions';
import { ReceivedProductDetailsDto, ReceivingDetailsDtoPaginatedResponse, ReceivingDetailsDto } from '../../api/generated/models';
import { WarehouseService } from '../../lib/services/warehouse.service';
import { ReceivingCreateComponent } from './create/receiving-create.component';
import { LucideAngularModule, ChevronLeft, ChevronRight, EyeIcon, SearchIcon, PlusIcon, AlertTriangle, FileSpreadsheet, Clock, Printer } from 'lucide-angular';
import { SignalRService } from '../../lib/services/signalr.service';
import { Subject, takeUntil } from 'rxjs';
import { PageHeaderComponent } from '../../shared/layout/page-header/page-header.component';
import { formatDate } from '../../lib/utils/format-date';
import { formatTime } from '../../lib/utils/format-time';
import { generateQrCodeDataUrl } from '../../lib/utils/qr-code.util';

export type DiscrepancyCategory = 'QUANTITY' | 'DESCRIPTION' | 'EXPIRY' | 'WEIGHT' | 'CBM' | 'DAMAGED' | 'OTHER';

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
  selector: 'app-receiving-list',
  standalone: true,
  imports: [CommonModule, FormsModule, ReceivingCreateComponent, LucideAngularModule, PageHeaderComponent],
  templateUrl: './receiving-list.component.html',
})
export class ReceivingListComponent implements OnInit, OnDestroy {
  // Reference the thermal print container in the template via ElementRef
  @ViewChild('thermalPrintContainer') thermalPrintContainer!: ElementRef<HTMLDivElement>;

  @Output() closed = new EventEmitter<void>();
  Math = Math;
  readonly chevronLeft = ChevronLeft;
  readonly chevronRight = ChevronRight;
  readonly eyeIcon = EyeIcon;
  readonly searchIcon = SearchIcon;
  readonly plus = PlusIcon;
  readonly AlertIcon = AlertTriangle;
  readonly SummaryIcon = FileSpreadsheet;
  readonly ClockIcon = Clock;
  readonly PrinterIcon = Printer;

  readonly BASELINE_START_DATE = '2026-09-23';

  public formatDate = formatDate;
  public formatTime = formatTime;

  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);
  public warehouseService = inject(WarehouseService);
  private signalRService = inject(SignalRService);

  private destroy$ = new Subject<void>();

  receivings: ReceivingDetailsDto[] = [];
  isLoading = true;
  error = '';
  search = '';
  page = 1;
  pageSize = 10;
  totalCount = 0;
  totalPages = 0;

  isViewOpen = false;
  isCreateOpen = false;
  selectedReceiving: ReceivingDetailsDto | null = null;

  isPrintModalOpen = false;
  generatedPalletLabels: PalletLabelPrintData[] = [];
  isGeneratingLabels = false;

  constructor() {
    effect(() => {
      this.warehouseService.selectedWarehouseId();
      this.page = 1;
      void this.loadReceivings();
    });
  }

  ngOnInit(): void {
    void this.loadReceivings();

    this.signalRService.receivingUpdated$
      .pipe(takeUntil(this.destroy$))
      .subscribe(() => {
        void this.loadReceivings();
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  close(): void {
    this.closed.emit();
  }

  async loadReceivings(): Promise<void> {
    this.isLoading = true;
    this.error = '';
    this.cd.markForCheck();

    const trimmedSearch = this.search.trim();
    const baseParams = {
      page: this.page,
      pageSize: this.pageSize,
      ...(trimmedSearch ? { search: trimmedSearch } : {}),
    };

    const params = this.warehouseService.withWarehouse(baseParams);

    try {
      const response = await this.api.invoke(receivingV2Get, params) as ReceivingDetailsDtoPaginatedResponse;
      this.receivings = response.items ?? [];
      this.totalCount = response.totalCount ?? 0;
      this.totalPages = response.totalPages ?? 0;
    } catch (err) {
      this.error = 'Unable to load receiving transactions.';
      console.error('Failed to load receivings:', err);
    } finally {
      this.isLoading = false;
      this.cd.markForCheck();
    }
  }

  openView(receiving: ReceivingDetailsDto): void {
    this.selectedReceiving = receiving;
    this.isViewOpen = true;
  }

  closeView(): void {
    this.isViewOpen = false;
    this.selectedReceiving = null;
  }

  openCreate(): void {
    this.isCreateOpen = true;
  }

  closeCreate(): void {
    this.isCreateOpen = false;
  }

  onSearch(): void {
    this.page = 1;
    void this.loadReceivings();
  }

  goToPage(nextPage: number): void {
    this.page = Math.max(1, Math.min(nextPage, this.totalPages || 1));
    void this.loadReceivings();
  }

  changePageSize(event: Event): void {
    this.pageSize = Number((event.target as HTMLSelectElement).value);
    this.page = 1;
    void this.loadReceivings();
  }

  hasPalletizedItems(receiving?: ReceivingDetailsDto | null): boolean {
    return !!receiving?.products?.some(p => !!p.palletId);
  }

  async preparePalletLabelsForPrinting(receivingId: number): Promise<void> {
    this.isGeneratingLabels = true;
    this.cd.markForCheck();

    try {
      const receiving = await this.api.invoke(getReceiving, { id: receivingId }) as ReceivingDetailsDto;
      const items = (receiving?.products || []).filter(p => !!p.palletId);

      if (items.length === 0) {
        this.isGeneratingLabels = false;
        this.cd.markForCheck();
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
      const dateReceivedStr = this.formatDate(receiving.dateReceived);

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
      console.error('Failed to fetch receiving details for printing:', err);
    } finally {
      this.isGeneratingLabels = false;
      this.cd.markForCheck();
    }
  }

  // --- ISOLATED IFRAME PRINTING VIA ElementRef ---
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
  }

  isReceivingFromBaselineOnward(receiving?: ReceivingDetailsDto | null): boolean {
    if (!receiving) return false;
    const rawDate = receiving.dateReceived;
    if (!rawDate) return false;

    try {
      const receiptDateStr = new Date(rawDate).toISOString().split('T')[0];
      return receiptDateStr >= this.BASELINE_START_DATE;
    } catch {
      return false;
    }
  }

  getVariance(item?: { quantity?: number | null; expectedQuantity?: number | null }): number {
    if (!item || item.expectedQuantity === null || item.expectedQuantity === undefined) {
      return 0;
    }
    return (item.quantity ?? 0) - item.expectedQuantity;
  }

  hasItemDiscrepancy(item: ReceivedProductDetailsDto, parentReceiving?: ReceivingDetailsDto | null): boolean {
    if (parentReceiving && !this.isReceivingFromBaselineOnward(parentReceiving)) {
      return false;
    }

    const hasQtyVar = this.getVariance(item) !== 0;
    const hasNameVar = !!item.expectedProductName && item.expectedProductName.trim().toLowerCase() !== item.name?.trim()?.toLowerCase();
    const hasCbmVar = !!item.expectedCBM && item.expectedCBM !== item.cbm;
    const hasWeightVar = !!item.expectedTotalWeight && item.expectedTotalWeight !== item.totalWeight;
    const hasExpiryVar = !!item.expectedExpirationDate && item.expectedExpirationDate !== item.expirationDate;

    return hasQtyVar || hasNameVar || hasCbmVar || hasWeightVar || hasExpiryVar;
  }

  getDiscrepancySummary(receiving: ReceivingDetailsDto | null) {
    const summary = {
      matchedCount: 0,
      flaggedCount: 0,
      totalItems: receiving?.products?.length || 0,
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
      } as Record<DiscrepancyCategory, number>
    };

    if (!receiving?.products) return summary;

    if (!this.isReceivingFromBaselineOnward(receiving)) {
      summary.matchedCount = summary.totalItems;
      return summary;
    }

    for (const item of receiving.products) {
      if (!this.hasItemDiscrepancy(item, receiving)) {
        summary.matchedCount++;
      } else {
        summary.flaggedCount++;

        const variance = this.getVariance(item);
        if (variance < 0) {
          summary.totalQuantityShortage += Math.abs(variance);
          summary.categoryCounts.QUANTITY++;
        } else if (variance > 0) {
          summary.totalQuantityExcess += variance;
          summary.categoryCounts.QUANTITY++;
        }

        if (item.expectedProductName && item.expectedProductName.trim().toLowerCase() !== item.name?.trim()?.toLowerCase()) {
          summary.categoryCounts.DESCRIPTION++;
        }
        if (item.expectedCBM && item.expectedCBM !== item.cbm) {
          summary.categoryCounts.CBM++;
        }
        if (item.expectedTotalWeight && item.expectedTotalWeight !== item.totalWeight) {
          summary.categoryCounts.WEIGHT++;
        }
        if (item.expectedExpirationDate && item.expectedExpirationDate !== item.expirationDate) {
          summary.categoryCounts.EXPIRY++;
        }

        if (item.remarks?.includes('DAMAGED')) summary.categoryCounts.DAMAGED++;
        if (item.remarks?.includes('OTHER')) summary.categoryCounts.OTHER++;
      }
    }

    return summary;
  }
}