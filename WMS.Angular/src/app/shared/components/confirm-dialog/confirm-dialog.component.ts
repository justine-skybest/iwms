import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AlertTriangle, Info, LucideAngularModule, Trash2 } from 'lucide-angular';

export type DialogVariant = 'danger' | 'warning' | 'info';

@Component({
  selector: 'app-confirm-dialog',
  standalone: true,
  imports: [CommonModule, LucideAngularModule],
  template: `
    <div *ngIf="isOpen" class="fixed inset-0 z-50 flex items-center justify-center p-4">
      <!-- Backdrop -->
      <div 
        class="absolute inset-0 bg-slate-900/60 backdrop-blur-sm transition-opacity" 
        (click)="onCancel()">
      </div>

      <!-- Dialog Panel -->
      <div class="relative z-10 w-full max-w-md bg-white rounded-xl shadow-2xl border border-slate-200 overflow-hidden transform transition-all">
        <div class="p-5">
          <div class="flex items-start gap-4">
            <!-- Dynamic Icon Container -->
            <div 
              class="w-10 h-10 rounded-full flex items-center justify-center shrink-0"
              [ngClass]="{
                'bg-red-100 text-red-600': variant === 'danger',
                'bg-amber-100 text-amber-600': variant === 'warning',
                'bg-blue-100 text-blue-600': variant === 'info'
              }">
              <lucide-icon [img]="getIcon()" [size]="20"></lucide-icon>
            </div>

            <!-- Content -->
            <div class="flex-1">
              <h3 class="text-sm font-bold text-slate-800">{{ title }}</h3>
              <p class="mt-1 text-xs text-slate-500 leading-relaxed">{{ message }}</p>
            </div>
          </div>
        </div>

        <!-- Action Buttons -->
        <div class="px-5 py-3.5 bg-slate-50 border-t border-slate-200 flex items-center justify-end gap-2 shrink-0">
          <button
            type="button"
            (click)="onCancel()"
            [disabled]="isLoading"
            class="px-3.5 py-1.5 text-xs font-semibold text-slate-700 bg-white border border-slate-300 rounded-lg hover:bg-slate-100 focus:outline-none focus:ring-2 focus:ring-slate-400 disabled:opacity-50 transition-colors">
            {{ cancelText }}
          </button>
          
          <button
            type="button"
            (click)="onConfirm()"
            [disabled]="isLoading"
            [ngClass]="{
              'bg-red-600 hover:bg-red-700 focus:ring-red-500': variant === 'danger',
              'bg-amber-600 hover:bg-amber-700 focus:ring-amber-500': variant === 'warning',
              'bg-blue-600 hover:bg-blue-700 focus:ring-blue-500': variant === 'info'
            }"
            class="inline-flex items-center gap-1.5 px-3.5 py-1.5 text-xs font-semibold text-white rounded-lg focus:outline-none focus:ring-2 focus:ring-offset-1 shadow-sm disabled:opacity-50 transition-colors">
            <span *ngIf="isLoading" class="w-3 h-3 border-2 border-white/30 border-t-white rounded-full animate-spin"></span>
            {{ confirmText }}
          </button>
        </div>
      </div>
    </div>
  `
})
export class ConfirmDialogComponent {
  @Input() isOpen = false;
  @Input() title = 'Confirm Action';
  @Input() message = 'Are you sure you want to proceed with this action?';
  @Input() confirmText = 'Confirm';
  @Input() cancelText = 'Cancel';
  @Input() variant: DialogVariant = 'danger';
  @Input() isLoading = false;

  @Output() confirmed = new EventEmitter<void>();
  @Output() cancelled = new EventEmitter<void>();

  readonly alertIcon = AlertTriangle;
  readonly trashIcon = Trash2;
  readonly infoIcon = Info;

  getIcon() {
    switch (this.variant) {
      case 'danger': return this.trashIcon;
      case 'warning': return this.alertIcon;
      case 'info': return this.infoIcon;
    }
  }

  onConfirm(): void {
    this.confirmed.emit();
  }

  onCancel(): void {
    if (!this.isLoading) {
      this.cancelled.emit();
    }
  }
}