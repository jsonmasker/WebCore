import { DatePipe, NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Params } from '@angular/router';
import { AccordionButtonDirective, AccordionComponent, AccordionItemComponent, ButtonCloseDirective, ButtonDirective, CardBodyComponent, CardComponent, CardHeaderComponent, FormControlDirective, FormDirective, FormLabelDirective, ModalBodyComponent, ModalComponent, ModalFooterComponent, ModalHeaderComponent, TableDirective, TemplateIdDirective } from '@coreui/angular';
import { ActionLoggingModel } from '@models/system-management-models/action-logging.model';
import { ActionLoggingService } from '@services/system-services/action-logging.service';
import { PageInformation, Pagination } from '@models/pagination.model';
import { EActions, EController, stringEnumToArray } from '@common/global';
import { DataTableComponent } from '@components/generals/data-table/data-table.component';

@Component({
  selector: 'app-logging',
  imports: [NgFor, DatePipe,
    ButtonCloseDirective, ButtonDirective, ModalComponent, ModalHeaderComponent, ModalBodyComponent,
    ModalFooterComponent, FormControlDirective, FormLabelDirective, FormDirective, ReactiveFormsModule, DataTableComponent,
    AccordionButtonDirective, AccordionComponent, AccordionItemComponent, TemplateIdDirective,],
  templateUrl: './logging.component.html',
  styleUrl: './logging.component.scss'
})
export class LoggingComponent {
  pageInformation: PageInformation = new PageInformation();
  data: Pagination<ActionLoggingModel> = new Pagination<ActionLoggingModel>();
  visibleUpdateModal: boolean = false;
  controllers: any[] = [];
  actions: any[] = [];
  updateForm: FormGroup = new FormGroup({
    id: new FormControl(0),
    userName: new FormControl(''),
    createdDate: new FormControl(''),
    actionName: new FormControl(''),
    controllerName: new FormControl(''),
    details: new FormControl('')
  });
  queryParamForm: FormGroup = new FormGroup({
    action: new FormControl('-1'),
    controller: new FormControl('-1'),
    startDate: new FormControl(''),
    endDate: new FormControl('')
  });

  constructor(private actionLoggingService: ActionLoggingService) { }
  ngOnInit(): void {
    var today = new Date();
    this.controllers = stringEnumToArray(EController);
    this.actions = stringEnumToArray(EActions);
    this.queryParamForm.patchValue({
      startDate: new Date(today.setDate(today.getDate() - 3)).toISOString().split('T')[0],
      endDate: new Date().toISOString().split('T')[0]
    });
    this.getData();
  }

  getData() {
    const query: Params = {
      actionName: this.queryParamForm.value.action,
      controllerName: this.queryParamForm.value.controller,
      startDate: this.queryParamForm.value.startDate,
      endDate: this.queryParamForm.value.endDate,
      pageIndex: this.pageInformation.pageIndex,
      pageSize: this.pageInformation.pageSize
    }

    this.actionLoggingService.getAll(query).subscribe((result) => {
      this.data = result.data;
      this.pageInformation.currentPage = this.data.currentPage;
      this.pageInformation.totalItems = this.data.totalItems;
      this.pageInformation.totalPages = this.data.totalPages;
    });
  }

  onExecuteSubmit() {
    this.getData();
    // if (this.queryParamForm.value.startTime > this.queryParamForm.value.finishTime) {
    //   console.log('InValid');
    // }
    // this.getActionLogs();
  }

  // onTableDataChange(event: any) {
  //   this.pageIndex = event;
  //   this.getActionLogs();
  // }

  updateData(id: string) {
    this.actionLoggingService.getById(id).subscribe((res) => {
      this.updateForm.patchValue(res.data);
      this.updateForm.patchValue({
        createdDate: new Date(res.data.createdDate).toLocaleString()
      })
      this.toggleLiveUpdateModel();
    });
    }

  toggleLiveUpdateModel() {
    this.visibleUpdateModal = !this.visibleUpdateModal;
  }

  handleLiveUpdateModelChange(event: any) {
    this.visibleUpdateModal = event;
  }
  onPageIndexChange(index: any) {
    this.pageInformation.pageIndex = index;
    this.getData();
  }
  onPageSizeChange(size: any) {
    this.pageInformation.pageSize = size;
    this.pageInformation.pageIndex = 1;
    this.getData();
  }
}
