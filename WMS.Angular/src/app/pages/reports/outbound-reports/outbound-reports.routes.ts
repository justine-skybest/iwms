
import type { Routes } from "@angular/router";
import { OutboundReportsComponent } from "./outbound-reports.component";

export const outboundReportRoutes: Routes = [
  {
    path: "",
    component: OutboundReportsComponent,
    data: {
      breadcrumb: "Outbound Reports",
    },
  },
];