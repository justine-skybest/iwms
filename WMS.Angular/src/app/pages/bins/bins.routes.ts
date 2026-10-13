import type { Routes } from "@angular/router";
import { BinsComponent } from "./bins.component";

export const binRoutes: Routes = [
  {
    path: "",
    component: BinsComponent,
    data: {
      breadcrumb: "Bins",
    },
  },
];