import { Routes } from '@angular/router';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { LoginComponent } from './pages/login/login.component';
import { PlaceholderComponent } from './pages/placeholder/placeholder.component';
import { MobileAppComponent } from './pages/mobile-app/mobile-app.component';


export const routes: Routes = [
  { path: 'login', component: LoginComponent,
    data: { hideLayout: true},
  },
  {
    path: 'home',
    loadChildren: () => import("./pages/home/home.routes").then((m) => m.homeRoutes),
  },
  {
    path: 'products',
    loadChildren: () => import("./pages/products/products.routes").then((m) => m.productsRoutes),
  },
  {
    path: 'warehouses',
    loadChildren: () => import("./pages/warehouses/warehouses.routes").then((m) => m.warehousesRoutes),
  },
  {
    path: 'warehouse-3d',
    loadComponent: () => import('./pages/warehouses/warehouse-3d-viewer.component').then(m => m.Warehouse3DViewerComponent),
    data: { hideLayout: true, breadcrumb: '3D Warehouse Viewer' },
  },
  {
    path: 'pallets',
    loadChildren: () => import("./pages/pallets/pallets.routes").then((m) => m.palletsRoutes),
  },
  {
    path: 'receiving',
    loadChildren: () => import("./pages/receiving/receiving.routes").then((m) => m.receivingRoutes),
  },
  {
    path: 'check-in',
    loadChildren: () => import("./pages/check-in/check-in.routes").then((m) => m.checkInRoutes),
  },
  {
    path: 'pick-order',
    loadChildren: () => import("./pages/pick-order/pick-order.routes").then((m) => m.pickOrderRoutes),
  },
  {
    path: 'mobile',
    component: MobileAppComponent,
    data: { hideLayout: true, breadcrumb: 'Mobile Operations' },
  },
  { path: '**', redirectTo: 'home' }
];