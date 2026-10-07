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
  Calendar, 
  Filter, 
  X,
  Truck
} from 'lucide-angular';
import { ToastService } from '../../../lib/services/toast.service';
import { formatDate } from '../../../lib/utils/format-date';
import { PageHeaderComponent } from '../../../shared/layout/page-header/page-header.component';
import { SearchableSelectComponent, SelectOption } from '../../../shared/components/select/select.component';

// Generated OpenAPI functions & models
import { 
  getPickOrderReports, 
  generatePickOrderReport, 
  downloadPickOrderReport, 
  getAllShippersFromReceiving 
} from '../../../api/generated/functions';
import { ReportJob, GeneratePickOrderReportRequest } from '../../../api/generated/models';
import { WarehouseService } from '../../../lib/services/warehouse.service';
import { formatLocalYMD } from '../../../lib/utils/format-local-ymd';

export type DatePreset = 'today' | 'yesterday' | 'thisWeek' | 'thisMonth' | 'custom';

@Component({
  selector: 'app-pick-order-reports',
  standalone: true,
  imports: [
    CommonModule, 
    FormsModule, 
    LucideAngularModule, 
    PageHeaderComponent, 
    SearchableSelectComponent
  ],
  templateUrl: './pick-order-reports.component.html'
})
export class PickOrderReportsComponent implements OnInit, OnDestroy {
  readonly FileIcon = FileSpreadsheet;
  readonly DownloadIcon = Download;
  readonly RefreshIcon = RefreshCw;
  readonly AlertIcon = AlertCircle;
  readonly CheckIcon = CheckCircle;
  readonly LoaderIcon = Loader2;
  readonly PlusIcon = Plus;
  readonly CalendarIcon = Calendar;
  readonly FilterIcon = Filter;
  readonly XIcon = X;
  readonly TruckIcon = Truck;

  private api = inject(Api);
  private http = inject(HttpClient);
  private cd = inject(ChangeDetectorRef);
  private toastService = inject(ToastService);
  private warehouseService = inject(WarehouseService);
  private formatLocalYMD = formatLocalYMD;

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

  // Searchable Select States
  selectedShipperOption: SelectOption<string>[] = [];

  // Date Filter Preset State
  activePreset: DatePreset = 'thisMonth';

  reportForm = {
    format: 'Excel' as 'Excel' | 'Csv' | 'Pdf',
    startDate: '',
    endDate: '',
    warehouseId: this.warehouseService.selectedWarehouseId() || null
  };

  ngOnInit(): void {
    this.applyDatePreset('thisMonth');
    this.loadReports();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  // ---------------------------------------------------------------------------
  // Date Presets Helper
  // ---------------------------------------------------------------------------
applyDatePreset(preset: DatePreset): void {
  this.activePreset = preset;
  const now = new Date();
  
  let start = new Date();
  let end = new Date();

  switch (preset) {
    case 'today':
      start = new Date(now.getFullYear(), now.getMonth(), now.getDate());
      end = new Date(now.getFullYear(), now.getMonth(), now.getDate());
      break;

    case 'yesterday':
      start = new Date(now.getFullYear(), now.getMonth(), now.getDate() - 1);
      end = new Date(now.getFullYear(), now.getMonth(), now.getDate() - 1);
      break;

    case 'thisWeek':
      const dayOfWeek = now.getDay(); // 0 is Sunday
      const distanceToMonday = dayOfWeek === 0 ? 6 : dayOfWeek - 1;
      start = new Date(now.getFullYear(), now.getMonth(), now.getDate() - distanceToMonday);
      end = new Date();
      break;

    case 'thisMonth':
      start = new Date(now.getFullYear(), now.getMonth(), 1);
      end = new Date();
      break;

    case 'custom':
      return;
  }

  // Uses local timezone year/month/day
  this.reportForm.startDate = this.formatLocalYMD(start);
  this.reportForm.endDate = this.formatLocalYMD(end);
}

  onManualDateChange(): void {
    this.activePreset = 'custom';
  }

  // ---------------------------------------------------------------------------
  // Searchable Select Function for Shippers
  // ---------------------------------------------------------------------------
  searchShippers = (term: string): Promise<SelectOption<string>[]> => {
    return firstValueFrom(
      getAllShippersFromReceiving(this.http, this.api.rootUrl, {
        warehouseId: this.reportForm.warehouseId || undefined
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
  // Report API Actions
  // ---------------------------------------------------------------------------
  loadReports(isSilent = false): void {
    if (!isSilent) this.isLoading = true;
    this.cd.markForCheck();

    getPickOrderReports(this.http, this.api.rootUrl, {
      page: this.page,
      pageSize: this.pageSize,
      warehouseId: this.warehouseService.selectedWarehouseId()!
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
        if (!isSilent) this.toastService.error('Failed to load pick order reports.');
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

  openGenerateModal(): void {
    this.isModalOpen = true;
    this.selectedShipperOption = [];
    this.applyDatePreset('thisMonth');
  }

  closeGenerateModal(): void {
    this.isModalOpen = false;
  }

  submitGenerateReport(): void {
    this.isGenerating = true;

    const shipperValue = this.selectedShipperOption.length > 0 ? this.selectedShipperOption[0].label : null;

    const payload: GeneratePickOrderReportRequest = {
      format: this.reportForm.format,
      startDate: this.reportForm.startDate ? new Date(this.reportForm.startDate).toISOString() : null,
      endDate: this.reportForm.endDate ? new Date(this.reportForm.endDate).toISOString() : null,
      shipper: shipperValue,
      warehouseId: this.warehouseService.selectedWarehouseId() || null
    };

    generatePickOrderReport(this.http, this.api.rootUrl, { body: payload }).subscribe({
      next: () => {
        this.toastService.success('Pick order report generation job queued.');
        this.isGenerating = false;
        this.closeGenerateModal();
        this.loadReports();
      },
      error: (err) => {
        console.error('Pick order report trigger error:', err);
        this.toastService.error('Failed to trigger pick order report generation.');
        this.isGenerating = false;
        this.cd.markForCheck();
      }
    });
  }

downloadFile(job: ReportJob): void {
  if (job.status !== 'Completed' || !job.id) return;

  const url = `${this.api.rootUrl}/reports/pickorders/download/${job.id}`;

  // Use responseType: 'blob' to keep the raw binary stream intact
  this.http.get(url, { observe: 'response', responseType: 'blob' }).subscribe({
    next: (response: HttpResponse<Blob>) => {
      if (!response.body) {
        this.toastService.error('Received empty file payload.');
        return;
      }

      let fileName = `${job.jobNumber}.xlsx`;
      const contentDisposition = response.headers?.get('Content-Disposition');
      if (contentDisposition) {
        const matches = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/.exec(contentDisposition);
        if (matches != null && matches[1]) {
          fileName = matches[1].replace(/['"]/g, '');
        }
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
    error: (err) => {
      console.error('Download error:', err);
      this.toastService.error('Failed to download report file.');
    }
  });
}

  changePage(newPage: number): void {
    if (newPage < 1 || newPage > this.totalPages) return;
    this.page = newPage;
    this.loadReports();
  }
}