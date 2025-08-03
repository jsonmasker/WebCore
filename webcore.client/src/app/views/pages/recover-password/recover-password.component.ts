import { Component, ViewEncapsulation } from '@angular/core';
import { IconDirective } from '@coreui/icons-angular';
import { InputGroupComponent, InputGroupTextDirective, FormControlDirective, ButtonDirective } from '@coreui/angular';
import { FormControl, FormGroup, ReactiveFormsModule, Validators  } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router, RouterLink } from '@angular/router';

import { MyAccountService } from '@services/system-services/my-account.service';
import { ToastService } from '@services/helper-services/toast.service';
import { EColors } from '@common/global';
import { timer } from 'rxjs';
import { CommonModule } from '@angular/common';
import { ParticleCanvasComponent } from '@components/generals/particle-canvas/particle-canvas.component';

@Component({
  selector: 'app-recover-password',
  standalone: true,
  imports: [
    InputGroupComponent,CommonModule,
    InputGroupTextDirective, IconDirective,
    FormControlDirective, ButtonDirective, ParticleCanvasComponent,
    ReactiveFormsModule, RouterLink ],
  templateUrl: './recover-password.component.html',
  encapsulation: ViewEncapsulation.None 
})
export class RecoverPasswordComponent {
  recoverPasswordForm: FormGroup = new FormGroup({
    email: new FormControl('',[Validators.required, Validators.email])
  });
  constructor(private myAccountSerVice : MyAccountService,private toastService : ToastService, private router : Router) { }
  onSubmit() {
    if (this.recoverPasswordForm.invalid) {
      return;
    }
    this.myAccountSerVice.recoverPassword(this.recoverPasswordForm.value.email).subscribe(
      (response: any) => {
        this.toastService.showToast(EColors.success, response.message);
        this.recoverPasswordForm.reset();
        timer(5000).subscribe(() => {
          this.router.navigate(['/login']);
        });
      },
      (exception: any) => {
        this.toastService.showToast(EColors.danger, exception.error.message);
      }
    );
  }
  get email() { return this.recoverPasswordForm.get('email'); }
}
