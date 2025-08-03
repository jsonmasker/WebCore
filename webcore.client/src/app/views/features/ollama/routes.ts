import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./ollama.component').then(m => m.OllamaComponent),
    data: {
      title: $localize`Ollama`
    }
  }
];