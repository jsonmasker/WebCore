import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./my-account.component').then(m => m.MyAccountComponent),
    data: {
      title: $localize`:@@myAccount:My Account`
    }
  }
];

