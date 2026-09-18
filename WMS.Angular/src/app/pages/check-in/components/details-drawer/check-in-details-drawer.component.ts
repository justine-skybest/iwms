import { Component, EventEmitter, Input, Output, ChangeDetectionStrategy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IconComponent } from '../../../../shared/components/icon/icon.component';
import { CheckInSummaryDto } from '../../../../api/generated/models';
import { BoxIcon, LucideAngularModule, PencilIcon, TrashIcon, XIcon } from 'lucide-angular';

/**
 * Read-only detail view for a single check-in. Takes the row already loaded
 * by the list (CheckInSummaryDto includes its full Bins/ReceivedProducts
 * arrays), so opening the drawer doesn't need a separate fetch.
 */
@Component({
  selector: 'app-check-in-details-drawer',
  standalone: true,
  imports: [CommonModule, IconComponent, LucideAngularModule],
  templateUrl: './check-in-details-drawer.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CheckInDetailsDrawerComponent {
  @Input() isOpen = false;
  @Input() checkIn: CheckInSummaryDto | null = null;
  @Output() closed = new EventEmitter<void>();

  readonly xIcon = XIcon;
  readonly boxIcon = BoxIcon;

  close(): void {
    this.closed.emit();
  }

  formatCheckInType(type?: string | null): string {
    if (!type) return '—';
    return type.charAt(0).toUpperCase() + type.slice(1);
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

  binLocation(bin: { rack?: string | null; level?: string | null; bay?: string | null }): string {
    return [bin.rack, bin.level, bin.bay].filter(Boolean).join(' / ') || '—';
  }
}