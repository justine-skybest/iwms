import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { HttpClient } from "@angular/common/http";
import { 
  AlertTriangle, 
  CheckCircle, 
  ChevronLeft, 
  ChevronRight, 
  Download, 
  EyeIcon, 
  FileText, 
  FileUp, 
  LucideAngularModule, 
  PlusIcon, 
  SearchIcon, 
  TrashIcon, 
  Upload 
} from "lucide-angular";
import { PageHeaderComponent } from "../../shared/layout/page-header/page-header.component";
import { ChangeDetectorRef, Component, effect, EventEmitter, inject, OnDestroy, OnInit, Output } from "@angular/core";
import { Subject, takeUntil } from "rxjs";
import { WarehouseService } from "../../lib/services/warehouse.service";
import { SignalRService } from "../../lib/services/signalr.service";
import { IncomingDocumentResponseDto, IncomingProductResponseDto, IncomingResponseDto, IncomingResponseDtoPaginatedResponse } from "../../api/generated/models";
import { Api } from "../../api/generated/api";
import { deleteIncoming, downloadIncomingDocument, getIncomings, importIncomingFromExcel, reviseIncomingFromExcel, shortCloseIncoming } from "../../api/generated/functions";
import { formatDate } from "../../lib/utils/format-date";
import { formatTime } from "../../lib/utils/format-time";
import { ToastService } from "../../lib/services/toast.service";
import { ConfirmDialogComponent } from "../../shared/components/dialog/confirm-dialog.component";

@Component({
  selector: 'app-incoming-list',
  standalone: true,
  imports: [
    CommonModule, 
    FormsModule, 
    LucideAngularModule, 
    PageHeaderComponent, 
    ConfirmDialogComponent
  ],
  templateUrl: './incoming-list.component.html',
})
export class IncomingListComponent implements OnInit, OnDestroy {
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
  readonly fileUpIcon = FileUp;
  readonly alertIcon = AlertTriangle;
  readonly checkCircleIcon = CheckCircle;
  readonly fileTextIcon = FileText;

  private destroy$ = new Subject<void>();

  incomings: IncomingResponseDto[] = [];
  selectedIncoming: IncomingResponseDto | null = null;

  isLoading = true;
  isImporting = false;
  isRevising = false;
  revisingIncomingId: number | null = null;
  isDownloadingTemplate = false;
  error = '';
  search = '';
  page = 1;
  pageSize = 10;
  totalCount = 0;
  totalPages = 0;

  // Drawer & Modal states
  isViewOpen = false;
  isCreateOpen = false;
  isErrorModalOpen = false;
  importErrors: string[] = [];

  isConfirmShortCloseOpen = false;
  isShortClosing = false;
  itemToShortClose: IncomingResponseDto | null = null;
  shortCloseMessage = '';

  isConfirmDeleteOpen = false;
  itemToDeleteId: number | null = null;
  isDeleting = false;

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

  async handleExecuteShortClose(): Promise<void> {
    if (!this.itemToShortClose?.id) return;

    const targetId = this.itemToShortClose.id;
    this.isShortClosing = true;
    this.error = '';
    this.cd.markForCheck();

    try {
      await this.api.invoke(shortCloseIncoming, { id: targetId });
      this.toastService.success(`Incoming shipment #${targetId} short-closed successfully.`);

      if (this.itemToShortClose) {
        this.itemToShortClose.status = 'CLOSED_SHORT' as any;
      }
      if (this.selectedIncoming && this.selectedIncoming.id === targetId) {
        this.selectedIncoming.status = 'CLOSED_SHORT' as any;
      }

      this.cancelShortClose();
      await this.loadIncomings();
    } catch (err: any) {
      console.error('Failed to short-close incoming shipment:', err);
      const msg = err.error?.message || err.message || 'Failed to short-close incoming shipment.';
      this.toastService.error(msg);
      this.error = msg;
    } finally {
      this.isShortClosing = false;
      this.cd.markForCheck();
    }
  }

  confirmShortClose(incoming: IncomingResponseDto): void {
    if (!incoming.id) return;

    const totalRemaining = (incoming.products || [])
      .reduce((sum, p) => sum + (p.remainingQuantity ?? 0), 0);

    this.itemToShortClose = incoming;
    this.shortCloseMessage = `Are you sure you want to SHORT-CLOSE Incoming Shipment #${incoming.id}? ` +
      `The remaining balance of ${totalRemaining} unit(s) will be permanently recorded as lost/unfulfilled and removed from active picklists.`;
    
    this.isConfirmShortCloseOpen = true;
    this.cd.markForCheck();
  }

