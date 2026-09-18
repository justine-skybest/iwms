import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { IconComponent } from '../../shared/components/icon/icon.component';

@Component({
  selector: 'app-mobile-app',
  standalone: true,
  imports: [CommonModule, IconComponent],
  templateUrl: './mobile-app.component.html'
})
export class MobileAppComponent {
  activeAction: string | null = null;

  mobileActions = [
    { label: "Item Receipt", icon: "truck", color: "#3b82f6", bg: "#dbeafe", path: '/receiving' },
    { label: "Check In", icon: "scan", color: "#22c55e", bg: "#dcfce7", path: '/check-in' },
    { label: "Pick Order", icon: "list", color: "#8b5cf6", bg: "#ede9fe", path: '/pick-order' },
    { label: "Cycle Count", icon: "rotate", color: "#f59e0b", bg: "#fef3c7", path: '/check-in' },
    { label: "Transfer", icon: "transfer", color: "#06b6d4", bg: "#cffafe", path: '/pallets' },
    { label: "Products", icon: "products", color: "#0f172a", bg: "#f1f5f9", path: '/products' },
    { label: "Warehouses", icon: "warehouses", color: "#0f172a", bg: "#f1f5f9", path: '/warehouses' },
  ];

  recentActivity = [
    { text: "RCV-2024-0891 received", time: "2 min ago", dot: "#22c55e" },
    { text: "PLT-003-C checked in", time: "18 min ago", dot: "#3b82f6" },
    { text: "Pick order #4471 completed", time: "1 hr ago", dot: "#8b5cf6" },
  ];

  constructor(private router: Router) {}

  toggleAction(label: string) {
    this.activeAction = this.activeAction === label ? null : label;
  }

  startAction() {
    if (!this.activeAction) return;
    const action = this.mobileActions.find(item => item.label === this.activeAction);
    if (action?.path) {
      this.router.navigate([action.path]);
    }
  }
}