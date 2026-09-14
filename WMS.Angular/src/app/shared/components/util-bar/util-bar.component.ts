import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-util-bar',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="flex items-center" style="display: flex; gap: 8px;">
      <div style="width: 80px; height: 6px; background: #e2e8f0; border-radius: 3px; overflow: hidden;">
        <div [ngStyle]="{'width': pct + '%', 'background': color}" 
             style="height: 100%; border-radius: 3px; transition: width 0.4s;"></div>
      </div>
      <span style="font-family: var(--font-mono); font-size: 12px; color: #475569;">{{pct}}%</span>
    </div>
  `
})
export class UtilBarComponent {
  @Input() pct: number = 0;
  get color(): string {
    return this.pct >= 90 ? '#ef4444' : this.pct >= 70 ? '#f59e0b' : '#22c55e';
  }
}