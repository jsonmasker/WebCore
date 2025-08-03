import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  private visible = new Subject<{ show: boolean;}>();

  visible$ = this.visible.asObservable();

  showLoadingComponent(show: boolean) {
    this.visible.next({show});
  }
}
