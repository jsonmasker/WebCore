import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ButtonDirective, CardBodyComponent, CardComponent, CollapseDirective, FormCheckComponent, FormControlDirective, FormDirective, FormLabelDirective } from '@coreui/angular';
import {ModuleModel} from '@models/system-management-models/role.model';
import {cilArrowThickBottom,cilArrowThickRight} from '@coreui/icons';
import { IconDirective } from '@coreui/icons-angular';
import { RoleService } from '@services/system-services/role.service';
import { ToastService } from '@services/helper-services/toast.service';
import { EColors } from '@common/global';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [FormDirective, FormLabelDirective,
    FormControlDirective, ButtonDirective, CollapseDirective, IconDirective,
    RouterLink, CardComponent, CardBodyComponent, NgFor, NgIf,
    FormCheckComponent, ReactiveFormsModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.scss'
})
export class CreateComponent implements OnInit {
  //public slideTheme: RoleModel = new RoleModel();
  icons = {cilArrowThickBottom,cilArrowThickRight};
  modules: ModuleModel[] = [];
  visible: Array<boolean> = [];
  createForm : FormGroup = new FormGroup({
    name : new FormControl('',[Validators.required]),
    description : new FormControl(''),
    isActive: new FormControl(true),
    //selectedRoleClaims: new FormGroup(),
  });
  constructor(private roleService : RoleService,private router: Router, private toastService : ToastService) {}
  ngOnInit(): void {
    //this.getModules();
  }

  toggleCollapse(id:number){
    this.visible[id] = !this.visible[id];
  }
  onSubmit() {
    this.roleService.createRole(this.createForm.value).subscribe(
      (result) => {
        this.toastService.showToast(EColors.success, result.message);
        this.router.navigate(['/system-management/extension/roles'])
      },
      (failure) => {
        this.toastService.showToast(EColors.danger, failure.error.message);
      }
    );
  }
}
