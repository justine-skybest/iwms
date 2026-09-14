import { Component, Input } from '@angular/core';
import { Icons } from '../../../core/constants/icons.constant';

@Component({
  selector: 'app-icon',
  standalone: true,
  template: `
    <svg [attr.width]="size" [attr.height]="size" viewBox="0 0 24 24" 
         [attr.fill]="fill" [attr.stroke]="stroke" stroke-width="1.8" 
         stroke-linecap="round" stroke-linejoin="round">
      <path [attr.d]="path" />
    </svg>
  `
})
export class IconComponent {
  @Input() name!: string;
  @Input() size: number | string = 16;
  @Input() stroke: string = 'currentColor';
  @Input() fill: string = 'none';

  get path(): string {
    return Icons[this.name] || '';
  }
}