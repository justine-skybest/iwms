import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { MobileAppComponent } from './pages/mobile-app/mobile-app.component';
import { AuthGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  // 1. Public Route
  { 
    path: 'login', 
    component: LoginComponent,
    data: { hideLayout: true }
  },

  // 2. Protected Business Routes Group (Requires Auth)
  {
    path: '',
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
      },
      {
        path: 'home',
        loadChildren: () => import('./pages/home/home.routes').then((m) => m.homeRoutes),
      },
      {
        path: 'products',
        loadChildren: () => import('./pages/products/products.routes').then((m) => m.productsRoutes),
        title: 'Products'
      },
      {
        path: 'warehouses',
        loadChildren: () => import('./pages/warehouses/warehouses.routes').then((m) => m.warehousesRoutes),
        title: 'Warehouses'
      },
      {
        path: 'warehouse-3d',
        loadComponent: () => import('./pages/warehouses/warehouse-3d-viewer.component').then(m => m.Warehouse3DViewerComponent),
        data: { hideLayout: true, breadcrumb: '3D Warehouse Viewer' },
      },
      {
        path: 'pallets',
        loadChildren: () => import('./pages/pallets/pallets.routes').then((m) => m.palletsRoutes),
        title: 'Pallets'
      },
      {
        path: 'incoming',
        loadChildren: () => import('./pages/incoming/incoming.routes').then((m) => m.incomingRoutes),
        title: 'Incoming'
      },
      {
        path: 'receiving',
        loadChildren: () => import('./pages/receiving/receiving.routes').then((m) => m.receivingRoutes),
        title: 'Receiving'
      },
      {
        path: 'check-in',
        loadChildren: () => import('./pages/check-in/check-in.routes').then((m) => m.checkInRoutes),
        title: 'Checkin'
      },
      {
        path: 'pick-order',
        loadChildren: () => import('./pages/pick-order/pick-order.routes').then((m) => m.pickOrderRoutes),
        title: 'Pick-Order'
      },
      // {
      //   path: 'reconcillation-report',
      //   loadChildren: () => import('./pages/reports/receiving-reconciliation-report/receiving-reconciliation.routes').then((m) => m.reconcillationRoutes),
      //   title: 'Reconciliation Report'
      // },
      {
        path: 'receiving-reports',
        loadChildren: () => import('./pages/reports/receiving-report-generation/receiving-report.routes').then((m) => m.receivingReportRoutes),
        title: 'Receiving Reports'
      },
      {
        path: 'pickorder-reports',
        loadChildren: () => import('./pages/reports/pick-orders-report-generation/pick-orders-report-generation.routes').then((m) => m.pickOrderReportRoutes),
        title: 'Pick Order Reports'
      },
      {
        path: 'warehouse-occupancy',
        loadChildren: () => import('./pages/reports/warehouse-occupancy/warehouse-occupancy.routes').then((m) => m.warehouseOccupancyRoutes),
        title: 'Warehouse Occupancy'
      },
      {
        path: 'mobile',
        component: MobileAppComponent,
        data: { hideLayout: true, breadcrumb: 'Mobile Operations' },
        title: 'Mobile Operations'
      },
      {
        path: 'audit-logs',
        loadChildren: () => import('./pages/audit-logs/audit-logs.routes').then((m)=>m.auditLogsRoutes),
        title: 'Audit Logs'
      }
    ]
  },

  // 3. Fallback Route
  { path: '**', redirectTo: 'home' }
];