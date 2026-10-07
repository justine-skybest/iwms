import type { Routes } from "@angular/router";
import { InventoryAgingReportsComponent } from "./inventory-aging-reports.component";

export const inventoryAgingReportRoutes: Routes = [
  {
    path: "",
    component: InventoryAgingReportsComponent,
    data: {
      breadcrumb: "Inventory Aging Reports",
    },
  },
];