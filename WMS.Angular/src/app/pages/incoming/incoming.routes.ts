import type { Routes } from "@angular/router";
import { IncomingListComponent } from "./incoming-list.component";

export const incomingRoutes: Routes = [
  {
    path: "",
    component: IncomingListComponent,
    data: {
      breadcrumb: "Item Receipt",
    },
  },
];