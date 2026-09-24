import { Component, inject, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive, Router, NavigationEnd } from '@angular/router';
import { CommonModule } from '@angular/common';
import { IconComponent } from '../../components/icon/icon.component';
import { filter } from 'rxjs/operators';
import { LayoutService } from '../../../lib/services/layout.service';
import { ArrowLeftRight, Locate, LucideAngularModule, Warehouse } from 'lucide-angular';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive, IconComponent, LucideAngularModule],
  templateUrl: './sidebar.component.html'
})
export class SidebarComponent implements OnInit {
  public layoutService = inject(LayoutService);
  
  mainNavItems = [
    { path: '/home', label: 'Dashboard', icon: 'dashboard' },
    { path: '/incoming', label: 'Incoming', icon: 'incoming' },
    { path: '/receiving', label: 'Receiving', icon: 'receiving' },
    { path: '/check-in', label: 'Check In', icon: 'checkIns' },
    { path: '/pick-order', label: 'Pick Order', icon: 'pickOrders' },
  ];

  masterDataItems = [
    { path: '/products', label: 'Products', icon: 'products' },
    { path: '/warehouses', label: 'Warehouses', icon: 'warehouses' },
    { path: '/pallets', label: 'Pallets', icon: 'pallets' },
    { path: '/suppliers', label: 'Suppliers', icon: 'suppliers' },
    { path: '/customers', label: 'Customers', icon: 'customers' },
    { path: '/users', label: 'System Users', icon: 'users' },
  ];

  reportItems = [
    { path: '/transaction-summary', label: 'Transaction Summary', icon: ArrowLeftRight },
    { path: '/pallet-locations', label: 'Pallet Location Audit', icon: Locate },
    { path: '/warehouse-occupancy', label: 'Warehouse Occupancy', icon: Warehouse },
    { path: '/reconcillation-report', label: 'Receiving Reconciliation', icon: Warehouse }
  ];

  isMasterDataOpen = false;
  isReportDataOpen = false;

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.checkActiveRoute();
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(() => this.checkActiveRoute());
  }

  toggleMasterData(): void {
    this.isMasterDataOpen = !this.isMasterDataOpen;
  }

  isReportDataActive(): boolean {
    const currentUrl = this.router.url;
    return this.reportItems.some(item => currentUrl.startsWith(item.path));
  }

  toggleReports(): void {
    this.isReportDataOpen = !this.isReportDataOpen;
  }

  isMasterDataActive(): boolean {
    const currentUrl = this.router.url;
    return this.masterDataItems.some(item => currentUrl.startsWith(item.path));
  }

  private checkActiveRoute(): void {
    if (this.isMasterDataActive()) {
      this.isMasterDataOpen = true;
    }
  }

  logout() {
    this.router.navigate(['/login']);
  }

  protected closeMenu(): void {
    this.layoutService.closeMobileMenu();
  }
}