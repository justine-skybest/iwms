import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { IconComponent } from '../../components/icon/icon.component';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive, IconComponent],
  templateUrl: './sidebar.component.html'
})
export class SidebarComponent {
  navItems = [
    { path: '/home', label: 'Dashboard', icon: 'dashboard' },
    { path: '/products', label: 'Products', icon: 'products' },
    { path: '/warehouses', label: 'Warehouses', icon: 'warehouses' },
    { path: '/pallets', label: 'Pallets', icon: 'pallets' },
    { path: '/suppliers', label: 'Suppliers', icon: 'suppliers' },
    { path: '/customers', label: 'Customers', icon: 'customers' },
    { path: '/users', label: 'System Users', icon: 'users' },
  ];

  constructor(private router: Router) {}

  logout() {
    this.router.navigate(['/login']);
  }
}