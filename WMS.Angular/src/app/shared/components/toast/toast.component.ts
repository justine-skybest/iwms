import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastService } from '../../../lib/services/toast.service';

@Component({
  selector: 'app-toast',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="fixed top-5 right-5 z-50 flex flex-col gap-2.5 max-w-sm w-full pointer-events-none px-4 sm:px-0">
      @for (toast of toastService.toasts(); track toast.id) {
        <div
          class="pointer-events-auto flex items-start justify-between gap-3 p-4 rounded-xl shadow-lg border backdrop-blur-md transition-all duration-300 animate-slide-in"
          [ngClass]="{
            'bg-emerald-50/95 border-emerald-200 text-emerald-900': toast.type === 'success',
            'bg-red-50/95 border-red-200 text-red-900': toast.type === 'error',
            'bg-slate-900/95 border-slate-800 text-white': toast.type === 'info'
          }"
        >
          <div class="flex items-start gap-3">
            <!-- Icon -->
            <div class="mt-0.5 shrink-0">
              @if (toast.type === 'success') {
                <svg class="w-5 h-5 text-emerald-600" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                  <path stroke-linecap="round" stroke-linejoin="round" d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z" />
                </svg>
              } @else if (toast.type === 'error') {
                <svg class="w-5 h-5 text-red-600" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
                  <path stroke-linecap="round" stroke-linejoin="round" d="M12 8v4m0 4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                </svg>
              }
            </div>

            <!-- Content -->
            <div>
              @if (toast.title) {
                <h4 class="text-xs font-semibold uppercase tracking-wider mb-0.5 opacity-90">{{ toast.title }}</h4>
              }
              <p class="text-xs leading-relaxed font-medium">{{ toast.message }}</p>
            </div>
          </div>

          <!-- Close Button -->
          <button
            (click)="toastService.remove(toast.id)"
            class="text-slate-400 hover:text-slate-600 dark:hover:text-white p-0.5 rounded transition-colors"
          >
            ✕
          </button>
        </div>
      }
    </div>
  `
})
export class ToastComponent {
  toastService = inject(ToastService);
}