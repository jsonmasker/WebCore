import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ButtonDirective, CardBodyComponent, CardComponent, CollapseDirective, FormCheckComponent, FormControlDirective, FormDirective, FormLabelDirective } from '@coreui/angular';
import {ModuleModel} from '@models/system-management-models/role.model';
import {cilArrowThickBottom,cilArrowThickRight} from '@coreui/icons';
import { IconDirective } from '@coreui/icons-angular';
import { RoleService } from '@services/system-services/role.service';
import { ToastService } from '@services/helper-services/toast.service';
import { EColors } from '@common/global';

@Component({
  selector: 'app-update',
  standalone: true,
  imports: [FormDirective, FormLabelDirective,
    FormControlDirective, ButtonDirective, CollapseDirective, IconDirective,
    RouterLink, CardComponent, CardBodyComponent, NgFor, NgIf,
    FormCheckComponent, ReactiveFormsModule],
  templateUrl: './update.component.html',
  styleUrl: './update.component.scss'
})
export class UpdateComponent implements OnInit {
  //public slideTheme: RoleModel = new RoleModel();
  icons = {cilArrowThickBottom,cilArrowThickRight};
  modules: ModuleModel[] = [];
  visible: Array<boolean> = [];
  updateForm : FormGroup = new FormGroup({
    id: new FormControl(0),
    name : new FormControl('',[Validators.required]),
    description : new FormControl(''),
    isActive: new FormControl(true),
    //selectedRoleClaims: new FormGroup(),
  });
  constructor(private roleService : RoleService,private router: Router, private toastService : ToastService, private route: ActivatedRoute) {}
  ngOnInit(): void {
    const id:any = this.route.snapshot.paramMap.get('id');
    this.roleService.getById(id).subscribe((res) => {
      this.updateForm.patchValue(res.data);
    });
  }

  toggleCollapse(id:number){
    this.visible[id] = !this.visible[id];
  }
  onSubmit() {
    this.roleService.updateRole(this.updateForm.value).subscribe(
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

