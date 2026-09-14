import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { TableCardComponent } from '../../shared/components/table-card/table-card.component';
import { IconComponent } from '../../shared/components/icon/icon.component';

@Component({
  selector: 'app-placeholder',
  standalone: true,
  imports: [CommonModule, TableCardComponent, IconComponent],
  templateUrl: './placeholder.component.html'
})
export class PlaceholderComponent implements OnInit {
  name: string = '';
  icon: string = '';
  color: string = '';

  colsMap: Record<string, string[]> = {
    Products: ["SKU", "Product Name", "Category", "Unit", "On-Hand Qty", "Status"],
    Warehouses: ["Code", "Warehouse Name", "Location", "Total Bins", "Utilization", "Manager"],
    Pallets: ["Pallet ID", "Series", "Warehouse", "Bin", "Product Count", "Status"],
    Suppliers: ["Supplier ID", "Company", "Contact", "Country", "Active POs", "Rating"],
    Customers: ["Customer ID", "Company", "Contact", "Region", "Last Order", "Status"],
    "System Users": ["Username", "Full Name", "Role", "Warehouse Access", "Last Login", "Status"],
  };

  rowsMap: Record<string, any[][]> = {
    Products: [["SKU-0041", "Organic Oat Bran 5kg", "Grains", "Bag", 240, "Active"], ["SKU-0078", "Whey Protein Isolate", "Supplements", "Pouch", 88, "Active"], ["SKU-0099", "Brown Rice Flour 2kg", "Grains", "Pack", 312, "Active"]],
    Warehouses: [["WH-NORTH-01", "North Distribution Center", "Quezon City", 360, "78%", "R. Santos"], ["WH-SOUTH-03", "South Logistics Hub", "Parañaque", 280, "54%", "M. Cruz"], ["WH-EAST-02", "East Storage Facility", "Pasig", 420, "93%", "J. Reyes"]],
    Pallets: [["PLT-001-A", "RCV-2024-0891", "WH-NORTH-01", "A-04", 24, "Checked In"], ["PLT-002-B", "RCV-2024-0890", "WH-SOUTH-03", "B-11", 18, "Pending"], ["PLT-003-C", "RCV-2024-0889", "WH-EAST-02", "C-07", 30, "Checked In"]],
    Suppliers: [["SUP-001", "Pacific Exports Ltd.", "Jane Lim", "Philippines", 3, "★★★★★"], ["SUP-002", "Guangzhou Freight Co.", "Wei Zhang", "China", 1, "★★★★☆"], ["SUP-003", "Manila Bay Logistics", "Rene Bautista", "Philippines", 2, "★★★★★"]],
    Customers: [["CUS-001", "FreshMart Superstore", "Ana Ramos", "NCR", "Sep 10, 2026", "Active"], ["CUS-002", "HealthHub PH", "Carlo Tan", "Cebu", "Sep 08, 2026", "Active"], ["CUS-003", "NutriLife Distributors", "Gina Flores", "Davao", "Aug 30, 2026", "Inactive"]],
    "System Users": [["admin", "Admin User", "Super Admin", "All", "Sep 14, 2026", "Active"], ["jreyes", "Juan Reyes", "Warehouse Mgr", "WH-EAST-02", "Sep 13, 2026", "Active"], ["mcruz", "Maria Cruz", "Operator", "WH-SOUTH-03", "Sep 12, 2026", "Active"]],
  };

  currentCols: string[] = [];
  currentRows: any[][] = [];

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.name = data['title'];
      this.icon = data['icon'];
      this.color = data['color'];
      this.currentCols = this.colsMap[this.name] || [];
      this.currentRows = this.rowsMap[this.name] || [];
    });
  }

  getAddLabel() {
    return this.name.slice(0, -1).replace("System User", "User");
  }

  isStatus(cell: any) {
    return typeof cell === 'string' && ['Active', 'Inactive', 'Checked In', 'Pending'].includes(cell);
  }
}