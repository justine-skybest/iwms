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
import { createProduct, updateProduct } from '../../../api/generated/functions';
import { CreateProductDto, ProductSummaryDto, UpdateProductDto } from '../../../api/generated/models';
import { ToastService } from '../../../lib/services/toast.service';

@Component({
  selector: 'app-create-product-dialog',
  standalone: true,
  imports: [CommonModule, FormsModule, IconComponent],
  templateUrl: './create-product-dialog.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CreateProductDialogComponent implements OnChanges {
  @Input() isOpen = false;
  @Input() productToEdit?: ProductSummaryDto;

  @Output() closed = new EventEmitter<void>();
  @Output() created = new EventEmitter<void>();

  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);

  private toastService = inject(ToastService);

  isSubmitting = false;
  errorMessage = '';
  validationErrors: { [key: string]: string } = {};
  isEditMode = false;

  // Form Fields
  name = '';
  typeOfPackage = '';
  measurement = '';
  weight: number | null = null;

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['isOpen'] && this.isOpen) {
      this.resetForm();
      this.isEditMode = !!this.productToEdit;

      if (this.isEditMode && this.productToEdit) {
        this.populateFormForEdit();
      }
    }
  }

  private populateFormForEdit(): void {
    if (!this.productToEdit) return;

    this.name = this.productToEdit.name ?? '';
    this.typeOfPackage = this.productToEdit.typeOfPackage ?? '';
    this.measurement = this.productToEdit.measurement ?? '';
    this.weight = this.productToEdit.weight ?? null;
  }

  resetForm(): void {
    this.name = '';
    this.typeOfPackage = '';
    this.measurement = '';
    this.weight = null;
    this.errorMessage = '';
    this.validationErrors = {};
    this.isSubmitting = false;
    this.isEditMode = false;
    this.cd.markForCheck();
  }

  closeModal(): void {
    this.closed.emit();
  }

  async onSubmit(): Promise<void> {
    this.errorMessage = '';
    this.validationErrors = {};

    const trimmedName = this.name.trim();
    const trimmedType = this.typeOfPackage.trim();
    const trimmedMeasurement = this.measurement.trim();

    // Field-level Validation
    if (!trimmedName) {
      this.validationErrors['name'] = 'Product Name is required';
    }
    if (!trimmedType) {
      this.validationErrors['typeOfPackage'] = 'Type of Package is required';
    }
    if (!trimmedMeasurement) {
      this.validationErrors['measurement'] = 'Measurement is required';
    }
    if (this.weight === null || this.weight === undefined) {
      this.validationErrors['weight'] = 'Weight is required';
    } else if (isNaN(this.weight) || this.weight <= 0) {
      this.validationErrors['weight'] = 'Weight must be a positive number';
    }

    if (Object.keys(this.validationErrors).length > 0) {
      this.errorMessage = 'Please fill out all required fields correctly.';
      this.cd.markForCheck();
      return;
    }

    this.isSubmitting = true;
  this.cd.markForCheck();

  try {
    const payload: CreateProductDto & UpdateProductDto = {
      name: trimmedName,
      typeOfPackage: trimmedType,
      measurement: trimmedMeasurement,
      weight: this.weight!,
      dateAdded: this.isEditMode && this.productToEdit?.dateAdded 
        ? this.productToEdit.dateAdded 
        : new Date().toISOString(),
    };

    if (this.isEditMode && this.productToEdit?.id !== undefined) {
      await this.api.invoke(updateProduct, { id: this.productToEdit.id, body: payload });
      this.toastService.success(`Product "${trimmedName}" updated successfully.`);
    } else {
      await this.api.invoke(createProduct, { body: payload });
      this.toastService.success(`Product "${trimmedName}" created successfully.`);
    }

    this.created.emit();
    this.closeModal();
  } catch (err: any) {
    console.error('Failed to save product:', err);
    this.errorMessage = err?.message || 'Failed to save product.';
    this.toastService.error(this.errorMessage, 'Submission Failed');
  } finally {
    this.isSubmitting = false;
    this.cd.markForCheck();
  }
  }
}