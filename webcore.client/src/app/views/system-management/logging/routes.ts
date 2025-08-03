import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./logging.component').then(m => m.LoggingComponent),
    data: {
      title: $localize`Accounts / Update`
    }
  }
];

