import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutService } from '../../../lib/services/layout.service';
import { LucideAngularModule, MenuIcon } from 'lucide-angular';

@Component({
  selector: 'app-mobile-header',
  standalone: true,
  imports: [CommonModule, LucideAngularModule],
  templateUrl: './mobile-header.component.html'
})
export class MobileHeaderComponent {
    readonly menuIcon = MenuIcon;
  public layoutService = inject(LayoutService);
}