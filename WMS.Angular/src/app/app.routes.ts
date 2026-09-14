import { Routes } from '@angular/router';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { LoginComponent } from './pages/login/login.component';
import { PlaceholderComponent } from './pages/placeholder/placeholder.component';
import { MobileAppComponent } from './pages/mobile-app/mobile-app.component';


export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: "home",
    loadChildren: () => import("./pages/home/home.routes").then((m) => m.homeRoutes),
  },
  { path: 'mobile', component: MobileAppComponent },
  { path: '**', redirectTo: 'login' }
];