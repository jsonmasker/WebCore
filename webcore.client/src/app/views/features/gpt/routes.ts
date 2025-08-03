import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./gpt.component').then(m => m.ChatGPTComponent),
    data: {
      title: $localize`ChatGPT`
    }
  }
];