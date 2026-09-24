import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { HttpClient } from "@angular/common/http";
import { ReceivingCreateComponent } from "../receiving/create/receiving-create.component";
import { ChevronLeft, ChevronRight, Download, EyeIcon, LucideAngularModule, PlusIcon, SearchIcon, TrashIcon, Upload } from "lucide-angular";
import { PageHeaderComponent } from "../../shared/layout/page-header/page-header.component";
import { ChangeDetectorRef, Component, effect, EventEmitter, inject, OnInit, Output } from "@angular/core";
import { Subject, takeUntil } from "rxjs";
import { WarehouseService } from "../../lib/services/warehouse.service";
import { SignalRService } from "../../lib/services/signalr.service";
import { IncomingResponseDto, IncomingResponseDtoPaginatedResponse } from "../../api/generated/models";
import { Api } from "../../api/generated/api";
import { deleteIncoming, getIncomings, importIncomingFromExcel } from "../../api/generated/functions";
import { formatDate } from "../../lib/utils/format-date";
import { formatTime } from "../../lib/utils/format-time";
import { ToastService } from "../../lib/services/toast.service";
import { ConfirmDialogComponent } from "../../shared/components/dialog/confirm-dialog.component";

@Component({
  selector: 'app-incoming-list',
  standalone: true,
  imports: [CommonModule, FormsModule, ReceivingCreateComponent, LucideAngularModule, PageHeaderComponent, ConfirmDialogComponent],
  templateUrl: './incoming-list.component.html',
})
export class IncomingListComponent implements OnInit {
  @Output() closed = new EventEmitter<void>();
  Math = Math;
  private api = inject(Api);
  private http = inject(HttpClient);
  private cd = inject(ChangeDetectorRef);
  public warehouseService = inject(WarehouseService);
  private signalRService = inject(SignalRService);
  private toastService = inject(ToastService);
  public formatDate = formatDate;
  public formatTime = formatTime;

  readonly chevronLeft = ChevronLeft;
  readonly chevronRight = ChevronRight;
  readonly eyeIcon = EyeIcon;
  readonly searchIcon = SearchIcon;
  readonly plus = PlusIcon;
  readonly downloadIcon = Download;
  readonly uploadIcon = Upload;
  readonly trashIcon = TrashIcon;

  private destroy$ = new Subject<void>();

  incomings: IncomingResponseDto[] = [];
  isLoading = true;
  isImporting = false;
  isDownloadingTemplate = false;
  error = '';
  search = '';
  page = 1;
  pageSize = 10;
  totalCount = 0;
  totalPages = 0;

  constructor() {
    effect(() => {
      this.warehouseService.selectedWarehouseId();
      this.page = 1;
      void this.loadIncomings();
    });
  }

