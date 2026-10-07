import { Component, OnInit, OnDestroy, inject, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Subject, Subscription, timer, firstValueFrom } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Api } from '../../../api/generated/api';
import { 
  LucideAngularModule, 
  FileSpreadsheet, 
  Download, 
  RefreshCw, 
  AlertCircle, 
  CheckCircle, 
  Loader2, 
  Plus, 
  Filter, 
  X,
  Hourglass
} from 'lucide-angular';
import { ToastService } from '../../../lib/services/toast.service';
import { formatDate } from '../../../lib/utils/format-date';
import { PageHeaderComponent } from '../../../shared/layout/page-header/page-header.component';
import { SearchableSelectComponent, SelectOption } from '../../../shared/components/select/select.component';
import { WarehouseService } from '../../../lib/services/warehouse.service';

// OpenAPI Generated Functions & Models
import { 
  getInventoryAgingReports, 
  generateInventoryAgingReport, 
  downloadInventoryAgingReport,
  getAllShippersFromReceiving 
} from '../../../api/generated/functions';
import { ReportJob, GenerateInventoryAgingReportRequest } from '../../../api/generated/models';

@Component({
  selector: 'app-inventory-aging-reports',
  standalone: true,
  imports: [
    CommonModule, 
    FormsModule, 
    LucideAngularModule, 
    PageHeaderComponent, 
    SearchableSelectComponent
  ],
  templateUrl: './inventory-aging-reports.component.html',
})
export class InventoryAgingReportsComponent implements OnInit, OnDestroy {
  readonly FileIcon = FileSpreadsheet;
  readonly DownloadIcon = Download;
  readonly RefreshIcon = RefreshCw;
  readonly AlertIcon = AlertCircle;
  readonly CheckIcon = CheckCircle;
  readonly LoaderIcon = Loader2;
  readonly PlusIcon = Plus;
  readonly FilterIcon = Filter;
  readonly XIcon = X;
  readonly HourglassIcon = Hourglass;

  private api = inject(Api);
  private http = inject(HttpClient);
  private cd = inject(ChangeDetectorRef);
  private toastService = inject(ToastService);
  private warehouseService = inject(WarehouseService);

  public formatDate = formatDate;
  public Math = Math;

  reports: ReportJob[] = [];
  isLoading = false;
  isGenerating = false;

  page = 1;
  pageSize = 15;
  totalCount = 0;
  totalPages = 0;

  private destroy$ = new Subject<void>();
  private pollSubscription?: Subscription;

  isModalOpen = false;

  // Searchable Select State for Shipper
  selectedShipperOption: SelectOption<string>[] = [];

  reportForm = {
    format: 'Excel' as 'Excel' | 'Csv' | 'Pdf'
  };

