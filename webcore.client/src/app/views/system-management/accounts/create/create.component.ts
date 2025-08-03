import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ButtonDirective, CardBodyComponent, CardComponent, FormCheckComponent, FormControlDirective, FormDirective, FormLabelDirective, FormSelectDirective } from '@coreui/angular';
import {AccountErrorModel, AccountModel } from '@models/system-management-models/account.model';
import { RoleModel } from '@models/system-management-models/role.model';
import { AccountService } from '@services/system-services/account.service'
import { RoleService } from '@services/system-services/role.service'
import { userNameValidator } from '@common/validations/username.validator';
import { phoneNumberValidator } from '@common/validations/phonenumber.validator';
import { fullNameValidator } from '@common/validations/fullname.validator';
import { ToastService } from '@services/helper-services/toast.service';
import { EColors } from '@common/global';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [ FormDirective, FormLabelDirective, NgFor, NgIf,
    FormControlDirective, ButtonDirective,FormSelectDirective,
     RouterLink, CardComponent, CardBodyComponent,
      FormCheckComponent, ReactiveFormsModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.scss'
})
export class CreateComponent implements OnInit {  
  roles : RoleModel[] = [];
  errorModel: AccountErrorModel = {
    //fullName: [],
    userName: [],
    email: [],
    phoneNumber: [],
    password: [],
    roleId: [],
  };
  formData : FormGroup = new FormGroup({
    mallId : new FormControl(-1),
    officeId : new FormControl(-1),
    roleId : new FormControl(-1,Validators.min(1)),
    //fullName : new FormControl('',[Validators.required, fullNameValidator()]),
    userName : new FormControl('',[Validators.required, userNameValidator()]),
    email : new FormControl('',[Validators.required, Validators.email]),
    phoneNumber : new FormControl('',phoneNumberValidator()),
    password : new FormControl('',[Validators.required, Validators.minLength(6),Validators.maxLength(20)]),
    isActive: new FormControl(true),
  });
  
  constructor(private accountService : AccountService, private roleService : RoleService,private router: Router, private toastService: ToastService) {}

  ngOnInit(): void {
    this.roleService.getAllActive().subscribe((res) => {
      this.roles = res.data;
    });
  }

  onSubmit() {
    this.accountService.createAccount(this.formData.value).subscribe(() => {
      this.router.navigate(['/accounts']);
    },(failure) => {
      // this.errorModel.email = errObj?.error?.errors?.Email;
      // this.errorModel.userName = errObj?.error?.errors?.UserName;
      // this.errorModel.phoneNumber = errObj?.error?.errors?.PhoneNumber;
      // this.errorModel.roleId = errObj?.error?.errors?.RoleId;
      this.toastService.showToast(EColors.danger, failure.error.message);
    });
  }
  
  get fullName() {
    return this.formData.get('fullName');
  }
  get userName() {
    return this.formData.get('userName');
  }
  get email() {
    return this.formData.get('email');
  }
  get phoneNumber() {
    return this.formData.get('phoneNumber');
  }
  get password() {
    return this.formData.get('password');
  }
  get roleId() {
    return this.formData.get('roleId');
  }

}
