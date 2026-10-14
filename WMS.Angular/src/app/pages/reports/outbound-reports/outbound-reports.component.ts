import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../../api/generated/api';
import { reportsOutboundReportsCancellationsReturnsGet, reportsOutboundReportsDispatchManifestGet, reportsOutboundReportsDockTurnaroundGet, reportsOutboundReportsEvidenceComplianceGet, reportsOutboundReportsExceptionsGet, reportsOutboundReportsPalletVerificationsGet, reportsOutboundReportsStagingVelocityGet, reportsOutboundReportsWorkforceProductivityGet } from '../../../api/generated/functions';

import {
  DispatchManifestReportDto,
  DockTurnaroundReportDto,
  StagingVelocityReportDto,
  LoadingExceptionReportDto,
  PalletVerificationReportSummaryDto,
  EvidenceComplianceSummaryDto,
  CancellationReturnReportDto,
  WorkforceProductivityReportDto
} from '../../../api/generated/models';
import { PageHeaderComponent } from '../../../shared/layout/page-header/page-header.component';
import { WarehouseService } from '../../../lib/services/warehouse.service';

export type OutboundReportType =
  | 'manifest'
  | 'turnaround'
  | 'staging'
  | 'verifications'
  | 'exceptions'
  | 'compliance'
  | 'cancellations'
  | 'workforce';

