import type { Routes } from "@angular/router";
import { ChangelogComponent } from "./changelog.component";

export const changelogRoutes: Routes = [
  {
    path: "",
    component: ChangelogComponent,
    data: {
      breadcrumb: "Changelog",
    },
  },
];