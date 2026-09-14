import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SidebarComponent } from '../../shared/layout/sidebar/sidebar.component';

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [RouterOutlet, SidebarComponent],
  template: `
    <div class="flex h-screen overflow-hidden">
      <app-sidebar></app-sidebar>

      <!--
        flex-1: fills the remaining width beside the in-flow sidebar
        overflow-y-auto: dashboard content scrolls within main, not the page
      -->
      <main class="flex-1 flex flex-col overflow-y-auto bg-slate-50 min-w-0 px-7">
        <router-outlet></router-outlet>
      </main>
    </div>
  `
})
export class MainLayoutComponent {}