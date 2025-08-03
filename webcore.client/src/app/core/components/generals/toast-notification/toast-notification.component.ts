import { Component, Input, OnInit, ViewChild, viewChild } from '@angular/core';

import { ToasterComponent, ToasterPlacement } from '@coreui/angular';
import { AppToastComponent } from './toast-simple/toast.component';
import { ToastService } from '@services/helper-services/toast.service';
import { cibPagekit } from '@coreui/icons';
@Component({
  selector: 'app-toast-notification',
  imports: [ToasterComponent],
  templateUrl: './toast-notification.component.html',
  styleUrl: './toast-notification.component.scss'
})

export class ToastNotificationComponent implements OnInit {
  placement = ToasterPlacement.TopEnd;
  @ViewChild(ToasterComponent) toaster!: ToasterComponent;

  constructor(private toastService: ToastService) {}

  ngOnInit() {
    this.toastService.toastRequest$.subscribe(({ color, message }) => {
      this.addToast(color, message);
    });
  }

  addToast(color: string, message: string) {
    const options = {
      message,
      delay: 5000,
      placement: this.placement,
      color,
      autohide: true
    };

    if (this.toaster) {
      this.toaster.addToast(AppToastComponent, { ...options });
    }
  }
}