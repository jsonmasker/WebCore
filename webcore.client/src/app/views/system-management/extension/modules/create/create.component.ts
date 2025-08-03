import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ButtonDirective, CardBodyComponent, CardComponent, FormCheckComponent,
  AccordionButtonDirective,
  AccordionComponent,
  AccordionItemComponent,
  TemplateIdDirective,
   FormControlDirective, FormDirective, FormLabelDirective, FormSelectDirective, 
   ButtonCloseDirective,
   ModalBodyComponent,
   ModalComponent,
   ModalFooterComponent,
   ModalHeaderComponent,
   ModalTitleDirective,
   ThemeDirective,
   TableDirective} from '@coreui/angular';
import {AccountErrorModel, AccountModel } from '@models/system-management-models/account.model';
import { RoleModel } from '@models/system-management-models/role.model';
import { AccountService } from '@services/system-services/account.service'
import { RoleService } from '@services/system-services/role.service'
import { userNameValidator } from '@common/validations/username.validator';
import { phoneNumberValidator } from '@common/validations/phonenumber.validator';
import { ActionService } from '@services/system-services/action.service';
import { ActionModel } from '@models/system-management-models/module.model';
@Component({
  selector: 'app-create',
  imports: [ FormDirective, FormLabelDirective, NgFor, TableDirective,
    FormControlDirective, ButtonDirective, AccordionComponent,
    AccordionItemComponent,TemplateIdDirective,AccordionButtonDirective, FormCheckComponent,
     RouterLink, CardComponent, CardBodyComponent,
     ModalComponent, ModalHeaderComponent, ModalTitleDirective, ThemeDirective,
      ButtonCloseDirective, ModalBodyComponent, ModalFooterComponent,
      FormCheckComponent, ReactiveFormsModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.scss'
})
export class CreateComponent {
  public visible = false;
  actionList: ActionModel[] = [];
  createForm : FormGroup = new FormGroup({
    id: new FormControl(0),
    name : new FormControl(""),
    label: new FormControl(""),
    description : new FormControl(""),
    priority: new FormControl(1),
    isActive: new FormControl(true),
    controllers: new FormControl([]),
  });
  controllerForm : FormGroup = new FormGroup({
    id: new FormControl(0),
    name : new FormControl(""),
    label: new FormControl(""),
    priority: new FormControl(1),
    controllerActions: new FormControl([])
  });


  constructor(private actionService : ActionService, private roleService: RoleService) {}

  ngOnInit(): void {
    this.actionService.getAllActive().subscribe((res) => {
      this.actionList = res.data;
    })
  }


  toggleLiveDemo() {
    this.visible = !this.visible;
  }

  handleLiveDemoChange(event: any) {
    this.visible = event;
  }


  onSubmit() {}
}
