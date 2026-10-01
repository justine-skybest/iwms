import { Component, OnInit, inject, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { finalize } from 'rxjs/operators';
import { environment } from '../../lib/config/app-env';

export interface AuditLogItem {
  id?: string;
  traceId?: string | null;
  userId?: string | null;
  userEmail?: string | null;
  userRole?: string | null;
  ipAddress?: string | null;
  category?: string;
  action?: string;
  description?: string;
  detailsJson?: string | null;
  timestamp?: string;
  statusCode?: number;
}

import {
  apiAuditLogsGet,
  apiAuditLogsIdGet,
  apiAuditLogsCategoriesGet
} from '../../api/generated/functions';
import { PageHeaderComponent } from '../../shared/layout/page-header/page-header.component';
import { formatPhilippineTime } from '../../lib/utils/format-ph-time';

@Component({
  selector: 'app-audit-logs',
  standalone: true,
  imports: [CommonModule, FormsModule, PageHeaderComponent],
  templateUrl: './audit-logs.component.html'
})
export class AuditLogsComponent implements OnInit {
  private http = inject(HttpClient);
  private cdr = inject(ChangeDetectorRef);
  private readonly apiUrl = environment.apiUrl || '';

  public formatPhTime = formatPhilippineTime;

  // Data State
  logs: AuditLogItem[] = [];
  categories: string[] = [];
  totalCount = 0;
  totalPages = 0;
  page = 1;
  pageSize = 20;
  loading = false;

  // Filter State
  search = '';
  selectedCategory = '';
  selectedAction = '';
  userEmail = '';
  fromDate = '';
  toDate = '';

  // Detail Modal State
  selectedLog: AuditLogItem | null = null;
  isDetailOpen = false;
  loadingDetail = false;
  parsedDetails: any = null;

  ngOnInit(): void {
    this.loadCategories();
    this.loadLogs();
  }

  loadCategories(): void {
    apiAuditLogsCategoriesGet(this.http, this.apiUrl).subscribe({
      next: (res) => {
        this.categories = res.body || [];
        this.cdr.detectChanges();
      },
      error: (err) => console.error('Failed to load categories:', err)
    });
  }

  loadLogs(resetPage = false): void {
    if (resetPage) {
      this.page = 1;
    }

    this.loading = true;

    apiAuditLogsGet(this.http, this.apiUrl, {
      search: this.search?.trim() || undefined,
      category: this.selectedCategory || undefined,
      action: this.selectedAction || undefined,
      userEmail: this.userEmail?.trim() || undefined,
      fromDate: this.toSafeIsoDate(this.fromDate),
      toDate: this.toSafeIsoDate(this.toDate),
      page: this.page,
      pageSize: this.pageSize
    } as any)
    .pipe(
      finalize(() => {
        this.loading = false;
        this.cdr.detectChanges();
      })
    )
    .subscribe({
      next: (res) => {
        const data = (res.body || {}) as any;
        
        this.logs = data.items || data.Items || [];
        this.totalCount = data.totalCount ?? data.TotalCount ?? 0;
        this.totalPages = data.totalPages ?? data.TotalPages ?? 0;
      },
      error: (err) => {
        console.error('Failed to load audit logs:', err);
        this.logs = [];
        this.totalCount = 0;
        this.totalPages = 0;
      }
    });
  }

  filterByTraceId(traceId?: string | null): void {
    if (!traceId) return;
    this.search = traceId;
    this.loadLogs(true);
  }

  openDetail(logId: string): void {
    this.isDetailOpen = true;
    this.loadingDetail = true;
    this.parsedDetails = null;

    apiAuditLogsIdGet(this.http, this.apiUrl, { id: logId })
      .pipe(
        finalize(() => {
          this.loadingDetail = false;
          this.cdr.detectChanges();
        })
      )
      .subscribe({
        next: (res) => {
          this.selectedLog = (res.body || null) as AuditLogItem;

          if (this.selectedLog?.detailsJson) {
            try {
              this.parsedDetails = JSON.parse(this.selectedLog.detailsJson);
            } catch {
              this.parsedDetails = this.selectedLog.detailsJson;
            }
          }
        },
        error: (err) => {
          console.error('Failed to fetch log details:', err);
        }
      });
  }

  closeDetail(): void {
    this.isDetailOpen = false;
    this.selectedLog = null;
  }

  resetFilters(): void {
    this.search = '';
    this.selectedCategory = '';
    this.selectedAction = '';
    this.userEmail = '';
    this.fromDate = '';
    this.toDate = '';
    this.loadLogs(true);
  }

  onPageChange(newPage: number): void {
    if (newPage >= 1 && newPage <= this.totalPages) {
      this.page = newPage;
      this.loadLogs();
    }
  }

  // --- DYNAMIC NON-JSON FORMATTING HELPERS ---

  isPrimitive(val: any): boolean {
    return val === null || val === undefined || typeof val !== 'object';
  }

  getDetailProperties(details: any): { key: string; label: string; value: any }[] {
    if (!details || typeof details !== 'object' || Array.isArray(details)) return [];
    return Object.keys(details)
      .filter(key => !Array.isArray(details[key]) && (details[key] === null || typeof details[key] !== 'object'))
      .map(key => ({
        key,
        label: this.formatLabel(key),
        value: details[key]
      }));
  }

  getDetailArrays(details: any): { key: string; label: string; items: any[] }[] {
    if (!details || typeof details !== 'object' || Array.isArray(details)) return [];
    return Object.keys(details)
      .filter(key => Array.isArray(details[key]) && details[key].length > 0)
      .map(key => ({
        key,
        label: this.formatLabel(key),
        items: details[key]
      }));
  }

  getItemHeaders(items: any[]): string[] {
    if (!items || items.length === 0) return [];
    const headersSet = new Set<string>();
    items.forEach(item => {
      if (item && typeof item === 'object') {
        Object.keys(item).forEach(k => headersSet.add(k));
      }
    });
    return Array.from(headersSet);
  }

  formatLabel(key: string): string {
    if (!key) return '';
    return key
      .replace(/([A-Z])/g, ' $1')
      .replace(/^./, str => str.toUpperCase())
      .trim();
  }

  getActionBadgeClass(action?: string | null): string {
    const act = (action || '').toUpperCase();
    switch (act) {
      case 'CREATED':
      case 'REGISTER':
      case 'ADDED':
        return 'bg-emerald-50 text-emerald-700 border-emerald-200';
      case 'LOGIN':
      case 'EXCELIMPORT':
      case 'UPDATED':
        return 'bg-blue-50 text-blue-700 border-blue-200';
      case 'DELETED':
        return 'bg-rose-50 text-rose-700 border-rose-200';
      default:
        return 'bg-slate-100 text-slate-700 border-slate-200';
    }
  }

  getStatusBadgeClass(code?: number): string {
    if (!code) return 'bg-slate-100 text-slate-600';
    if (code >= 200 && code < 300) return 'bg-emerald-100 text-emerald-800';
    if (code >= 400 && code < 500) return 'bg-amber-100 text-amber-800';
    return 'bg-rose-100 text-rose-800';
  }

  private toSafeIsoDate(dateString: string): string | undefined {
    if (!dateString || !dateString.trim()) return undefined;
    try {
      const date = new Date(dateString);
      return isNaN(date.getTime()) ? undefined : date.toISOString();
    } catch {
      return undefined;
    }
  }
}