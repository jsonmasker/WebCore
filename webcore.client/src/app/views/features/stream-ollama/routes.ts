import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./stream-ollama.component').then(m => m.StreamOllamaComponent),
    data: {
      title: $localize`Stream Ollama`
    }
  }
];