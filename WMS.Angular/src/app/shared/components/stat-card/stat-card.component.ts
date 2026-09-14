import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IconComponent } from '../icon/icon.component';

@Component({
  selector: 'app-stat-card',
  standalone: true,
  imports: [CommonModule, IconComponent],
  template: `
    <div class="stat-card" style="background: #fff; border: 1px solid #e2e8f0; border-radius: 12px; padding: 20px;">
      <div style="display: flex; justify-content: space-between; align-items: flex-start;">
        <div>
          <div style="font-size: 11.5px; font-weight: 600; color: #64748b; text-transform: uppercase; letter-spacing: 0.05em;">{{label}}</div>
          <div style="font-family: var(--font-mono); font-weight: 600; font-size: 28px; color: #0f172a; margin-top: 4px; letter-spacing: -0.02em;">{{value}}</div>
          <div *ngIf="sub" style="font-size: 12px; color: #94a3b8; margin-top: 3px;">{{sub}}</div>
        </div>
        <div [ngStyle]="{'background': color + '18'}" style="width: 38px; height: 38px; border-radius: 9px; display: flex; align-items: center; justify-content: center;">
          <app-icon [name]="icon" [size]="18" [stroke]="color"></app-icon>
        </div>
      </div>
    </div>
  `
})
export class StatCardComponent {
  @Input() label!: string;
  @Input() value!: string | number;
  @Input() sub?: string;
  @Input() color!: string;
  @Input() icon!: string;
}