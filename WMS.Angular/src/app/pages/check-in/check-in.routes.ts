import type { Routes } from "@angular/router";
import { CheckInListComponent } from "./check-in-list.component";

export const checkInRoutes: Routes = [
  {
    path: "",
    component: CheckInListComponent,
    data: {
      breadcrumb: "Check-In",
    },
  },
];