  ngOnInit(): void {
    this.loadReports();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  // ---------------------------------------------------------------------------
  // Searchable Select Function for Shippers
  // ---------------------------------------------------------------------------
  searchShippers = (term: string): Promise<SelectOption<string>[]> => {
    return firstValueFrom(
      getAllShippersFromReceiving(this.http, this.api.rootUrl, {
        warehouseId: this.warehouseService.selectedWarehouseId() || undefined
      })
    ).then((res) => {
      const shippers = res.body || [];
      const filtered = shippers.filter(s => s.toLowerCase().includes(term.toLowerCase()));
      
      return filtered.map((shipper, index) => ({
        id: index,
        label: shipper,
        sublabel: 'Shipper / Supplier',
        raw: shipper
      }));
    }).catch(() => []);
  };

  // ---------------------------------------------------------------------------
  // Load Generated Reports History
  // ---------------------------------------------------------------------------
  loadReports(isSilent = false): void {
    const warehouseId = this.warehouseService.selectedWarehouseId();
    if (!warehouseId) return;

    if (!isSilent) this.isLoading = true;
    this.cd.markForCheck();

    getInventoryAgingReports(this.http, this.api.rootUrl, {
      warehouseId: warehouseId,
      page: this.page,
      pageSize: this.pageSize
    }).subscribe({
      next: (res) => {
        const data = res.body;
        this.reports = data?.items || [];
        this.totalCount = data?.totalCount ?? 0;
        this.totalPages = data?.totalPages ?? 1;
        this.isLoading = false;
        this.checkAndStartPolling();
        this.cd.markForCheck();
      },
      error: () => {
        if (!isSilent) this.toastService.error('Failed to load inventory aging reports.');
        this.isLoading = false;
        this.cd.markForCheck();
      }
    });
  }

  private checkAndStartPolling(): void {
    const hasActiveJobs = this.reports.some(r => r.status === 'Pending' || r.status === 'Processing');
    if (hasActiveJobs && !this.pollSubscription) {
      this.pollSubscription = timer(3000, 3000).pipe(
        takeUntil(this.destroy$)
      ).subscribe(() => this.loadReports(true));
    } else if (!hasActiveJobs && this.pollSubscription) {
      this.pollSubscription.unsubscribe();
      this.pollSubscription = undefined;
    }
  }

  // ---------------------------------------------------------------------------
  // Modal Actions
  // ---------------------------------------------------------------------------
  openGenerateModal(): void {
    this.isModalOpen = true;
    this.selectedShipperOption = [];
    this.reportForm.format = 'Excel';
  }

  closeGenerateModal(): void {
    this.isModalOpen = false;
  }

  submitGenerateReport(): void {
    const warehouseId = this.warehouseService.selectedWarehouseId();
    if (!warehouseId) {
      this.toastService.error('Please select an active warehouse.');
      return;
    }

    this.isGenerating = true;
    const shipperValue = this.selectedShipperOption.length > 0 ? this.selectedShipperOption[0].label : null;

    const payload: GenerateInventoryAgingReportRequest = {
      format: this.reportForm.format,
      warehouseId: warehouseId,
      shipper: shipperValue,
      productId: null // Product filter skipped as requested
    };

    generateInventoryAgingReport(this.http, this.api.rootUrl, { body: payload }).subscribe({
      next: () => {
        this.toastService.success('Inventory aging report generation job queued.');
        this.isGenerating = false;
        this.closeGenerateModal();
        this.loadReports();
      },
      error: (err) => {
        console.error('Report trigger error:', err);
        this.toastService.error('Failed to trigger inventory aging report generation.');
        this.isGenerating = false;
        this.cd.markForCheck();
      }
    });
  }

  // ---------------------------------------------------------------------------
  // File Download (Preserves raw binary blob stream)
  // ---------------------------------------------------------------------------
  downloadFile(job: ReportJob): void {
    if (job.status !== 'Completed' || !job.id) return;

    const url = `${this.api.rootUrl}/reports/inventory-aging/download/${job.id}`;

    this.http.get(url, { observe: 'response' as const, responseType: 'blob' as const }).subscribe({
      next: (response: HttpResponse<Blob>) => {
        if (!response.body) {
          this.toastService.error('Received empty file payload.');
          return;
        }

        let fileName = `${job.jobNumber}.xlsx`;
        const contentDisposition = response.headers?.get('Content-Disposition');
        if (contentDisposition) {
          const matches = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/.exec(contentDisposition);
          if (matches != null && matches[1]) fileName = matches[1].replace(/['"]/g, '');
        }

        const blob = new Blob([response.body], {
          type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'
        });
        const downloadUrl = window.URL.createObjectURL(blob);
        const link = document.createElement('a');
        link.href = downloadUrl;
        link.download = fileName;
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
        window.URL.revokeObjectURL(downloadUrl);
      },
      error: () => this.toastService.error('Failed to download report file.')
    });
  }

  changePage(newPage: number): void {
    if (newPage < 1 || newPage > this.totalPages) return;
    this.page = newPage;
    this.loadReports();
  }
}