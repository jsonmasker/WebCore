import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ButtonCloseDirective, ButtonDirective, CardBodyComponent, CardComponent, CardHeaderComponent, FormCheckComponent, FormControlDirective, FormDirective, FormLabelDirective, ModalBodyComponent, ModalComponent, ModalFooterComponent, ModalHeaderComponent, ModalTitleDirective, ModalToggleDirective, TableDirective } from '@coreui/angular';
import { cilCloudUpload } from '@coreui/icons';
import { IconDirective } from '@coreui/icons-angular';
import { ActionModel } from '@models/system-management-models/module.model';
import { ActionService } from '@services/system-services/action.service';

@Component({
  selector: 'app-settings',
  imports: [TableDirective, CardComponent, ModalBodyComponent, NgFor, NgIf, FormControlDirective, FormLabelDirective,
    ModalComponent, ButtonDirective, FormDirective, ReactiveFormsModule,
    ModalFooterComponent, ButtonCloseDirective, ModalHeaderComponent,
    CardBodyComponent, CardHeaderComponent],
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.scss'
})
export class SettingsComponent {
  visibleCreateModal: boolean = false;
  visibleUpdateModal: boolean = false;
  visibleDelete: boolean = false;
  deleteById: number = 0;
  actionList: ActionModel[] = [];
  reviewCreateUploadImage: string = '';
  reviewUpdateUploadImage: string = '';
  icons : any = {cilCloudUpload};

  updateForm: FormGroup = new FormGroup({
    id: new FormControl(0, Validators.required),
    name: new FormControl('', Validators.required),
    label: new FormControl('', Validators.required),

  });

  constructor(private actionService : ActionService) {}
  ngOnInit(): void {
    this.getData();
  }

  getData(){
    // this.brandService.getAll().subscribe((res) => {
    //   this.brandList = res;
    // });
  }



//#region  Update Form
updateData(id: number) {
  // this.brandService.getById(id).subscribe((res) => {
  //   this.updateForm.patchValue(res);
  //   this.toggleLiveUpdateModel();
  //   if(res.avatar){
  //     this.reviewUpdateUploadImage = `<img src="https://localhost:7025/Brands/${res.avatar}" alt="Image Preview" class="mw-100 mh-100"/>`;
  //   }else{
  //     this.reviewUpdateUploadImage = '';
  //   }
  // });
}
onSubmitUpdateForm() {
  if (this.updateForm.valid) {
    // const formData = new FormData();
    // formData.append('id', this.updateForm.value.id);
    // formData.append('nameEN', this.updateForm.value.nameEN);
    // formData.append('nameVN', this.updateForm.value.nameVN);
    // formData.append('note', this.updateForm.value.note);
    // formData.append('priority', this.updateForm.value.priority);
    // formData.append('isActive', this.updateForm.value.isActive);
    // formData.append('imageFile', this.updateForm.value.imageFile);

    // this.brandService.update(formData).subscribe(() => {
    //   this.toggleLiveUpdateModel();
    //   this.getData();
    // });
  }
}

toggleLiveUpdateModel() {
  this.visibleUpdateModal = !this.visibleUpdateModal;
}

handleLiveUpdateModelChange(event: any) {
  this.visibleUpdateModal = event;
}

get nameUpdateForm() { return this.updateForm.get('name'); }
get labelUpdateForm() { return this.updateForm.get('label'); }

//#endregion

}
