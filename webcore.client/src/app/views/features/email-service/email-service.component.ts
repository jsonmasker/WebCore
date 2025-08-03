import { Component } from '@angular/core';
import { CardBodyComponent, CardComponent } from '@coreui/angular';

@Component({
  selector: 'app-email-service',
  imports:[ CardComponent, CardBodyComponent],
  templateUrl: './email-service.component.html',
  styleUrl: './email-service.component.scss'
})
export class EmailServiceComponent {

}
