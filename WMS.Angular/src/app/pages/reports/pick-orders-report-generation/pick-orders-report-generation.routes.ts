import type { Routes } from "@angular/router";
import { PickOrderReportsComponent } from "./pick-order-reports.component";

export const pickOrderReportRoutes: Routes = [
  {
    path: "",
    component: PickOrderReportsComponent,
    data: {
      breadcrumb: "Pick Order Reports",
    },
  },
];