import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-table-card',
  standalone: true,
  template: `
    <div class="stat-card" style="padding: 0; overflow: hidden; background: #fff; border-radius: 12px; border: 1px solid #e2e8f0;">
      <div style="padding: 14px 18px; border-bottom: 1px solid #e2e8f0; display: flex; align-items: center; justify-content: space-between;">
        <span style="font-family: var(--font-display); font-weight: 600; font-size: 14px; color: #0f172a;">{{ title }}</span>
        <!-- Projection for 'extra' -->
        <ng-content select="[extra]"></ng-content>
      </div>
      <div style="overflow-x: auto;">
        <!-- Projection for 'children' -->
        <ng-content></ng-content>
      </div>
    </div>
  `
})
export class TableCardComponent {
  @Input() title!: string;
}