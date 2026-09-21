import { Component, input, inject } from '@angular/core';
import { DatePipe } from '@angular/common';
import { WarehouseService } from '../../../lib/services/warehouse.service';

@Component({
  selector: 'app-page-header',
  standalone: true,
  imports: [DatePipe],
  templateUrl: './page-header.component.html'
})
export class PageHeaderComponent {
  private warehouseService = inject(WarehouseService);

  // Signal Inputs
  title = input.required<string>();
  subtitle = input<string>('');
  showWarehouse = input<boolean>(true);
  showDate = input<boolean>(true);

  // Reactive state from WarehouseService
  activeWarehouse = this.warehouseService.activeWarehouse;
  today = new Date();
}