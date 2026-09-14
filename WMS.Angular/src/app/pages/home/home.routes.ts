import type { Routes } from "@angular/router";
import { HomeComponent } from "./home";

export const homeRoutes: Routes = [
  {
    path: "",
    component: HomeComponent,
    data: {
      breadcrumb: "Home",
    },
  },
];
