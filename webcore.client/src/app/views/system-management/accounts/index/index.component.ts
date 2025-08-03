import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CardBodyComponent, CardComponent, CardHeaderComponent, TableDirective } from '@coreui/angular';
import { AccountService } from '@services/system-services/account.service';
import { AccountModel } from '@models/system-management-models/account.model';
import { PageInformation, Pagination } from '@models/pagination.model';
import { DataTableComponent } from '@components/generals/data-table/data-table.component';

@Component({
  selector: 'app-index',
  standalone: true,
  imports: [NgFor, RouterLink, DataTableComponent],
  templateUrl: './index.component.html',
  styleUrl: './index.component.scss'
})
export class IndexComponent implements OnInit {
  pageInformation: PageInformation = new PageInformation();
  data: Pagination<AccountModel> = new Pagination<AccountModel>();
  constructor(private accountService : AccountService) {}

  ngOnInit() {
    this.getData();
  }
  getData() {
    this.accountService.getAll(this.pageInformation.pageIndex, this.pageInformation.pageSize).subscribe((res) => {
      console.log(res);
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
