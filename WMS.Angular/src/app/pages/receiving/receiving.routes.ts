import type { Routes } from "@angular/router";
import { ReceivingListComponent } from "./receiving-list.component";

export const receivingRoutes: Routes = [
  {
    path: "",
    component: ReceivingListComponent,
    data: {
      breadcrumb: "Item Receipt",
    },
  },
];