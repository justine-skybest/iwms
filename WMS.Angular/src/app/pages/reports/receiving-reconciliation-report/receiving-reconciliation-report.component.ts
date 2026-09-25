import { Component, OnInit, inject, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../../api/generated/api';
import { getAllShippersFromReceiving, receivingV2Get } from '../../../api/generated/functions';
import { ReceivedProductSummaryDto, ReceivingDetailsDtoPaginatedResponse, ReceivingSummaryDto } from '../../../api/generated/models';
import { WarehouseService } from '../../../lib/services/warehouse.service';
import { PageHeaderComponent } from '../../../shared/layout/page-header/page-header.component';
import { 
  LucideAngularModule, 
  Search, 
  ChevronDown, 
  ChevronRight, 
  FileSpreadsheet, 
  AlertTriangle, 
  Filter, 
  CheckCircle2, 
  Loader2,
  Building2,
  Clock
} from 'lucide-angular';
import { formatDate } from '../../../lib/utils/format-date';

@Component({
  selector: 'app-receiving-reconciliation-report',
  standalone: true,
  imports: [CommonModule, FormsModule, LucideAngularModule, PageHeaderComponent],
  templateUrl: './receiving-reconciliation-report.component.html',
})
export class ReceivingReconciliationReportComponent implements OnInit {
  readonly SearchIcon = Search;
  readonly ChevronDownIcon = ChevronDown;
  readonly ChevronRightIcon = ChevronRight;
  readonly SummaryIcon = FileSpreadsheet;
  readonly AlertIcon = AlertTriangle;
  readonly FilterIcon = Filter;
  readonly CheckIcon = CheckCircle2;
  readonly LoaderIcon = Loader2;
  readonly ShipperIcon = Building2;
  readonly ClockIcon = Clock;

  readonly BASELINE_START_DATE = '2026-09-23';

  public formatDate = formatDate;

  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);
  public warehouseService = inject(WarehouseService);

  shippers: string[] = [];
  selectedShipper = '';
  receivings: ReceivingSummaryDto[] = [];
  
  isLoadingShippers = false;
  isLoadingReceivings = false;
  error = '';
  searchQuery = '';

  // Track expanded row IDs for inline discrepancy inspection
  expandedReceivingIds: Set<number> = new Set();

  ngOnInit(): void {
    void this.loadShippers();
  }

  // --- STEP 1: FETCH ALL SHIPPERS ---
  async loadShippers(): Promise<void> {
    this.isLoadingShippers = true;
    this.error = '';
    this.cd.markForCheck();

    try {
      const response = await this.api.invoke(getAllShippersFromReceiving, {}) as string[];
      this.shippers = response || [];

      if (this.shippers.length > 0) {
        this.selectedShipper = this.shippers[0];
        void this.loadReceivingsForShipper();
      }
    } catch (err) {
      console.error('Failed to load shippers:', err);
      this.error = 'Unable to load shippers list.';
    } finally {
      this.isLoadingShippers = false;
      this.cd.markForCheck();
    }
  }

  // --- STEP 2: FETCH ALL RECEIVINGS FOR SELECTED SHIPPER (UNPAGINATED) ---
  async loadReceivingsForShipper(): Promise<void> {
    if (!this.selectedShipper) {
      this.receivings = [];
      return;
    }

    this.isLoadingReceivings = true;
    this.error = '';
    this.expandedReceivingIds.clear();
    this.cd.markForCheck();

    const params = this.warehouseService.withWarehouse({
      search: this.selectedShipper,
      pageSize: 10000
    });

    try {
      const response = await this.api.invoke(receivingV2Get, params) as ReceivingDetailsDtoPaginatedResponse;
      this.receivings = response.items ?? [];
    } catch (err) {
      console.error('Failed to load receivings for shipper:', err);
      this.error = `Failed to fetch receiving records for shipper "${this.selectedShipper}".`;
      this.receivings = [];
    } finally {
      this.isLoadingReceivings = false;
      this.cd.markForCheck();
    }
  }

  onShipperChange(): void {
    void this.loadReceivingsForShipper();
  }

  // --- CLIENT-SIDE SEARCH FILTERING ---
  get filteredReceivings(): ReceivingSummaryDto[] {
    if (!this.searchQuery.trim()) return this.receivings;
    const query = this.searchQuery.toLowerCase().trim();

    return this.receivings.filter(r => 
      r.series?.toLowerCase().includes(query) ||
      r.reference?.toLowerCase().includes(query) ||
      r.transportCompany?.toLowerCase().includes(query) ||
      r.driverName?.toLowerCase().includes(query)
    );
  }

// --- DATE EVALUATION: SEPTEMBER 24, 2026 ONWARD ---
  isReceivingFromBaselineOnward(receiving?: ReceivingSummaryDto | null): boolean {
    if (!receiving) return false;
    const rawDate = receiving.dateReceived || receiving.dateAdded;
    if (!rawDate) return false;

    try {
      const receiptDateStr = new Date(rawDate).toISOString().split('T')[0];
      return receiptDateStr >= this.BASELINE_START_DATE;
    } catch {
      return false;
    }
  }

  // --- EXPAND / COLLAPSE ROW TOGGLE ---
  toggleRowExpansion(id: number): void {
    if (this.expandedReceivingIds.has(id)) {
      this.expandedReceivingIds.delete(id);
    } else {
      this.expandedReceivingIds.add(id);
    }
    this.cd.markForCheck();
  }

  isRowExpanded(id: number): boolean {
    return this.expandedReceivingIds.has(id);
  }

  // --- DISCREPANCY RECONCILIATION HELPERS ---
  getVariance(item: ReceivedProductSummaryDto): number {
    return (item.quantity ?? 0) - (item.expectedQuantity ?? item.quantity ?? 0);
  }

  hasItemDiscrepancy(item: ReceivedProductSummaryDto, parentReceiving?: ReceivingSummaryDto | null): boolean {
    // SKIP PREVIOUS DATE RECEIVINGS (No Incoming baseline reference)
    if (parentReceiving && !this.isReceivingFromBaselineOnward(parentReceiving)) {
      return false;
    }

    if (item.hasDiscrepancy !== undefined) return item.hasDiscrepancy;

    const hasQtyVar = this.getVariance(item) !== 0;
    const hasNameVar = !!item.expectedProductName && item.expectedProductName.trim().toLowerCase() !== item.name?.trim()?.toLowerCase();
    const hasCbmVar = !!item.expectedCBM && item.expectedCBM !== item.cbm;
    const hasWeightVar = !!item.expectedTotalWeight && item.expectedTotalWeight !== item.totalWeight;
    const hasExpiryVar = !!item.expectedExpirationDate && item.expectedExpirationDate !== item.expirationDate;

    return hasQtyVar || hasNameVar || hasCbmVar || hasWeightVar || hasExpiryVar;
  }

  getReceiptDiscrepancyCount(receiving: ReceivingSummaryDto): number {
    // Return 0 for legacy records created prior to today
    if (!this.isReceivingFromBaselineOnward(receiving) || !receiving.products) {
      return 0;
    }
    return receiving.products.filter(p => this.hasItemDiscrepancy(p, receiving)).length;
  }

  // --- ACCURATE OVERVIEW CARDS (EVALUATES TODAY'S RECEIPTS ONLY) ---
  getOverallSummary() {
    let totalLineItems = 0;
    let totalMatchedItems = 0;
    let totalFlaggedItems = 0;
    let totalShortageUnits = 0;
    let totalExcessUnits = 0;
    let todayReceiptsCount = 0;
    let legacyReceiptsCount = 0;

    const targetList = this.filteredReceivings;

    for (const r of targetList) {
      const isToday = this.isReceivingFromBaselineOnward(r);
      if (isToday) {
        todayReceiptsCount++;
      } else {
        legacyReceiptsCount++;
      }

      if (!r.products) continue;

      for (const p of r.products) {
        totalLineItems++;
        if (isToday && this.hasItemDiscrepancy(p, r)) {
          totalFlaggedItems++;
          const variance = this.getVariance(p);
          if (variance < 0) totalShortageUnits += Math.abs(variance);
          if (variance > 0) totalExcessUnits += variance;
        } else {
          totalMatchedItems++;
        }
      }
    }

    const accuracyRate = totalLineItems > 0 ? (totalMatchedItems / totalLineItems) * 100 : 100;

    return {
      totalReceipts: targetList.length,
      todayReceiptsCount,
      legacyReceiptsCount,
      discrepantReceiptsCount: targetList.filter(r => this.isReceivingFromBaselineOnward(r) && this.getReceiptDiscrepancyCount(r) > 0).length,
      totalLineItems,
      totalMatchedItems,
      totalFlaggedItems,
      totalShortageUnits,
      totalExcessUnits,
      accuracyRate
    };
  }

  exportCsv(): void {
    console.log('Exporting full unpaginated Reconciliation Report for:', this.selectedShipper);
  }
}