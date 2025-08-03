import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./index.component').then(m => m.IndexComponent),
    data: {
      title: $localize`Accounts`
    }
  }
];

