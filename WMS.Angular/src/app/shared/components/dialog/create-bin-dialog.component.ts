import {
  Component,
  Input,
  Output,
  EventEmitter,
  OnChanges,
  SimpleChanges,
  inject,
  ChangeDetectorRef,
  ChangeDetectionStrategy,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Api } from '../../../api/generated/api';
import { binV2Get, createBin } from '../../../api/generated/functions';
import { BinNamesDto, CreateBinDto, BinNamesDtoPaginatedResponse, BinSummaryDto } from '../../../api/generated/models';
import { WarehouseService } from '../../../lib/services/warehouse.service';
import { firstValueFrom } from 'rxjs';

export interface CreateBinPosition {
  positionX: number;
  positionY: number;
  positionZ: number;
  rotationY: number;
}

@Component({
  selector: 'app-create-bin-dialog',
  standalone: true,
  imports: [CommonModule, FormsModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
  template: `
    <div
      *ngIf="isOpen"
      class="fixed inset-0 z-50 flex items-center justify-center bg-slate-900/50 backdrop-blur-sm p-4"
    >
      <div class="bg-white rounded-lg shadow-xl w-full max-w-md p-6 flex flex-col gap-4 border border-slate-200">
        <!-- Dialog Header -->
        <div class="flex items-center justify-between">
          <h3 class="text-base font-semibold text-slate-800">Create New Bin</h3>
          <button
            type="button"
            (click)="onCancel()"
            class="text-slate-400 hover:text-slate-600 text-lg font-bold leading-none"
          >
            &times;
          </button>
        </div>

        <!-- Bin Name -->
        <div class="flex flex-col gap-1">
          <label class="text-xs font-medium text-slate-600">
            Bin Name <span class="text-red-500">*</span>
          </label>
          <select
            [(ngModel)]="binNamesId"
            [disabled]="isLoadingBinNames || binNames.length === 0"
            class="px-3 py-1.5 border rounded-md text-sm border-slate-300 focus:ring-2 focus:ring-blue-500 outline-none"
          >
            <option [ngValue]="null">{{ isLoadingBinNames ? 'Loading bin names...' : 'Select a bin name' }}</option>
            <option *ngFor="let name of binNames" [ngValue]="name.id">{{ name.binName }}</option>
          </select>
        </div>

        <!-- Auto-Generated Hash Code -->
        <div class="flex flex-col gap-1">
          <div class="flex items-center justify-between">
            <label class="text-xs font-medium text-slate-600">Auto-Generated Hash Code</label>
            <button
              type="button"
              (click)="regenerateHashCode()"
              class="text-[11px] font-medium text-blue-600 hover:text-blue-700 underline"
            >
              Regenerate
            </button>
          </div>
          <input
            type="text"
            [value]="binHashCode"
            readonly
            class="px-3 py-1.5 border rounded-md text-sm border-slate-200 bg-slate-50 text-slate-700 font-mono font-semibold cursor-not-allowed outline-none"
          />
        </div>

        <!-- Error Message -->
        <div *ngIf="errorMessage" class="text-xs text-red-600">
          {{ errorMessage }}
        </div>

        <!-- Actions -->
        <div class="flex justify-end gap-2 mt-2">
          <button
            type="button"
            (click)="onCancel()"
            class="px-3 py-1.5 text-xs font-medium text-slate-600 hover:bg-slate-100 rounded-md transition-colors"
          >
            Cancel
          </button>
          <button
            type="button"
            [disabled]="isSubmitting || isLoadingBinNames || binNamesId === null || !binHashCode"
            (click)="onSubmit()"
            class="px-3 py-1.5 text-xs font-medium bg-blue-600 hover:bg-blue-700 text-white rounded-md transition-colors disabled:opacity-50 disabled:cursor-not-allowed"
          >
            {{ isSubmitting ? 'Creating...' : 'Create' }}
          </button>
        </div>
      </div>
    </div>
  `,
})
export class CreateBinDialogComponent implements OnChanges {
  @Input() isOpen = false;
  @Input() initialPosition: CreateBinPosition | null = null;
  @Output() closed = new EventEmitter<void>();
  @Output() created = new EventEmitter<BinSummaryDto>();

  private api = inject(Api);
  private http = inject(HttpClient);
  private warehouseService = inject(WarehouseService);
  private cd = inject(ChangeDetectorRef);

  binNames: BinNamesDto[] = [];
  binNamesId: number | null = null;
  isLoadingBinNames = false;
  binHashCode = this.generateBinHashCode();
  isSubmitting = false;
  errorMessage = '';

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['isOpen'] && this.isOpen) {
      this.resetForm();
      void this.loadBinNames();
    }
  }

  regenerateHashCode(): void {
    this.binHashCode = this.generateBinHashCode();
  }

  async onSubmit(): Promise<void> {
    const warehouseId = this.warehouseService.selectedWarehouseId();
    if (this.binNamesId === null || !this.binHashCode || warehouseId === null) {
      this.errorMessage = warehouseId === null ? 'Select a warehouse before creating a bin.' : 'Select a bin name.';
      this.cd.markForCheck();
      return;
    }

    this.isSubmitting = true;
    this.errorMessage = '';
    this.cd.markForCheck();

    try {
      const bins = await this.api.invoke(binV2Get, { warehouseId, page: 1, pageSize: 500 });
      const standaloneCount = (bins.items ?? []).filter(
        (bin) => (bin.rack ?? '').toLowerCase() === 'standalone'
      ).length;
      const payload: CreateBinDto = {
        warehouseId,
        rackId: null,
        bayId: null,
        levelId: null,
        binNamesId: this.binNamesId,
        binHashCode: this.binHashCode,
        dateAdded: new Date().toISOString(),
        location3D: {
          positionX: this.initialPosition?.positionX ?? 8 + (standaloneCount % 5) * 3,
          positionY: this.initialPosition?.positionY ?? 0.6,
          positionZ: this.initialPosition?.positionZ ?? -20 + Math.floor(standaloneCount / 5) * 3,
          rotationY: this.initialPosition?.rotationY ?? 0,
          width: 1.5,
          height: 1.2,
          depth: 1.2,
        },
      };
      const createdBin = (await this.api.invoke(createBin, {
        body: payload,
      })) as BinSummaryDto;

      this.created.emit(createdBin);
      this.resetAndClose();
    } catch (err) {
      console.error('Failed to create bin:', err);
      this.errorMessage = 'Failed to create bin. Please try again.';
    } finally {
      this.isSubmitting = false;
      this.cd.markForCheck();
    }
  }

  onCancel(): void {
    this.resetAndClose();
  }

  private resetForm(): void {
    this.binNamesId = null;
    this.binHashCode = this.generateBinHashCode();
    this.errorMessage = '';
  }

  private async loadBinNames(): Promise<void> {
    this.isLoadingBinNames = true;
    this.errorMessage = '';
    this.cd.markForCheck();

    try {
      const response = await firstValueFrom(
        this.http.get<BinNamesDto[] | BinNamesDtoPaginatedResponse>(
          `${this.api.rootUrl.replace(/\/$/, '')}/binnames`
        )
      );
      this.binNames = Array.isArray(response) ? response : response.items ?? [];
    } catch (err) {
      console.error('Failed to load bin names:', err);
      this.errorMessage = 'Unable to load bin names. Please try again.';
    } finally {
      this.isLoadingBinNames = false;
      this.cd.markForCheck();
    }
  }

  private resetAndClose(): void {
    this.resetForm();
    this.closed.emit();
  }

  private generateBinHashCode(): number {
    const min = 1_000_000_000;
    const max = 2_147_483_647;
    return Math.floor(min + Math.random() * (max - min + 1));
  }
}