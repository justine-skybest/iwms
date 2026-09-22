import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManualPickingSummaryDto, PickedProductSummaryDto } from '../../../api/generated/models';
import { BoxIcon, LucideAngularModule, XIcon } from 'lucide-angular';

@Component({
  selector: 'app-pick-order-details-drawer',
  standalone: true,
  imports: [CommonModule, LucideAngularModule],
  templateUrl: './pick-order-details-drawer.component.html'
})
export class PickOrderDetailsDrawerComponent {
  @Input() isOpen = false;
  @Input() pickOrder: ManualPickingSummaryDto | null = null;
  @Output() closed = new EventEmitter<void>();

  readonly xIcon = XIcon;
  readonly boxIcon = BoxIcon;

  close(): void {
    this.closed.emit();
  }

  formatDate(dateStr?: string): string {
    if (!dateStr) return '—';
    const date = new Date(dateStr);
    return isNaN(date.getTime()) ? '—' : date.toLocaleDateString('en-US', {
      month: 'short',
      day: 'numeric',
      year: 'numeric'
    });
  }

  getTotalQuantity(products?: PickedProductSummaryDto[] | null): number {
    if (!products?.length) return 0;
    return products.reduce((sum, item) => sum + (item.quantityPicked ?? 0), 0);
  }
}