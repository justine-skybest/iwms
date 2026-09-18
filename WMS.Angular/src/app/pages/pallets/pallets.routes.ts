import type { Routes } from "@angular/router";
import { PalletsListComponent } from "./pallets-list.component";

export const palletsRoutes: Routes = [
  {
    path: "",
    component: PalletsListComponent,
    data: {
      breadcrumb: "Pallets",
    },
  },
];