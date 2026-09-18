import type { Routes } from "@angular/router";
import { WarehousesListComponent } from "./warehouses-list.component";

export const warehousesRoutes: Routes = [
  {
    path: "",
    component: WarehousesListComponent,
    data: {
      breadcrumb: "Warehouses",
    },
  },
];