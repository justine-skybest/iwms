import type { Routes } from "@angular/router";
import { ReceivingReportsComponent } from "./receiving-reports.component";

export const receivingReportRoutes: Routes = [
  {
    path: "",
    component: ReceivingReportsComponent,
    data: {
      breadcrumb: "Receiving Reports",
    },
  },
];