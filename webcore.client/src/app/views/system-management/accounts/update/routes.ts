import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./update.component').then(m => m.UpdateComponent),
    data: {
      title: $localize`Accounts / Update`
    }
  }
];

