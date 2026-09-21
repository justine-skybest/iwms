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
import { IconComponent } from '../../../shared/components/icon/icon.component';
import { Api } from '../../../api/generated/api';
import { createPallet, updatePallet, palletNumberWarehouseIdGet } from '../../../api/generated/functions';
import { CreatePalletDto, PalletSummaryDto } from '../../../api/generated/models';
import { WarehouseService } from '../../../lib/services/warehouse.service';
import { generateHashCode } from '../../../lib/utils/hashcodeGenerator';
import { ToastService } from '../../../lib/services/toast.service';

@Component({
  selector: 'app-create-pallet-dialog',
  standalone: true,
  imports: [CommonModule, FormsModule, IconComponent],
  templateUrl: './create-pallet-dialog.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CreatePalletDialogComponent implements OnChanges {
  @Input() isOpen = false;
  @Input() palletToEdit?: PalletSummaryDto;

  @Output() closed = new EventEmitter<void>();
  @Output() created = new EventEmitter<void>();

  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);
  private warehouseService = inject(WarehouseService);
  private toastService = inject(ToastService);

  isSubmitting = false;
  isLoadingNextNumber = false;
  errorMessage = '';
  validationErrors: { [key: string]: string } = {};

  // Form Fields
  palletNumber: number | null = null;
  palletDimension: string | null = null;
  capacityInCBM: number | null = null;
  capacityInKG: number | null = null;
  palletHashCode: number | null = null;
  dateAdded: string | null = null;

  isEditMode = false;

  async ngOnChanges(changes: SimpleChanges): Promise<void> {
    if (changes['isOpen'] && this.isOpen) {
      this.resetForm();
      this.isEditMode = !!this.palletToEdit;

      if (this.isEditMode && this.palletToEdit) {
        this.populateFormForEdit();
      } else {
        // Automatically fetch and suggest the next pallet number in create mode
        this.palletHashCode = generateHashCode();
        await this.loadNextPalletNumber();
      }
    }
  }

  private populateFormForEdit(): void {
    if (!this.palletToEdit) return;

    this.palletNumber = this.palletToEdit.palletNumber ?? null;
    this.palletDimension = this.palletToEdit.palletDimension ?? null;
    this.capacityInCBM = this.palletToEdit.capacityInCBM ?? null;
    this.capacityInKG = this.palletToEdit.capacityInKG ?? null;
    this.palletHashCode = this.palletToEdit.palletHashCode ?? null;
    this.dateAdded = this.palletToEdit.dateAdded ?? null;
  }

  resetForm(): void {
    this.palletNumber = null;
    this.palletDimension = null;
    this.capacityInCBM = null;
    this.capacityInKG = null;
    this.palletHashCode = null;
    this.dateAdded = null;
    this.errorMessage = '';
    this.validationErrors = {};
    this.isLoadingNextNumber = false;
    this.isSubmitting = false;
    this.isEditMode = false;
    this.cd.markForCheck();
  }

  closeModal(): void {
    this.closed.emit();
  }

  async loadNextPalletNumber(): Promise<void> {
    const warehouseId = this.warehouseService.selectedWarehouseId();
    if (!warehouseId) return;

    this.isLoadingNextNumber = true;
    this.cd.markForCheck();

    try {
      const currentMaxNumber = (await this.api.invoke(palletNumberWarehouseIdGet, {
        WarehouseId: warehouseId,
      })) as number;

      // Increment by 1 for the next available pallet number
      this.palletNumber = (currentMaxNumber ?? 0) + 1;
    } catch (err) {
      console.error('Failed to get next pallet number:', err);
    } finally {
      this.isLoadingNextNumber = false;
      this.cd.markForCheck();
    }
  }

 async onSubmit(): Promise<void> {
  this.errorMessage = '';
  this.validationErrors = {};

  const warehouseId = this.warehouseService.selectedWarehouseId();
  if (!warehouseId) {
    this.errorMessage = 'Please select a specific warehouse before saving.';
    this.toastService.error(this.errorMessage);
    this.cd.markForCheck();
    return;
  }

  this.isSubmitting = true;
  this.cd.markForCheck();

  try {
    if (!this.isEditMode && this.palletNumber === null) {
      await this.loadNextPalletNumber();
    }

    const payload: CreatePalletDto = {
      palletNumber: this.palletNumber ?? undefined,
      palletDimension: this.palletDimension ?? undefined,
      capacityInCBM: this.capacityInCBM ?? undefined,
      capacityInKG: this.capacityInKG ?? undefined,
      palletHashCode: this.palletHashCode ?? undefined,
      dateAdded: this.dateAdded ?? new Date().toISOString(),
      warehouseId: warehouseId,
    };

    if (this.isEditMode && this.palletToEdit?.id !== undefined) {
      await this.api.invoke(updatePallet, { id: this.palletToEdit.id, body: payload });
      this.toastService.success(`Pallet #${payload.palletNumber} updated successfully.`);
    } else {
      await this.api.invoke(createPallet, { body: payload });
      this.toastService.success(`Pallet #${payload.palletNumber} created successfully.`);
    }

    this.created.emit();
    this.closeModal();
  } catch (err: any) {
    console.error('Failed to save pallet:', err);
    this.errorMessage = err?.error?.title || err?.message || 'Failed to save pallet.';
    this.toastService.error(this.errorMessage, 'Submission Failed');
  } finally {
    this.isSubmitting = false;
    this.cd.markForCheck();
  }
}
}