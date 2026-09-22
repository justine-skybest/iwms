import { Component, computed, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { IconComponent } from '../../shared/components/icon/icon.component';
import { ToastService } from '../../lib/services/toast.service';
import { ReceivingCreateComponent } from '../receiving/create/receiving-create.component';
import { CreateCheckInModalComponent } from '../check-in/components/create/create-check-in-modal.component';
import { CreatePickOrderModalComponent } from '../pick-order/create-pick-order-modal.component';
import { WarehouseSwitcherComponent } from '../../shared/components/warehouse-switcher/warehouse-switcher.component';
import { WarehouseService } from '../../lib/services/warehouse.service';
import { CreateTransferModalComponent } from './transfer-operation/create-transfer-modal.component';
import { InventoryCheckModalComponent } from './inventory-checker/inventory-check.component';

export interface MobileAction {
  id: 'receiving' | 'check-in' | 'pick-order' | 'cycle-count' | 'transfer' | 'inventory-check';
  label: string;
  icon: string;
  color: string;
  bg: string;
  path?: string;
  disabled?: boolean
}

interface RecentActivity {
  text: string;
  time: string;
  dot: string;
}

@Component({
  selector: 'app-mobile-app',
  standalone: true,
  imports: [
    CommonModule,
    IconComponent,
    ReceivingCreateComponent,
    CreateCheckInModalComponent,
    CreatePickOrderModalComponent,
    CreateTransferModalComponent,
    WarehouseSwitcherComponent,
    InventoryCheckModalComponent
  ],
  templateUrl: './mobile-app.component.html',
})
export class MobileAppComponent {
  private router = inject(Router);
  private toastService = inject(ToastService);
  private warehouseService = inject(WarehouseService);

  // Warehouse State
  currentWarehouse = this.warehouseService.activeWarehouse;
  hasSelectedWarehouse = computed(() => this.warehouseService.selectedWarehouseId() !== null);

  // Dialog & Drawer States
  isReceivingOpen = false;
  isCheckInOpen = false;
  isPickOrderOpen = false;
  isTransferOpen = false;
  isInventoryCheckOpen = false;

  mobileActions: MobileAction[] = [
    { id: 'receiving', label: 'Item Receipt', icon: 'truck', color: '#3b82f6', bg: '#dbeafe' },
    { id: 'check-in', label: 'Check In', icon: 'scan', color: '#22c55e', bg: '#dcfce7' },
    { id: 'pick-order', label: 'Pick Order', icon: 'list', color: '#8b5cf6', bg: '#ede9fe' },
    { id: 'cycle-count', label: 'Cycle Count', icon: 'rotate', color: '#f59e0b', bg: '#fef3c7', path: '/check-in', disabled: true },
    { id: 'inventory-check', label: 'Inventory Check', icon: 'search', color: '#ec4899', bg: '#fce7f3' },
    { id: 'transfer', label: 'Transfer', icon: 'transfer', color: '#06b6d4', bg: '#cffafe' },
  ];

  recentActivity: RecentActivity[] = [
    // { text: 'RCV-2024-0891 received', time: '2 min ago', dot: '#22c55e' },
    // { text: 'PLT-003-C checked in', time: '18 min ago', dot: '#3b82f6' },
    // { text: 'Pick order #4471 completed', time: '1 hr ago', dot: '#8b5cf6' },
  ];

  executeAction(action: MobileAction): void {
    if (!this.hasSelectedWarehouse()) {
      this.toastService.error('Please select a specific warehouse before performing operations.', 'Warehouse Required');
      return;
    }

    switch (action.id) {
      case 'receiving':
        this.isReceivingOpen = true;
        break;
      case 'check-in':
        this.isCheckInOpen = true;
        break;
      case 'pick-order':
        this.isPickOrderOpen = true;
        break;
      case 'inventory-check':
        this.isInventoryCheckOpen = true;
        break;
      case 'transfer':
        this.isTransferOpen = true;
        break;
      default:
        if (action.path) {
          this.router.navigate([action.path]);
        }
        break;
    }
  }

  onReceivingCreated(): void {
    this.toastService.success('Item receipt recorded successfully.');
    this.addRecentActivity('New item receipt recorded');
  }

  onCheckInCreated(): void {
    this.toastService.success('Check-in completed successfully.');
    this.addRecentActivity('Item checked into location');
  }

  onPickOrderCreated(): void {
    this.toastService.success('Pick order created successfully.');
    this.addRecentActivity('Pick order initiated');
  }

  onTransferCreated(): void {
    // this.toastService.success('Pallet transfer executed successfully.');
    this.addRecentActivity('Pallet transferred to new bin');
  }

  private addRecentActivity(text: string): void {
    this.recentActivity.unshift({
      text,
      time: 'Just now',
      dot: '#22c55e',
    });
    if (this.recentActivity.length > 5) {
      this.recentActivity.pop();
    }
  }
}