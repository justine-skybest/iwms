import { Component, inject, signal } from '@angular/core';
import { RouterOutlet, Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { filter, map } from 'rxjs/operators';
import { toSignal } from '@angular/core/rxjs-interop';
import { SidebarComponent } from './shared/layout/sidebar/sidebar.component';
import { LayoutService } from './lib/services/layout.service';
import { WarehouseSwitcherComponent } from './shared/components/warehouse-switcher/warehouse-switcher.component';
import { MobileDrawer } from './shared/layout/mobile-drawer/mobile-drawer';
import { MobileHeaderComponent } from './shared/layout/mobile-header/mobile-header.component';

@Component({
  imports: [SidebarComponent, RouterOutlet, WarehouseSwitcherComponent, MobileDrawer, MobileHeaderComponent],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('Skybest WMS');
  protected readonly layoutService = inject(LayoutService);
  private readonly router = inject(Router);
  private readonly activatedRoute = inject(ActivatedRoute);

  protected readonly hideLayout = toSignal(
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd),
      map(() => {
        let route = this.activatedRoute;
        while (route.firstChild) {
          route = route.firstChild;
        }
        return route.snapshot.data['hideLayout'] === true;
      })
    ),
    { initialValue: false }
  );
}