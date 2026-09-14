import { Component, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SidebarComponent } from './shared/layout/sidebar/sidebar.component';
import { LayoutService } from './lib/services/layout.service';

@Component({
  imports: [SidebarComponent, RouterOutlet],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('Skybest WMS');
  protected readonly layoutService = inject(LayoutService);
}
