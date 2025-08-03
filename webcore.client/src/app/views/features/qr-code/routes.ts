import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./qr-code.component').then(m => m.QrCodeComponent),
    data: {
      title: $localize`QR Code`
    }
  }
];

