import { Routes } from '@angular/router';
import { DefaultLayoutComponent } from './layout';
import { LoginComponent } from './views/pages/login/login.component';
import { authGuard } from './core/guards/auth.guard';
import { authenticationGuard } from './core/guards/authentication.guard';

export const routes: Routes = [
  {
    path: '',
    //redirectTo: 'dashboard',
    component: LoginComponent,
    //pathMatch: 'full'
    canActivate: [authGuard],
  },
  {
    path: '',
    component: DefaultLayoutComponent,
    canActivate: [authenticationGuard],
    data: {
      title: 'Home'
    },
    children: [
      {
        path: 'introduction',
        loadChildren: () => import('./views/introduction/routes').then((m) => m.routes)
      },
      {
        path: 'dashboard',
        loadChildren: () => import('./views/dashboard/routes').then((m) => m.routes)
      },
       //#region System Management
      //account management
      {
        path: 'my-account',
        loadChildren: () => import('./views/system-management/my-account/routes').then((m) => m.routes)
      },
      {
        path: 'accounts',
        loadChildren: () => import('./views/system-management/accounts/index/routes').then((m) => m.routes)
      },
      {
        path: 'accounts/create',
        loadChildren: () => import('./views/system-management/accounts/create/routes').then((m) => m.routes)
      },
      {
        path: 'accounts/update/:id',
        loadChildren: () => import('./views/system-management/accounts/update/routes').then((m) => m.routes)
      },
      {
        path: 'logs',
        loadChildren: () => import('./views/system-management/logging/routes').then((m) => m.routes)
      },
      {
        path: 'system-management/extension',
        loadChildren: () => import('./views/system-management/extension/routes').then((m) => m.routes)
      },
      //#endregion
    ]
  },
    {
    path: '404',
    loadComponent: () => import('./views/pages/page404/page404.component').then(m => m.Page404Component),
    data: {
      title: 'Page 404'
    }
  },
  {
    path: '423',
    loadComponent: () => import('./views/pages/page423/page423.component').then(m => m.Page423Component),
    data: {
      title: 'Page 423'
    }
  },
  {
    path: '500',
    loadComponent: () => import('./views/pages/page500/page500.component').then(m => m.Page500Component),
    data: {
      title: 'Page 500'
    }
  },
  {
    path: 'login',
    loadComponent: () => import('./views/pages/login/login.component').then(m => m.LoginComponent),
    data: {
      title: 'Login Page'
    }
  },
  {
    path: 'recover-password',
    loadComponent: () => import('./views/pages/recover-password/recover-password.component').then(m => m.RecoverPasswordComponent),
    data: {
      title: 'Reover Password Page'
    }
  },
  {
    path: 'reset-password',
    loadComponent: () => import('./views/pages/reset-password/reset-password.component').then(m => m.ResetPasswordComponent),
    data: {
      title: 'Reset Password Page'
    }
  },
  { path: '**', redirectTo: 'dashboard' }
];
