import type { Routes } from "@angular/router";
import { ReceivingReconciliationReportComponent } from "./receiving-reconciliation-report.component";

export const reconcillationRoutes: Routes = [
  {
    path: "",
    component: ReceivingReconciliationReportComponent,
    data: {
      breadcrumb: "Receiving Reconciliation Report",
    },
  },
];