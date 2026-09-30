import type { Routes } from "@angular/router";
import { AuditLogsComponent } from "./audit-logs.component";

export const auditLogsRoutes: Routes = [
  {
    path: "",
    component: AuditLogsComponent,
    data: {
      breadcrumb: "Check-In",
    },
  },
];