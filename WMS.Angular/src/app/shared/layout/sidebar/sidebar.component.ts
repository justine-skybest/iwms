import { Component, inject, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive, Router, NavigationEnd } from '@angular/router';
import { CommonModule } from '@angular/common';
import { IconComponent } from '../../components/icon/icon.component';
import { filter } from 'rxjs/operators';
import { LayoutService } from '../../../lib/services/layout.service';
import { AuthService } from '../../../lib/services/auth.service';
import { ArrowLeftRight, Download, FileCheck, AArrowUp, House, Inbox, LogsIcon, LucideAngularModule, Warehouse, ListOrdered, RotateCcwIcon, PackageSearch } from 'lucide-angular';
import { UserResponseDto } from '../../../api/generated/models';
import { Grid3x3, LayersPlusIcon, User, UserPlus, Users } from 'lucide-angular/src/icons';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive, IconComponent, LucideAngularModule],
  templateUrl: './sidebar.component.html'
})
export class SidebarComponent implements OnInit {
  public layoutService = inject(LayoutService);
  public authService = inject(AuthService);
  private router = inject(Router);

  mainNavItems = [
    { path: '/home', label: 'Dashboard', icon: House },
    { path: '/incoming', label: 'Incoming', icon: Download },
    { path: '/receiving', label: 'Receiving', icon: Inbox },
    { path: '/check-in', label: 'Check In', icon: FileCheck },
    { path: '/pick-order', label: 'Pick Order', icon: PackageSearch },
    { path: '/audit-logs', label: 'Audit Logs', icon: RotateCcwIcon }
  ];

  masterDataItems = [
    { path: '/products', label: 'Products', icon: PackageSearch },
    { path: '/warehouses', label: 'Warehouses', icon: Warehouse },
    { path: '/pallets', label: 'Pallets', icon: Grid3x3 },
    { path: '/suppliers', label: 'Suppliers', icon: Users },
    { path: '/customers', label: 'Customers', icon: Users },
    { path: '/users', label: 'System Users', icon: Users },
  ];

  reportItems = [
    { path: '/transaction-summary', label: 'Transaction Summary', icon: ArrowLeftRight },
    { path: '/warehouse-occupancy', label: 'Warehouse Occupancy', icon: Warehouse },
    { path: '/reconcillation-report', label: 'Receiving Reconciliation', icon: Warehouse }
  ];

  isMasterDataOpen = false;
  isReportDataOpen = false;

  ngOnInit(): void {
    this.checkActiveRoute();
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(() => this.checkActiveRoute());

    // Fetch user info on load if state is empty
    if (!this.authService.currentUserValue) {
      this.authService.getCurrentUser().subscribe();
    }
  }

  toggleMasterData(): void {
    this.isMasterDataOpen = !this.isMasterDataOpen;
  }

  toggleReports(): void {
    this.isReportDataOpen = !this.isReportDataOpen;
  }

  isReportDataActive(): boolean {
    const currentUrl = this.router.url;
    return this.reportItems.some(item => currentUrl.startsWith(item.path));
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

  getUserName(user: UserResponseDto | null): string {
    if (!user) return 'User';
    if (user.firstName || user.lastName) {
      return `${user.firstName || ''} ${user.lastName || ''}`.trim();
    }
    return user?.email!.split('@')[0];
  }

  getUserInitials(user: UserResponseDto | null): string {
    if (!user) return 'U';
    if (user.firstName && user.lastName) {
      return (user.firstName[0] + user.lastName[0]).toUpperCase();
    }
    if (user.firstName) {
      return user.firstName.substring(0, 2).toUpperCase();
    }
    return user?.email!.substring(0, 2).toUpperCase();
  }

  logout(): void {
    this.authService.logout().subscribe();
  }

  protected closeMenu(): void {
    this.layoutService.closeMobileMenu();
  }
}