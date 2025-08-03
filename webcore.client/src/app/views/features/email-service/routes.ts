import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./email-service.component').then(m => m.EmailServiceComponent),
    data: {
      title: $localize`Email Service`
    }
  }
];

