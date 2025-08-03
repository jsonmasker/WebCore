import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./ai-chatbot.component').then(m => m.AiChatbotComponent),
    data: {
      title: $localize`AI Chatbot`,
    }
  }
];