  cancelShortClose(): void {
    this.isConfirmShortCloseOpen = false;
    this.itemToShortClose = null;
    this.shortCloseMessage = '';
    this.cd.markForCheck();
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

  // --- EXCEL IMPORT LOGIC ---
  triggerFileInput(fileInput: HTMLInputElement): void {
    fileInput.click();
  }

  async onFileSelected(event: Event, fileInput: HTMLInputElement): Promise<void> {
    const target = event.target as HTMLInputElement;
    const file = target.files?.[0];
    if (!file) return;

    this.importErrors = [];

    const warehouseId = this.warehouseService.selectedWarehouseId();
    if (!warehouseId) {
      this.showImportErrors(['Please select an active warehouse before importing.']);
      fileInput.value = '';
      return;
    }

    if (!this.isValidExcelFile(file, fileInput)) return;

    this.isImporting = true;
    this.cd.markForCheck();

    try {
      await this.api.invoke(importIncomingFromExcel, {
        warehouseId,
        body: { file }
      });

      fileInput.value = '';
      await this.loadIncomings();
      this.toastService.success("Incoming imported successfully");
    } catch (err: any) {
      fileInput.value = '';
      const errorMessages = this.extractErrorMessages(err, 'The uploaded Excel file contained invalid data or mismatched columns.');
      this.showImportErrors(errorMessages);
    } finally {
      this.isImporting = false;
      this.cd.markForCheck();
    }
  }

  // --- EXCEL REVISION LOGIC ---
  triggerRevisionInput(fileInput: HTMLInputElement, incomingId: number): void {
    this.revisingIncomingId = incomingId;
    fileInput.click();
  }

  async onRevisionFileSelected(event: Event, fileInput: HTMLInputElement): Promise<void> {
    const target = event.target as HTMLInputElement;
    const file = target.files?.[0];

    if (!file || !this.revisingIncomingId) {
      fileInput.value = '';
      this.revisingIncomingId = null;
      return;
    }

    const targetId = this.revisingIncomingId;
    this.importErrors = [];

    if (!this.isValidExcelFile(file, fileInput)) {
      this.revisingIncomingId = null;
      return;
    }

    this.isRevising = true;
    this.cd.markForCheck();

    try {
      await this.api.invoke(reviseIncomingFromExcel, {
        incomingId: targetId,
        body: { file }
      });

      fileInput.value = '';
      this.revisingIncomingId = null;
      await this.loadIncomings();
      this.toastService.success(`Incoming transaction #${targetId} revised successfully.`);
    } catch (err: any) {
      fileInput.value = '';
      const errorMessages = this.extractErrorMessages(err, 'An unexpected error occurred while processing the revision file.');
      this.showImportErrors(errorMessages);
    } finally {
      this.isRevising = false;
      this.revisingIncomingId = null;
      this.cd.markForCheck();
    }
  }

productSearch = '';

// Add a getter to dynamically filter products by code, name, supplier, or remarks
get filteredProducts(): IncomingProductResponseDto[] {
  if (!this.selectedIncoming?.products) return [];
  const query = this.productSearch.trim().toLowerCase();
  if (!query) return this.selectedIncoming.products;

  return this.selectedIncoming.products.filter(p =>
    (p.productName && p.productName.toLowerCase().includes(query)) ||
    (p.code && p.code.toLowerCase().includes(query)) ||
    (p.supplier && p.supplier.toLowerCase().includes(query)) ||
    (p.remarks && p.remarks.toLowerCase().includes(query))
  );
}

  downloadingDocId: number | null = null;
  
downloadDocument(doc: IncomingDocumentResponseDto): void {
    if (!doc?.id || !doc?.incomingId) return;

    const docId = doc.id;
    const incomingId = doc.incomingId;

    this.downloadingDocId = docId;
    this.cd.markForCheck();

    // Dynamically replace the route parameters using the generated API PATH
    const path = downloadIncomingDocument.PATH
      .replace('{incomingId}', incomingId.toString())
      .replace('{documentId}', docId.toString());

    const url = `${this.api.rootUrl}${path}`;

    this.http.get(url, { responseType: 'blob' }).subscribe({
      next: (blob: Blob) => {
        const blobUrl = window.URL.createObjectURL(blob);
        const anchor = document.createElement('a');
        anchor.href = blobUrl;
        anchor.download = doc.originalFileName || `PackingList_v${doc.version || docId}.xlsx`;
        anchor.click();
        window.URL.revokeObjectURL(blobUrl);

        this.downloadingDocId = null;
        this.cd.markForCheck();
      },
      error: (err) => {
        console.error('Failed to download document:', err);
        this.toastService.error('Unable to download the selected document version.');
        this.downloadingDocId = null;
        this.cd.markForCheck();
      }
    });
  }

  // --- HELPER METHODS ---
  formatFileSize(bytes?: number): string {
    if (!bytes || bytes === 0) return '0 B';
    const k = 1024;
    const sizes = ['B', 'KB', 'MB', 'GB'];
    const i = Math.floor(Math.log(bytes) / Math.log(k));
    return parseFloat((bytes / Math.pow(k, i)).toFixed(1)) + ' ' + sizes[i];
  }

  private isValidExcelFile(file: File, fileInput: HTMLInputElement): boolean {
    const validExtensions = ['.xlsx', '.xls'];
    const fileName = file.name.toLowerCase();
    const isValidExtension = validExtensions.some(ext => fileName.endsWith(ext));

    if (!isValidExtension) {
      this.showImportErrors(['Invalid file extension. Please upload an Excel packing list (.xlsx or .xls).']);
      fileInput.value = '';
      return false;
    }

    const maxSizeBytes = 10 * 1024 * 1024; // 10MB
    if (file.size > maxSizeBytes) {
      this.showImportErrors(['File size exceeds the 10MB limit.']);
      fileInput.value = '';
      return false;
    }

    return true;
  }

  private extractErrorMessages(err: any, fallbackMessage: string): string[] {
    if (err.status === 422 || err.status === 400) {
      const errors = err.error?.errors || err.error?.Errors;
      if (Array.isArray(errors) && errors.length > 0) {
        return errors;
      }
      if (typeof err.error === 'string') {
        return [err.error];
      }
      if (err.error?.message) {
        return [err.error.message];
      }
    }
    return [fallbackMessage];
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
    this.productSearch = '';
    this.selectedIncoming = incoming;
    this.isViewOpen = true;
  }

  async handleExecuteDelete(): Promise<void> {
    if (!this.itemToDeleteId) return;

    this.isDeleting = true;
    this.error = '';
    this.cd.markForCheck();

    try {
      await this.api.invoke(deleteIncoming, { id: this.itemToDeleteId });
      this.toastService.success(`Incoming with id ${this.itemToDeleteId} deleted successfully`);
      this.isConfirmDeleteOpen = false;
      this.itemToDeleteId = null;
      await this.loadIncomings();
    } catch (err) {
      console.error('Failed to delete incoming shipment:', err);
      this.toastService.error(`Unable to delete incoming transaction #${this.itemToDeleteId}.`);
      this.error = `Unable to delete incoming transaction #${this.itemToDeleteId}.`;
    } finally {
      this.isDeleting = false;
      this.cd.markForCheck();
    }
  }

  closeView(): void {
    this.productSearch = '';
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

  getStatusColorClass(status: 'PENDING' | 'PARTIAL' | 'RECEIVED' | 'CANCELLED' | 'CLOSED_SHORT' | string | undefined): string {
    switch (status) {
      case 'PENDING':
        return 'bg-amber-50 text-amber-700 border-amber-200';
      case 'PARTIAL':
        return 'bg-blue-50 text-blue-700 border-blue-200';
      case 'RECEIVED':
        return 'bg-emerald-50 text-emerald-700 border-emerald-200';
      case 'CLOSED_SHORT':
        return 'bg-purple-50 text-purple-700 border-purple-200';
      case 'CANCELLED':
        return 'bg-rose-50 text-rose-700 border-rose-200';
      default:
        return 'bg-slate-100 text-slate-700 border-slate-200';
    }
  }

  getItemStatusBadgeClass(status?: 'UNRECEIVED' | 'PARTIAL' | 'RECEIVED' | 'CLOSED_SHORT' | string): string {
    switch (status) {
      case 'RECEIVED':
        return 'bg-emerald-100 text-emerald-800 border-emerald-300';
      case 'PARTIAL':
        return 'bg-blue-100 text-blue-800 border-blue-300';
      case 'CLOSED_SHORT':
        return 'bg-purple-100 text-purple-800 border-purple-300';
      case 'UNRECEIVED':
      default:
        return 'bg-slate-100 text-slate-600 border-slate-200';
    }
  }
}