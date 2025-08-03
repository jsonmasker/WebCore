import { NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { EColors } from '@common/global';
import { ButtonDirective, CardBodyComponent, CardComponent, CardHeaderComponent, FormCheckComponent, FormControlDirective, FormDirective, FormLabelDirective, FormSelectDirective, TableDirective } from '@coreui/angular';
import { cilCloudUpload } from '@coreui/icons';
import { IconDirective } from '@coreui/icons-angular';
import { QrCodeService } from '@services/feature-services/qr-code.service';
import { LoadingService } from '@services/helper-services/loading.service';
import { ToastService } from '@services/helper-services/toast.service';
@Component({
  selector: 'app-qr-code',
  imports: [ CardComponent, CardBodyComponent,FormDirective, FormLabelDirective,
     FormSelectDirective,NgIf, NgFor,
      FormControlDirective, ButtonDirective, ReactiveFormsModule],
  templateUrl: './qr-code.component.html',
  styleUrl: './qr-code.component.scss'
})
export class QrCodeComponent {
  color: string = '#ffffff';
  icons: any = { cilCloudUpload };
  demoLogo:string = '';  
  qrCodeImageUrl: string = '';  
  qrCodeTypeList: string[] = ["Numbers","Characters","Characters and Numbers"];
  generateAQrCodeForm: FormGroup = new FormGroup({
    content: new FormControl('https://lulusia.com/', Validators.required),
    size: new FormControl(1,[Validators.min(1), Validators.max(500)]),
    logo: new FormControl(''),
    text: new FormControl(''),
    fontSize: new FormControl(12, [Validators.min(10), Validators.max(100)]),
    textColor: new FormControl('#000000'),
    backgroundColor: new FormControl('#ffffff'),
    fillColor: new FormControl('#000000'),
    fontFamily: new FormControl('arial.ttf'),
    border: new FormControl(0, [Validators.min(0), Validators.max(100)]),
  });
  generateListQRCodeForm: FormGroup = new FormGroup({
    prefix: new FormControl(''),
    quantity: new FormControl(1,[Validators.min(1),Validators.max(10000)]),
    codeLength: new FormControl(6,[Validators.min(1), Validators.max(10)]),
    randomType: new FormControl(0),
  });

  constructor(private qrCodeService: QrCodeService, private toastService: ToastService, private loadingService : LoadingService) { }
  onFileChange(event: any) {
    const file:File = event.target.files[0];
    if (file) {
      //show image preview
      const reader = new FileReader();
      reader.onload = (e: any) => {
          this.demoLogo = `<img src="${e.target.result}" alt="Image Preview"  class="w-50"/>`;
          this.generateAQrCodeForm.patchValue({
            logo: file
          });
        
      };
      reader.readAsDataURL(file);
    }
  }

  onSubmitGenerateQrCode(): void {
    if (this.generateAQrCodeForm.valid) {
      const formData = new FormData();
      if (this.generateAQrCodeForm.value.text) {
        formData.append('text', this.generateAQrCodeForm.value.text);
      }
      if (this.generateAQrCodeForm.value.logo) {
        formData.append('logo', this.generateAQrCodeForm.value.logo);
      }
      formData.append('content', this.generateAQrCodeForm.value.content);
      formData.append('size', this.generateAQrCodeForm.value.size);
      formData.append('textColor', this.generateAQrCodeForm.value.textColor);
      formData.append('backgroundColor', this.generateAQrCodeForm.value.backgroundColor);
      formData.append('fillColor', this.generateAQrCodeForm.value.fillColor);
      formData.append('border', this.generateAQrCodeForm.value.border);
      formData.append('fontFamily', this.generateAQrCodeForm.value.fontFamily);
      formData.append('fontSize', this.generateAQrCodeForm.value.fontSize);
      this.qrCodeService.generateAQRCode(formData).subscribe((res) => {
        //how to display the qr code image
        const blob = new Blob([res], { type: 'image/png' });
        this.qrCodeImageUrl = URL.createObjectURL(blob);
      }, err => {
        this.toastService.showToast(EColors.danger,err.message);
      });
       
    }
  }

  onSubmitGenerateQrCodeList(): void {
    this.loadingService.showLoadingComponent(true);
    const formData = new FormData();
    if (this.generateAQrCodeForm.value.text) {
      formData.append('text', this.generateAQrCodeForm.value.text);
    }
    if (this.generateAQrCodeForm.value.logo) {
      formData.append('logo', this.generateAQrCodeForm.value.logo);
    }
    formData.append('content', this.generateAQrCodeForm.value.content);
    formData.append('size', this.generateAQrCodeForm.value.size);
    formData.append('textColor', this.generateAQrCodeForm.value.textColor);
    formData.append('backgroundColor', this.generateAQrCodeForm.value.backgroundColor);
    formData.append('fillColor', this.generateAQrCodeForm.value.fillColor);
    formData.append('border', this.generateAQrCodeForm.value.border);
    formData.append('fontFamily', this.generateAQrCodeForm.value.fontFamily);
    formData.append('fontSize', this.generateAQrCodeForm.value.fontSize);
    formData.append('prefix', this.generateListQRCodeForm.value.prefix);
    formData.append('quantity', this.generateListQRCodeForm.value.quantity);
    formData.append('codeLength', this.generateListQRCodeForm.value.codeLength);
    formData.append('randomType', this.generateListQRCodeForm.value.randomType);
    this.qrCodeService.generateListQRCode(formData).subscribe((res) => {
    this.loadingService.showLoadingComponent(false);
      const blob = new Blob([res], { type: 'application/zip' });
      const url = URL.createObjectURL(blob);
      const link = document.createElement('a');
      link.href = url;
      link.download = 'QRCode.zip';
      link.click();
    }, err => {
      this.loadingService.showLoadingComponent(false);
      this.toastService.showToast(EColors.danger,err.message);
    });
  }


  get content(){return this.generateAQrCodeForm.get('content');}
  get size(){return this.generateAQrCodeForm.get('size');}
  get border(){return this.generateAQrCodeForm.get('border');}

  get prefix(){return this.generateListQRCodeForm.get('prefix');}
  get quantity(){return this.generateListQRCodeForm.get('quantity');}
  get codeLength(){return this.generateListQRCodeForm.get('codeLength');}
  get randomType(){return this.generateListQRCodeForm.get('randomType');}
}
