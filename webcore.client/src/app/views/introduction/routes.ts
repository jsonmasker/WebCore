import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./introduction.component').then(m => m.IntroductionComponent),
    data: {
      title: "Introduction"
    }
  }
];

