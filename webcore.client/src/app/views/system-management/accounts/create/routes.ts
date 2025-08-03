import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./create.component').then(m => m.CreateComponent),
    data: {
      title: $localize`Accounts / Create`
    }
  }
];

