import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
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
    { label: "Item Receipt", icon: "truck", color: "#3b82f6", bg: "#dbeafe" },
    { label: "Check In", icon: "scan", color: "#22c55e", bg: "#dcfce7" },
    { label: "Pick Order", icon: "list", color: "#8b5cf6", bg: "#ede9fe" },
    { label: "Cycle Count", icon: "rotate", color: "#f59e0b", bg: "#fef3c7" },
    { label: "Transfer", icon: "transfer", color: "#06b6d4", bg: "#cffafe" },
    { label: "Products", icon: "products", color: "#0f172a", bg: "#f1f5f9" },
    { label: "Route Return", icon: "route", color: "#ef4444", bg: "#fee2e2" },
  ];

  recentActivity = [
    { text: "RCV-2024-0891 received", time: "2 min ago", dot: "#22c55e" },
    { text: "PLT-003-C checked in", time: "18 min ago", dot: "#3b82f6" },
    { text: "Pick order #4471 completed", time: "1 hr ago", dot: "#8b5cf6" },
  ];

  toggleAction(label: string) {
    this.activeAction = this.activeAction === label ? null : label;
  }
}