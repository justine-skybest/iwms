import { Component, OnInit, inject, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { finalize } from 'rxjs/operators';
import { environment } from '../../lib/config/app-env';

// Generated OpenAPI Imports
import { AuditLog, AuditLogPagedResponseDto } from '../../api/generated/models';
import {
  apiAuditLogsGet,
  apiAuditLogsIdGet,
  apiAuditLogsEntityNamesGet
} from '../../api/generated/functions';
import { PageHeaderComponent } from '../../shared/layout/page-header/page-header.component';

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

  // Data State
  logs: AuditLog[] = [];
  entityNames: string[] = [];
  totalCount = 0;
  totalPages = 0;
  page = 1;
  pageSize = 20;
  loading = false;

  // Filter State
  search = '';
  selectedEntity = '';
  selectedAction = '';
  userEmail = '';
  fromDate = '';
  toDate = '';

  // Detail Modal State
  selectedLog: AuditLog | null = null;
  isDetailOpen = false;
  loadingDetail = false;
  parsedOldValues: any = null;
  parsedNewValues: any = null;

  ngOnInit(): void {
    this.loadEntityNames();
    this.loadLogs();
  }

  loadEntityNames(): void {
    apiAuditLogsEntityNamesGet(this.http, this.apiUrl).subscribe({
      next: (res) => {
        this.entityNames = res.body || [];
        this.cdr.detectChanges();
      },
      error: (err) => console.error('Failed to load entity names:', err)
    });
  }

  loadLogs(resetPage = false): void {
    if (resetPage) {
      this.page = 1;
    }

    this.loading = true;

    apiAuditLogsGet(this.http, this.apiUrl, {
      search: this.search?.trim() || undefined,
      entityName: this.selectedEntity || undefined,
      action: this.selectedAction || undefined,
      userEmail: this.userEmail?.trim() || undefined,
      fromDate: this.toSafeIsoDate(this.fromDate),
      toDate: this.toSafeIsoDate(this.toDate),
      page: this.page,
      pageSize: this.pageSize
    })
    .pipe(
      finalize(() => {
        // ALWAYS executes when observable completes or errors out
        this.loading = false;
        this.cdr.detectChanges();
      })
    )
    .subscribe({
      next: (res) => {
        const data = (res.body || {}) as any;
        
        // Support both camelCase and PascalCase JSON responses
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

  openDetail(logId: string): void {
    this.isDetailOpen = true;
    this.loadingDetail = true;
    this.parsedOldValues = null;
    this.parsedNewValues = null;

    apiAuditLogsIdGet(this.http, this.apiUrl, { id: logId })
      .pipe(
        finalize(() => {
          this.loadingDetail = false;
          this.cdr.detectChanges();
        })
      )
      .subscribe({
        next: (res) => {
          this.selectedLog = res.body || null;

          if (this.selectedLog?.oldValues) {
            try {
              this.parsedOldValues = JSON.parse(this.selectedLog.oldValues);
            } catch {
              this.parsedOldValues = this.selectedLog.oldValues;
            }
          }

          if (this.selectedLog?.newValues) {
            try {
              this.parsedNewValues = JSON.parse(this.selectedLog.newValues);
            } catch {
              this.parsedNewValues = this.selectedLog.newValues;
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
    this.selectedEntity = '';
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

  getActionBadgeClass(action?: string | null): string {
    const act = (action || '').toUpperCase();
    switch (act) {
      case 'ADDED':
      case 'POST':
        return 'bg-emerald-50 text-emerald-700 border-emerald-200';
      case 'MODIFIED':
      case 'PUT':
      case 'PATCH':
        return 'bg-blue-50 text-blue-700 border-blue-200';
      case 'DELETED':
      case 'DELETE':
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