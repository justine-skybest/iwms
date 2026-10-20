import {
  Component,
  computed,
  effect,
  input,
  model,
  output,
  signal,
} from '@angular/core';
import { LowerCasePipe } from '@angular/common';

@Component({
  selector: 'app-confirm-delete-dialog',
  standalone: true,
  imports: [LowerCasePipe],
  templateUrl: './confirm-delete-dialog.component.html',
})
export class ConfirmDeleteDialogComponent {
  readonly open = model<boolean>(false);
  readonly entityName = input.required<string>();
  readonly entityLabel = input<string>('Item');
  readonly deleting = input<boolean>(false);

  readonly confirmed = output<void>();
  readonly cancelled = output<void>();

  readonly confirmInput = signal('');

  readonly isConfirmValid = computed(() => {
    return this.confirmInput().trim() === this.entityName().trim();
  });

  constructor() {
    effect(() => {
      if (!this.open()) {
        this.confirmInput.set('');
      }
    });
  }

  onBackdropClick(event: MouseEvent): void {
    if (!this.deleting()) {
      this.onCancel();
    }
  }

  onCancel(): void {
    if (this.deleting()) return;
    this.open.set(false);
    this.cancelled.emit();
  }

  onConfirm(): void {
    if (!this.isConfirmValid() || this.deleting()) return;
    this.confirmed.emit();
  }
}