@Component({
  selector: 'app-outbound-reports',
  standalone: true,
  imports: [CommonModule, FormsModule, PageHeaderComponent],
  template: `<h1>Pending Development</h1>`,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class OutboundReportsComponent implements OnInit {
  activeTab: OutboundReportType = 'manifest';
  isLoading = false;
  error: string | null = null;
  expandedRows = new Set<number>();
  private warehouseService = inject(WarehouseService);

  // Global Date & Operational Filters
  fromDate: string = new Date(Date.now() - 7 * 24 * 60 * 60 * 1000).toISOString().split('T')[0];
  toDate: string = new Date().toISOString().split('T')[0];
  warehouseId = this.warehouseService.selectedWarehouseId();
  statusFilter: string = '';

  // Data sets
    manifestData: DispatchManifestReportDto[] = [];
  turnaroundData: DockTurnaroundReportDto[] = [];
  stagingData: StagingVelocityReportDto[] = [];
  exceptionsData: LoadingExceptionReportDto[] = [];
  verificationReport: PalletVerificationReportSummaryDto | null = null;
  complianceReport: EvidenceComplianceSummaryDto | null = null;
  cancellationsData: CancellationReturnReportDto[] = [];
  workforceData: WorkforceProductivityReportDto | null = null;

  constructor(
    private api: Api,
    private cd: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadCurrentReport();
  }

  get totalCount(): number {
    switch (this.activeTab) {
      case 'manifest': return this.manifestData.length;
      case 'turnaround': return this.turnaroundData.length;
      case 'staging': return this.stagingData.length;
      case 'exceptions': return this.exceptionsData.length;
      case 'verifications': return this.verificationReport?.totalScans ?? 0;
      case 'compliance': return this.complianceReport?.totalCompletedPlans ?? 0;
      case 'cancellations': return this.cancellationsData.length;
      default: return 0;
    }
  }

  setTab(tab: OutboundReportType): void {
    this.activeTab = tab;
    this.error = null;
    this.loadCurrentReport();
  }

toggleRow(id?: number): void {
    if (id === undefined) return;
    if (this.expandedRows.has(id)) {
      this.expandedRows.delete(id);
    } else {
      this.expandedRows.add(id);
    }
    this.cd.markForCheck();
  }

isExpanded(id?: number): boolean {
    return id !== undefined && this.expandedRows.has(id);
}

  async loadCurrentReport(): Promise<void> {
    this.isLoading = true;
    this.error = null;
    this.cd.markForCheck();

    const baseParams = {
      fromDate: this.fromDate ? new Date(this.fromDate).toISOString() : undefined,
      toDate: this.toDate ? new Date(this.toDate + 'T23:59:59.999Z').toISOString() : undefined,
      warehouseId: this.warehouseId ? Number(this.warehouseId) : undefined
    };

    try {
      switch (this.activeTab) {
        case 'manifest':
          this.manifestData = await this.api.invoke(reportsOutboundReportsDispatchManifestGet, {
            fromDate: this.fromDate,
            toDate: this.toDate,
            warehouseId: this.warehouseId!
          }) as DispatchManifestReportDto[];
          break;

        case 'turnaround':
          this.turnaroundData = await this.api.invoke(reportsOutboundReportsDockTurnaroundGet, {
            fromDate: this.fromDate,
            toDate: this.toDate,
            warehouseId: this.warehouseId!
          }) as DockTurnaroundReportDto[];
          break;

        case 'exceptions':
          this.exceptionsData = await this.api.invoke(reportsOutboundReportsExceptionsGet, {
            fromDate: this.fromDate,
            toDate: this.toDate
          }) as LoadingExceptionReportDto[];
          break;

        case 'verifications':
          this.verificationReport = await this.api.invoke(reportsOutboundReportsPalletVerificationsGet, {
            fromDate: this.fromDate,
            toDate: this.toDate
          }) as PalletVerificationReportSummaryDto;
          break;
      }
    } catch (err) {
      this.error = `Failed to load ${this.activeTab} report.`;
    } finally {
      this.isLoading = false;
      this.cd.markForCheck();
    }
  }

  // --- Aggregate Visual Indicators ---
  get manifestAggregate() {
    const totalPlanned = this.manifestData.reduce((acc, curr) => acc + curr.totalQuantityPlanned!, 0);
    const totalLoaded = this.manifestData.reduce((acc, curr) => acc + curr.totalQuantityLoaded!, 0);
    const overallFillRate = totalPlanned > 0 ? (totalLoaded / totalPlanned) * 100 : 0;
    return { totalPlanned, totalLoaded, overallFillRate };
  }

  get turnaroundAverage(): number {
    if (!this.turnaroundData.length) return 0;
    const totalMinutes = this.turnaroundData.reduce((acc, curr) => acc + curr.netTurnaroundMinutes!, 0);
    return Math.round(totalMinutes / this.turnaroundData.length);
  }

  get exceptionsCriticalCount(): number {
    return this.exceptionsData.filter(e => e.severity === 'Critical' || e.severity === 'High').length;
  }

  // --- Client-side CSV Download ---
  exportCsv(): void {
    let rows: any[] = [];
    let filename = `outbound-${this.activeTab}-${new Date().toISOString().slice(0, 10)}.csv`;

    if (this.activeTab === 'manifest') {
      rows = this.manifestData.map(d => ({
        LoadingReference: d.loadingReference,
        Status: d.status,
        Warehouse: d.warehouseName,
        Vehicle: d.transport?.vehiclePlateNumber || 'N/A',
        Seal: d.transport?.sealNumber || 'N/A',
        Planned: d.totalQuantityPlanned,
        Loaded: d.totalQuantityLoaded,
        FulfillmentRate: `${d.fulfillmentRatePercentage}%`,
        CompletedAt: d.timestamps?.completedAt || 'N/A'
      }));
    } else if (this.activeTab === 'turnaround') {
      rows = this.turnaroundData.map(d => ({
        LoadingReference: d.loadingReference,
        Vehicle: d.vehiclePlateNumber || 'N/A',
        Container: d.containerNumber || 'N/A',
        TurnaroundMinutes: d.netTurnaroundMinutes,
        UnitsLoaded: d.totalUnitsLoaded,
        Pallets: d.totalPalletsCount,
        UnitsPerHour: d.unitsPerHour
      }));
    } else if (this.activeTab === 'exceptions') {
      rows = this.exceptionsData.map(d => ({
        LoadingReference: d.loadingReference,
        Type: d.exceptionType,
        Severity: d.severity,
        Product: d.affectedProduct,
        Description: d.description,
        CreatedAt: d.createdAt
      }));
    }

    if (!rows.length) return;

    const headers = Object.keys(rows[0]).join(',');
    const csvContent = 'data:text/csv;charset=utf-8,' + [headers, ...rows.map(r => Object.values(r).map(v => `"${v}"`).join(','))].join('\n');
    const encodedUri = encodeURI(csvContent);
    const link = document.createElement('a');
    link.setAttribute('href', encodedUri);
    link.setAttribute('download', filename);
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  }
}