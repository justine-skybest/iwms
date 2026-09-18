import type { Routes } from "@angular/router";
import { ProductsListComponent } from "./products-list.component";

export const productsRoutes: Routes = [
  {
    path: "",
    component: ProductsListComponent,
    data: {
      breadcrumb: "Products",
    },
  },
];