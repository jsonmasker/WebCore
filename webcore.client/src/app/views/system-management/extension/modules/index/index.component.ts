import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TableDirective, CardComponent, CardBodyComponent, CardHeaderComponent } from '@coreui/angular';
import {ModuleModel} from '@models/system-management-models/module.model';
import {ModuleService} from '@services/system-services/module.service';
@Component({
  selector: 'app-index',
  imports: [TableDirective, CardComponent, CardBodyComponent, CardHeaderComponent, RouterLink, NgFor],
  templateUrl: './index.component.html',
  styleUrl: './index.component.scss'
})
export class IndexComponent implements OnInit {
  public data: ModuleModel[] = [];
  constructor(private moduleService : ModuleService ) { }
  ngOnInit(): void {
    //this.getData();
  }
  getData() {
    this.moduleService.getModules().subscribe((res: ModuleModel[]) => {
      this.data = res;
    }, (error) => {
      console.log(error);
    }
  );
  }
}
