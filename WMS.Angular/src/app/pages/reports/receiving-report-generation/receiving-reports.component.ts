import { Component, OnInit, OnDestroy, inject, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Subject, Subscription, timer, firstValueFrom } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Api } from '../../../api/generated/api';
import { LucideAngularModule, FileSpreadsheet, Download, RefreshCw, AlertCircle, CheckCircle, Loader2, Plus, Calendar, Filter, X } from 'lucide-angular';
import { ToastService } from '../../../lib/services/toast.service';
import { formatDate } from '../../../lib/utils/format-date';
import { PageHeaderComponent } from '../../../shared/layout/page-header/page-header.component';
import { SearchableSelectComponent, SelectOption } from '../../../shared/components/select/select.component';
import { getIncomings, getPalletsV2 } from '../../../api/generated/functions';

export enum ReportFormat {
  Excel = 'Excel',
  Pdf = 'Pdf',
  Csv = 'Csv'
}

@Component({
  selector: 'app-receiving-reports',
  standalone: true,
  imports: [
    CommonModule, 
    FormsModule, 
    LucideAngularModule, 
    PageHeaderComponent, 
    SearchableSelectComponent // 👈 Registered SearchableSelectComponent
  ],
  templateUrl: './receiving-reports.component.html'
})
export class ReceivingReportsComponent implements OnInit, OnDestroy {
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

  private api = inject(Api);
  private http = inject(HttpClient);
  private cd = inject(ChangeDetectorRef);
  private toastService = inject(ToastService);

  public formatDate = formatDate;
  public Math = Math;

  reports: any[] = [];
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
  selectedIncoming: SelectOption<any>[] = [];
  selectedPallet: SelectOption<any>[] = [];

  reportForm = {
    format: ReportFormat.Excel,
    startDate: '',
    endDate: '',
    plateNumber: ''
  };

  ngOnInit(): void {
    this.setDefaultDates();
    this.loadReports();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  setDefaultDates(): void {
    const today = new Date();
    const firstDay = new Date(today.getFullYear(), today.getMonth(), 1);
    this.reportForm.endDate = today.toISOString().split('T')[0];
    this.reportForm.startDate = firstDay.toISOString().split('T')[0];
  }

  // 🔍 Searchable Select Function for Incomings
  searchIncomings = (term: string): Promise<SelectOption<any>[]> => {
    return firstValueFrom(
      getIncomings(this.http, this.api.rootUrl, { search: term, pageSize: 20 })
    ).then((res) => {
      const items = res.body?.items || [];
      return items.map((inc: any) => ({
        id: inc.id,
        label: inc.shipper ? `${inc.shipper} (ID #${inc.id})` : `Incoming #${inc.id}`,
        sublabel: `Shipper: ${inc.shipper || 'N/A'} • Status: ${inc.status || 'PENDING'}`,
        raw: inc
      }));
    });
  };

  // 🔍 Searchable Select Function for Pallets
  searchPallets = (term: string): Promise<SelectOption<any>[]> => {
    return firstValueFrom(
      getPalletsV2(this.http, this.api.rootUrl, { search: term, pageSize: 20 })
    ).then((res) => {
      const items = res.body?.items || [];
      return items.map((pallet: any) => ({
        id: pallet.id,
        label: pallet.palletNumber ? `PAL-${pallet.palletNumber}` : `Pallet #${pallet.id}`,
        sublabel: pallet.binName ? `Location: ${pallet.binName}` : null,
        raw: pallet
      }));
    });
  };

  loadReports(isSilent = false): void {
    if (!isSilent) this.isLoading = true;
    this.cd.markForCheck();

    const url = `${this.api.rootUrl}/reports/receiving?page=${this.page}&pageSize=${this.pageSize}`;

    this.http.get<any>(url).subscribe({
      next: (res) => {
        this.reports = res.items || res.Items || [];
        this.totalCount = res.totalCount ?? res.TotalCount ?? 0;
        this.totalPages = res.totalPages ?? res.TotalPages ?? 1;
        this.isLoading = false;
        this.checkAndStartPolling();
        this.cd.markForCheck();
      },
      error: () => {
        if (!isSilent) this.toastService.error('Failed to load receiving reports.');
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
    this.selectedIncoming = [];
    this.selectedPallet = [];
    this.reportForm.plateNumber = '';
    this.setDefaultDates();
  }

  closeGenerateModal(): void {
    this.isModalOpen = false;
  }

  submitGenerateReport(): void {
    if (!this.selectedIncoming || this.selectedIncoming.length === 0) {
      this.toastService.error('Please select a target Incoming shipment.');
      return;
    }
    
    this.isGenerating = true;
    const url = `${this.api.rootUrl}/reports/generate-receiving-report`;

    const incomingId = this.selectedIncoming.length > 0 ? this.selectedIncoming[0].id : null;
    const palletNumber = this.selectedPallet.length > 0 ? this.selectedPallet[0].label.replace('PAL-', '') : null;

    const payload = {
      incomingId: incomingId,
      startDate: this.reportForm.startDate ? new Date(this.reportForm.startDate).toISOString() : null,
      endDate: this.reportForm.endDate ? new Date(this.reportForm.endDate).toISOString() : null,
      palletNumber: palletNumber || null,
      plateNumber: this.reportForm.plateNumber || null
    };

    this.http.post(url, payload).subscribe({
      next: () => {
        this.toastService.success('Report generation job queued successfully.');
        this.isGenerating = false;
        this.closeGenerateModal();
        this.loadReports();
      },
      error: (err) => {
        console.error('Report trigger error:', err);
        this.toastService.error('Failed to trigger report generation.');
        this.isGenerating = false;
        this.cd.markForCheck();
      }
    });
  }

  downloadFile(job: any): void {
    if (job.status !== 'Completed') return;

    const url = `${this.api.rootUrl}/reports/receiving/download/${job.id}`;

    this.http.get(url, { observe: 'response' as const, responseType: 'blob' as const }).subscribe({
      next: (response: HttpResponse<Blob>) => {
        let fileName = `${job.jobNumber}.xlsx`;
        const contentDisposition = response.headers.get('Content-Disposition');
        if (contentDisposition) {
          const matches = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/.exec(contentDisposition);
          if (matches != null && matches[1]) fileName = matches[1].replace(/['"]/g, '');
        }

        const blob = new Blob([response.body as Blob]);
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