import { Component, HostListener, ElementRef, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WarehouseDetailsDto } from '../../../api/generated/models';
import { IconComponent } from '../icon/icon.component';
import { WarehouseService, ALL_WAREHOUSES_OPTION } from '../../../lib/services/warehouse.service';
import { LucideAngularModule, Warehouse, RefreshCw } from 'lucide-angular';

@Component({
  selector: 'app-warehouse-switcher',
  standalone: true,
  imports: [CommonModule, IconComponent, LucideAngularModule],
  templateUrl: './warehouse-switcher.component.html'
})
export class WarehouseSwitcherComponent {
  readonly WarehouseIcon = Warehouse;
  readonly RefreshIcon = RefreshCw;
  readonly allWarehousesOption = ALL_WAREHOUSES_OPTION;

  warehouseService = inject(WarehouseService);
  private elementRef = inject(ElementRef);

  isOpen = signal(false);

  toggleMenu(): void {
    this.isOpen.update((v) => !v);
  }

  selectWarehouse(id: number | null): void {
    if (this.warehouseService.selectedWarehouseId() !== id) {
      this.warehouseService.setWarehouse(id);
      window.location.reload();
    }
    this.isOpen.set(false);
  }

  @HostListener('document:click', ['$event'])
  onClickOutside(event: Event): void {
    if (!this.elementRef.nativeElement.contains(event.target)) {
      this.isOpen.set(false);
    }
  }
}