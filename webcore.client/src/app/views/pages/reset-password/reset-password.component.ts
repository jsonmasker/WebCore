import { Component, ViewEncapsulation } from '@angular/core';
import { IconDirective } from '@coreui/icons-angular';
import { InputGroupComponent, InputGroupTextDirective, FormControlDirective, ButtonDirective } from '@coreui/angular';
import { AbstractControl, FormControl, FormGroup, ReactiveFormsModule, ValidationErrors, Validators  } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { MyAccountService } from '@services/system-services/my-account.service';
import { NgIf } from '@angular/common';
import { ToastService } from '@services/helper-services/toast.service';
import { EyeIconComponent } from '@components/icons/eye-icon.component';
import { EyeCloseIconComponent } from '@components/icons/eye-close-icon.component';
import { EColors } from '@common/global';
import { timer } from 'rxjs';
import { ParticleCanvasComponent } from '@components/generals/particle-canvas/particle-canvas.component';

@Component({
  selector: 'app-reset-password',
  standalone: true,
  imports:[InputGroupComponent, NgIf,
    InputGroupTextDirective, IconDirective,EyeIconComponent, EyeCloseIconComponent,
    FormControlDirective, ButtonDirective, ParticleCanvasComponent,
    ReactiveFormsModule],
  templateUrl: './reset-password.component.html',
  //styleUrl: './reset-password.component.scss',
  encapsulation: ViewEncapsulation.None 
})
export class ResetPasswordComponent {
  showPassword = false;
  showConfirmPassword = false;
  emailParam: string = '';
  tokenParam: string = '';
  resetPasswordForm = new FormGroup(
    {
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
      confirmPassword: new FormControl('', [Validators.required, Validators.minLength(6)])
    },
    { validators: this.passwordsMatchValidator } // ✅ Apply the custom validator
  );
  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.tokenParam = params['token']?.replace(/ /g, '+'); // Fix '+' issue
      this.emailParam = params['email'];
    });
    if (!this.tokenParam || !this.emailParam) {
      this.router.navigate(['/login']);
    }
  }
  constructor(private myAccountService : MyAccountService, private router: Router, private toastService : ToastService, private route: ActivatedRoute) { }
  onSubmit() {
    if (this.resetPasswordForm.invalid) {
      return;
    }
    let password = this.resetPasswordForm.value.password;
    let confirmPassword = this.resetPasswordForm.value.confirmPassword;
    this.myAccountService.resetPassword(this.tokenParam, this.emailParam, password, confirmPassword).subscribe(
      (response) => {
        this.toastService.showToast(EColors.success, response.message);
         timer(3000).subscribe(() => {
            this.router.navigate(['/login']);
          });
      },
      (exception) => {
        console.log(exception);
        this.toastService.showToast(EColors.danger, exception.error.message);
      }
    );
  }
  ShowPassword() {
    const passwordInput = document.getElementById('password');
    if (passwordInput) {
      passwordInput.setAttribute('type', this.showPassword ? 'password' : 'text');
    }
    this.showPassword = !this.showPassword
  }
  ShowConfirmPassword() {
    const confirmPassword = document.getElementById('confirmPassword');
    if (confirmPassword) {
      confirmPassword.setAttribute('type', this.showConfirmPassword ? 'password' : 'text');
    }
    this.showConfirmPassword = !this.showConfirmPassword
  }
  get password() {
    return this.resetPasswordForm.get('password');
  }

  get confirmPassword() {
    return this.resetPasswordForm.get('confirmPassword');
  }
   // ✅ Custom Validator: Check if passwords match
   private passwordsMatchValidator(form: AbstractControl): ValidationErrors | null {
    const password = form.get('password')?.value;
    const confirmPassword = form.get('confirmPassword')?.value;
    return password === confirmPassword ? null : { passwordsMismatch: true };
  }
}
