import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Extend'
    },
    children: [
      {
        path: '',
        redirectTo: 'modules',
        pathMatch: 'full'
      },
      {
        path: 'roles',
        loadComponent: () => import('./roles/index/index.component').then(m => m.IndexComponent),
        data: {
          title: 'Roles'
        }
      },
      {
        path: 'roles/create',
        loadComponent: () => import('./roles/create/create.component').then(m => m.CreateComponent),
        data: {
          title: 'Create Roles'
        }
      },
      {
        path: 'roles/update/:id',
        loadComponent: () => import('./roles/update/update.component').then(m => m.UpdateComponent),
        data: {
          title: 'Update Roles'
        }
      },
      {
        path: 'modules',
        loadComponent: () => import('./modules/index/index.component').then(m => m.IndexComponent),
        data: {
          title: 'Modules'
        }
      },
      {
        path: 'modules/create',
        loadComponent: () => import('./modules/create/create.component').then(m => m.CreateComponent),
        data: {
          title: 'Create Module'
        }
      },
      {
        path: 'modules/update/:id',
        loadComponent: () => import('./modules/update/update.component').then(m => m.UpdateComponent),
      },
      {
        path: 'actions',
        loadComponent: () => import('./actions/actions.component').then(m => m.ActionsComponent),
        data: {
          title: 'Actions'
        }
      },
      {
        path: 'settings',
        loadComponent: () => import('./settings/settings.component').then(m => m.SettingsComponent),
        data: {
          title: 'Settings'
        }
      }  
    ]
  }
];


