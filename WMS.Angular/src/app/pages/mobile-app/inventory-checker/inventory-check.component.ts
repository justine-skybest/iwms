import {
  Component,
  EventEmitter,
  Input,
  Output,
  OnChanges,
  SimpleChanges,
  inject,
  ChangeDetectorRef,
  ChangeDetectionStrategy,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Api } from '../../../api/generated/api';
import { inspectInventoryCode } from '../../../api/generated/functions';
import {
  InventoryInspectionResultDto,
  InventoryCheckItemDto,
} from '../../../api/generated/models';
import { WarehouseService } from '../../../lib/services/warehouse.service';
import { ToastService } from '../../../lib/services/toast.service';
import { IconComponent } from '../../../shared/components/icon/icon.component';
import { QrScannerComponent } from '../../../shared/components/qr-scanner/qr-scanner.component';

@Component({
  selector: 'app-inventory-check-modal',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    IconComponent,
    QrScannerComponent,
  ],
  templateUrl: './inventory-check-modal.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class InventoryCheckModalComponent implements OnChanges {
  @Input() isOpen = false;
  @Output() closed = new EventEmitter<void>();

  private api = inject(Api);
  private warehouseService = inject(WarehouseService);
  private toastService = inject(ToastService);
  private cd = inject(ChangeDetectorRef);

  searchQuery = '';
  isLoading = false;
  inspectionResult: InventoryInspectionResultDto | null = null;
  errorMessage = '';

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['isOpen'] && this.isOpen) {
      this.resetModal();
    }
  }

  resetModal(): void {
    this.searchQuery = '';
    this.inspectionResult = null;
    this.errorMessage = '';
    this.isLoading = false;
    this.cd.markForCheck();
  }

  closeModal(): void {
    this.closed.emit();
  }

  async executeInspection(code: string): Promise<void> {
    const trimmed = code.trim();
    if (!trimmed) return;

    this.searchQuery = trimmed;
    const warehouseId = this.warehouseService.selectedWarehouseId();

    if (!warehouseId) {
      this.toastService.error('Please select a specific warehouse location first.');
      return;
    }

    this.isLoading = true;
    this.errorMessage = '';
    this.inspectionResult = null;
    this.cd.markForCheck();

    try {
      const result = (await this.api.invoke(inspectInventoryCode, {
        code: trimmed,
        warehouseId: warehouseId,
      })) as InventoryInspectionResultDto;

      if (result && result.found) {
        this.inspectionResult = result;
        this.toastService.success(
          `Inspected ${result.inspectionType ?? 'Location'}: ${result.title ?? ''}`
        );
      } else {
        this.errorMessage =
          result?.errorMessage || `No Pallet or Bin found matching "${trimmed}".`;
      }
    } catch (err: any) {
      console.error('Inventory inspection error:', err);
      this.errorMessage = err?.message || 'An error occurred while inspecting inventory.';
      this.toastService.error(this.errorMessage);
    } finally {
      this.isLoading = false;
      this.cd.markForCheck();
    }
  }

  clearSearch(): void {
    this.searchQuery = '';
    this.inspectionResult = null;
    this.errorMessage = '';
    this.cd.markForCheck();
  }

  formatDate(dateStr?: string | null): string {
    if (!dateStr) return '—';
    try {
      return new Date(dateStr).toLocaleDateString('en-US', {
        month: 'short',
        day: '2-digit',
        year: 'numeric',
      });
    } catch {
      return dateStr;
    }
  }
}