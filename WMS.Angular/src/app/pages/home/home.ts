import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { StatCardComponent } from '../../shared/components/stat-card/stat-card.component';
import { TableCardComponent } from '../../shared/components/table-card/table-card.component';
import { UtilBarComponent } from '../../shared/components/util-bar/util-bar.component';
import { IconComponent } from '../../shared/components/icon/icon.component';
import { Api } from '../../api/generated/api';
import {
  warehouseGet,
  receivingV2Get
} from '../../api/generated/functions';
import {
  ReceivingSummaryDto,
  WarehouseDetailsDto
} from '../../api/generated/models';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    StatCardComponent,
    TableCardComponent,
    UtilBarComponent,
    IconComponent
  ],
  templateUrl: './home.html'
})
export class HomeComponent implements OnInit {
  isLoading = true;

  recentReceiving?: ReceivingSummaryDto[] = [];
  warehouseBreakdown: {
    warehouse: string;
    pallets: number;
    utilization: number;
    pending: number;
  }[] = [];

  // Pagination metadata for the receiving V2 endpoint
  receivingPage = 1;
  receivingPageSize = 5;
  receivingTotalCount = 0;
  receivingTotalPages = 0;

  constructor(
    private router: Router,
    private api: Api,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.fetchData();
  }

  async fetchData(): Promise<void> {
    this.isLoading = true;

    try {
      const [warehouses, receivings] = await Promise.all([
        this.api.invoke(warehouseGet),

        // V2: only retrieve the 5 most recent receivings
        this.api.invoke(receivingV2Get, {
          page: this.receivingPage,
          pageSize: this.receivingPageSize
        })
      ]);

      console.log('Fetched data:', { warehouses, receivings });

      // -----------------------------
      // Warehouse breakdown
      // -----------------------------
      this.warehouseBreakdown = warehouses.map(
        (warehouse: WarehouseDetailsDto) => ({
          warehouse: warehouse.name ?? 'N/A',
          pallets: 0,
          utilization: 0,
          pending: 0
        })
      );

      // -----------------------------
      // Receiving pagination metadata
      // -----------------------------
      this.receivingTotalCount = receivings.totalCount!;
      this.receivingTotalPages = receivings.totalPages!;

      // -----------------------------
      // Recent receivings
      // -----------------------------
      this.recentReceiving = receivings.items?.map(
        (receiving: ReceivingSummaryDto) => ({
          series: receiving.series || 'N/A',
          warehouse: receiving.warehouse || 'N/A',
          shipper: receiving.shipper,
          dateReceived: receiving.dateReceived
            ? new Date(receiving.dateReceived).toLocaleDateString(
                'en-US',
                {
                  month: 'short',
                  day: '2-digit',
                  year: 'numeric'
                }
              )
            : 'Unknown'
        })
      );

    } catch (error) {
      console.error('Failed to load dashboard data:', error);
    } finally {
      this.isLoading = false;
      this.cdr.detectChanges();
    }
  }

  goToMobile(): void {
    window.open('/mobile', '_blank');
  }

  readonly expiringProducts = [
    {
      product: 'Organic Oat Bran (5kg)',
      series: 'OOB-2024-0041',
      qty: 240,
      expiration: 'Sep 20, 2026',
      status: 'critical'
    },
    {
      product: 'Whey Protein Isolate',
      series: 'WPI-2024-0078',
      qty: 88,
      expiration: 'Sep 25, 2026',
      status: 'critical'
    },
    {
      product: 'Brown Rice Flour (2kg)',
      series: 'BRF-2024-0099',
      qty: 312,
      expiration: 'Oct 03, 2026',
      status: 'warning'
    },
    {
      product: 'Chia Seeds Premium',
      series: 'CSP-2024-0055',
      qty: 156,
      expiration: 'Oct 08, 2026',
      status: 'warning'
    },
    {
      product: 'Coconut Milk Powder',
      series: 'CMP-2024-0033',
      qty: 74,
      expiration: 'Oct 15, 2026',
      status: 'ok'
    }
  ];

  readonly agingInventory = [
    {
      product: 'Dried Mango Strips',
      series: 'DMS-2023-0012',
      bins: 'A-04, A-05',
      qty: 180,
      days: 384
    },
    {
      product: 'Black Sesame Seeds',
      series: 'BSS-2023-0018',
      bins: 'B-11',
      qty: 95,
      days: 340
    },
    {
      product: 'Quinoa (White)',
      series: 'QNW-2023-0024',
      bins: 'C-07, C-08, C-09',
      qty: 448,
      days: 298
    },
    {
      product: 'Hemp Seeds Hulled',
      series: 'HSH-2023-0031',
      bins: 'D-02',
      qty: 67,
      days: 265
    },
    {
      product: 'Moringa Powder',
      series: 'MRP-2023-0044',
      bins: 'E-15',
      qty: 120,
      days: 241
    }
  ];

  readonly topProducts = [
    { product: 'Rolled Oats Premium', qty: 4820 },
    { product: 'Brown Rice (25kg)', qty: 3910 },
    { product: 'Whey Protein Concentrate', qty: 2740 },
    { product: 'Organic Quinoa', qty: 2380 },
    { product: 'Chia Seeds', qty: 1950 },
    { product: 'Coconut Flour', qty: 1640 }
  ];

  readonly maxTopQty = this.topProducts[0].qty;

  readonly receivingVsPicking = [
    { date: 'Sep 08', received: 412, picked: 380 },
    { date: 'Sep 09', received: 295, picked: 440 },
    { date: 'Sep 10', received: 540, picked: 310 },
    { date: 'Sep 11', received: 380, picked: 495 },
    { date: 'Sep 12', received: 620, picked: 520 },
    { date: 'Sep 13', received: 448, picked: 385 },
    { date: 'Sep 14', received: 310, picked: 290 }
  ];
}