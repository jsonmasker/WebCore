import { CommonModule, NgFor } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { DataTableComponent } from '@components/generals/data-table/data-table.component';
import { PageInformation, Pagination } from '@models/pagination.model';
import { RoleModel } from '@models/system-management-models/role.model';
import { RoleService } from '@services/system-services/role.service';

@Component({
  selector: 'app-index',
  standalone: true,
  imports: [DataTableComponent, CommonModule, RouterLink],
  templateUrl: './index.component.html',
  styleUrl: './index.component.scss'
})
export class IndexComponent implements OnInit {
  pageInformation: PageInformation = new PageInformation();
  data: Pagination<RoleModel> = new Pagination<RoleModel>();
  constructor(private roleService : RoleService) {}
  ngOnInit() {
    this.getData();
  }
  getData() {
    this.roleService.getAll(this.pageInformation.pageIndex, this.pageInformation.pageSize).subscribe((res) => {
      this.data = res.data;
      this.pageInformation.currentPage = this.data.currentPage;
      this.pageInformation.totalItems = this.data.totalItems;
      this.pageInformation.totalPages = this.data.totalPages;
    });
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
