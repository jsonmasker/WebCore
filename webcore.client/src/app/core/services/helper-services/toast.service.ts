import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ToastService {
  private toastRequest = new Subject<{ color: string; message: string }>();

  toastRequest$ = this.toastRequest.asObservable();

  showToast(color: string, message: string) {
    this.toastRequest.next({ color, message });
  }
}
