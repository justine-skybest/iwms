import type { Routes } from "@angular/router";
import { WarehouseOccupancyComponent } from "./warehouse-occupancy.component";

export const warehouseOccupancyRoutes: Routes = [
  {
    path: "",
    component: WarehouseOccupancyComponent,
    data: {
      breadcrumb: "Warehouse Occupancy Report",
    },
  },
];