  ngOnInit(): void {
    void this.loadIncomings();
    this.signalRService.receivingUpdated$
      .pipe(takeUntil(this.destroy$))
      .subscribe(() => {
        void this.loadIncomings();
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  close(): void {
    this.closed.emit();
  }

  // Drawer & Modal states
  isViewOpen = false;
  isCreateOpen = false;
  isErrorModalOpen = false;
  importErrors: string[] = [];
  selectedIncoming: IncomingResponseDto | null = null;

  isConfirmDeleteOpen = false;
  itemToDeleteId: number | null = null;
  isDeleting = false;

  // Opens dialog and captures ID
  confirmDelete(id: number): void {
    this.itemToDeleteId = id;
    this.isConfirmDeleteOpen = true;
  }

  cancelDelete(): void {
    this.isConfirmDeleteOpen = false;
    this.itemToDeleteId = null;
  }


  async loadIncomings(): Promise<void> {
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
      const response = await this.api.invoke(getIncomings, params) as IncomingResponseDtoPaginatedResponse;
      this.incomings = response.items ?? [];
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

  // --- EXCEL TEMPLATE DOWNLOAD ---
  downloadTemplate(): void {
    this.isDownloadingTemplate = true;
    this.cd.markForCheck();

    this.http.get(`${this.api.rootUrl}/incoming-template/template`, { responseType: 'blob' }).subscribe({
      next: (blob: Blob) => {
        const url = window.URL.createObjectURL(blob);
        const anchor = document.createElement('a');
        anchor.href = url;
        anchor.download = 'Incoming_Packing_List_Template.xlsx';
        anchor.click();
        window.URL.revokeObjectURL(url);
        this.isDownloadingTemplate = false;
        this.cd.markForCheck();
      },
      error: (err) => {
        console.error('Failed to download template:', err);
        this.error = 'Failed to download the Excel template. Please try again.';
        this.isDownloadingTemplate = false;
        this.cd.markForCheck();
      }
    });
  }

  // --- EXCEL IMPORT LOGIC & VALIDATION ---
  triggerFileInput(fileInput: HTMLInputElement): void {
    fileInput.click();
  }

  async onFileSelected(event: Event, fileInput: HTMLInputElement): Promise<void> {
    const target = event.target as HTMLInputElement;
    const file = target.files?.[0];
    if (!file) return;

    this.importErrors = [];

    // 1. Frontend Pre-flight Validations
    const warehouseId = this.warehouseService.selectedWarehouseId();
    if (!warehouseId) {
      this.showImportErrors(['Please select a active warehouse before importing.']);
      fileInput.value = '';
      return;
    }

    const validExtensions = ['.xlsx', '.xls'];
    const fileName = file.name.toLowerCase();
    const isValidExtension = validExtensions.some(ext => fileName.endsWith(ext));

    if (!isValidExtension) {
      this.showImportErrors(['Invalid file extension. Please upload an Excel packing list (.xlsx or .xls).']);
      fileInput.value = '';
      return;
    }

    const maxSizeBytes = 10 * 1024 * 1024; // 10MB
    if (file.size > maxSizeBytes) {
      this.showImportErrors(['File size exceeds the 10MB limit.']);
      fileInput.value = '';
      return;
    }

    // 2. Perform File Upload
    this.isImporting = true;
    this.cd.markForCheck();

    const formData = new FormData();
    formData.append('file', file);

    try {
        await this.api.invoke(importIncomingFromExcel, {
            warehouseId,
            body: {
            file: file // File extends Blob in TypeScript/JavaScript
            }
        });

      // Success
      fileInput.value = '';
      await this.loadIncomings();
      this.toastService.success("Incoming Imported successfully")
    } catch (err: any) {
      fileInput.value = '';
      let errorMessages: string[] = [];

      if (err.status === 422 || err.status === 400) {
        if (err.error?.errors && Array.isArray(err.error.errors)) {
          errorMessages = err.error.errors;
        } else if (typeof err.error === 'string') {
          errorMessages = [err.error];
        } else if (err.error?.message) {
          errorMessages = [err.error.message];
        } else {
          errorMessages = ['The uploaded Excel file contained invalid data or mismatched columns.'];
        }
      } else {
        errorMessages = ['An unexpected error occurred while processing the file. Please verify the template.'];
      }

      this.showImportErrors(errorMessages);
    } finally {
      this.isImporting = false;
      this.cd.markForCheck();
    }
  }

  showImportErrors(errors: string[]): void {
    this.importErrors = errors;
    this.isErrorModalOpen = true;
    this.cd.markForCheck();
  }

  closeErrorModal(): void {
    this.isErrorModalOpen = false;
    this.importErrors = [];
  }

  openView(incoming: IncomingResponseDto): void {
    this.selectedIncoming = incoming;
    this.isViewOpen = true;
  }

// Executes actual deletion when confirmed
  async handleExecuteDelete(): Promise<void> {
    if (!this.itemToDeleteId) return;

    this.isDeleting = true;
    this.error = '';
    this.cd.markForCheck();

    try {
      await this.api.invoke(deleteIncoming, { id: this.itemToDeleteId });
      this.toastService.success(`Incoming with id ${this.itemToDeleteId} deleted successfuly`)
      this.isConfirmDeleteOpen = false;
      this.itemToDeleteId = null;
      await this.loadIncomings();
    } catch (err) {
      console.error('Failed to delete incoming shipment:', err);
      this.toastService.error(`Unable to delete incoming transaction #${this.itemToDeleteId}.`)
      this.error = `Unable to delete incoming transaction #${this.itemToDeleteId}.`;
    } finally {
      this.isDeleting = false;
      this.cd.markForCheck();
    }
  }

  closeView(): void {
    this.isViewOpen = false;
    this.selectedIncoming = null;
  }

  openCreate(): void {
    this.isCreateOpen = true;
  }

  closeCreate(): void {
    this.isCreateOpen = false;
  }

  onSearch(): void {
    this.page = 1;
    void this.loadIncomings();
  }

  goToPage(nextPage: number): void {
    this.page = Math.max(1, Math.min(nextPage, this.totalPages || 1));
    void this.loadIncomings();
  }

  changePageSize(event: Event): void {
    this.pageSize = Number((event.target as HTMLSelectElement).value);
    this.page = 1;
    void this.loadIncomings();
  }

  getStatusColorClass(status: 'PENDING' | 'RECEIVED' | 'CANCELLED' | undefined): string {
    switch (status) {
        case 'PENDING':
        return 'bg-amber-50 text-amber-700 border-amber-200';
        case 'RECEIVED':
        return 'bg-emerald-50 text-emerald-700 border-emerald-200';
        case 'CANCELLED':
        return 'bg-rose-50 text-rose-700 border-rose-200';
        default:
        return 'bg-emerald-100 text-slate-700 border-slate-200';
    }
    }
}