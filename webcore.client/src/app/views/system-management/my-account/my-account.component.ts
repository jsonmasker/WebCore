import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '@services/system-services/authentication.service';
import { EyeIconComponent } from '@components/icons/eye-icon.component';
import { EyeCloseIconComponent } from '@components/icons/eye-close-icon.component';
import { RoleService } from '@services/system-services/role.service'
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RoleModel } from '@models/system-management-models/role.model';
import { MyAccountService } from '@services/system-services/my-account.service';
import { ButtonCloseDirective, ButtonDirective, CardBodyComponent, CardComponent, CardHeaderComponent, FormControlDirective, FormDirective, FormLabelDirective, FormSelectDirective, ModalBodyComponent, ModalComponent, ModalFooterComponent, ModalHeaderComponent, ModalTitleDirective, ModalToggleDirective, ToastBodyComponent, ToastComponent, ToasterComponent, ToastHeaderComponent } from '@coreui/angular';
import { NgFor, NgIf } from '@angular/common';
import { Router } from '@angular/router';
import { AccountErrorModel, AccountModel } from '@models/system-management-models/account.model';
import { AccountService } from '@services/system-services/account.service'
@Component({
  selector: 'app-my-account',
  standalone: true,
  imports: [ToasterComponent, ToastHeaderComponent, ToastComponent,NgFor,ButtonCloseDirective,
     EyeCloseIconComponent, EyeIconComponent, ReactiveFormsModule,FormControlDirective,
    ModalComponent, ModalFooterComponent, NgIf, CardBodyComponent,FormSelectDirective,
     CardHeaderComponent, CardComponent, FormDirective, FormLabelDirective,
    ModalHeaderComponent, ModalTitleDirective, ModalBodyComponent, ToastBodyComponent, ButtonDirective],
  templateUrl: './my-account.component.html',
  styleUrl: './my-account.component.scss'
})
export class MyAccountComponent implements OnInit {
  roles : RoleModel[] = [];
  formData : FormGroup = new FormGroup({
    id : new FormControl(-1),
    mallId : new FormControl(-1),
    officeId : new FormControl(-1),
    roleId : new FormControl(-1,Validators.min(1)),
    userName : new FormControl(''),
    email : new FormControl(''),
    phoneNumber : new FormControl(''),
    password : new FormControl(''),
    isActive: new FormControl(true),
  });
  changePasswordForm: FormGroup = new FormGroup({
    userId: new FormControl(-1),
    oldPassword: new FormControl('', [Validators.required]),
    newPassword: new FormControl('', [Validators.required, Validators.minLength(6)]),
    confirmPassword: new FormControl('', [Validators.required, Validators.minLength(6)]),
    error: new FormControl('')
  });
  visibleToast: boolean = false;
  changePasswordFormError: string = '';
  visibleChangePassword: boolean = false;
  showOldPassword: boolean = false;
  showNewPassword: boolean = false;
  showConfirmPassword: boolean = false;
  constructor(private authentication: AuthenticationService,private roleService : RoleService,private accountService : AccountService,
     private myAccountService: MyAccountService, private router: Router) {
  }
  ngOnInit(): void {
    const id:any =this.authentication.getUserId();
    // this.roleService.getRoles().subscribe((res: RoleModel[]) => {
    //   this.roles = res;
    // });
    this.accountService.getAccountById(id).subscribe((res) => {
      this.formData.patchValue(res.data);
    });
  }
  toggleToast() {
    this.visibleToast = !this.visibleToast;
  }
  onVisibleChange($event: boolean) {
    this.visibleToast = $event;
  }
  toggleChangePassword() {
    this.visibleChangePassword = !this.visibleChangePassword;
  }

  handleChangePasswordChange(event: any) {
    this.visibleChangePassword = event;
  }
  onSubmitChangePassword() {
    let userId = this.authentication.getUserId();
    this.changePasswordForm.value.userId = userId;
    if (this.changePasswordForm.value.newPassword != this.changePasswordForm.value.confirmPassword) {
      this.changePasswordFormError = $localize`:@@passwordDoesNotMatch:Password does not match`;
      return;
    }
    this.myAccountService.changePassword(this.changePasswordForm.value).subscribe(() => {
      this.changePasswordForm.reset();
      //this model staticBackdropModal will be used to close the modal
      this.toggleChangePassword();
      this.toggleToast();
    }, (error: any) => {
      console.log(error);
      this.changePasswordFormError = $localize`:@@oldPasswordIsIncorrect:Old password is incorrect`;
    });
  }

  ShowPassword(id: string) {
    const passwordInput = document.getElementById(id);
    if (passwordInput && id == 'newPassword') {
      passwordInput.setAttribute('type', this.showNewPassword ? 'password' : 'text');
      this.showNewPassword = !this.showNewPassword
    }
    else if (passwordInput && id == 'oldPassword') {
      passwordInput.setAttribute('type', this.showOldPassword ? 'password' : 'text');
      this.showOldPassword = !this.showOldPassword
    }
    else if (passwordInput && id == 'confirmPassword') {
      passwordInput.setAttribute('type', this.showConfirmPassword ? 'password' : 'text');
      this.showConfirmPassword = !this.showConfirmPassword
    }
  }
  get oldPassword() { return this.changePasswordForm.get('oldPassword'); }
  get newPassword() { return this.changePasswordForm.get('newPassword'); }
  get confirmPassword() { return this.changePasswordForm.get('confirmPassword'); }

}
