import type { Routes } from "@angular/router";
import { PickOrderListComponent } from "./pick-order-list.component";

export const pickOrderRoutes: Routes = [
  {
    path: "",
    component: PickOrderListComponent,
    data: {
      breadcrumb: "Pick Order",
    },
  },
];