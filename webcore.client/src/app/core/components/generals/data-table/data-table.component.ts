import { Component, EventEmitter, Input, Output, computed, signal } from '@angular/core';
import { CardBodyComponent, CardComponent, CardHeaderComponent, TableDirective } from '@coreui/angular';
import { CustomPaginationComponent } from "../custom-pagination/custom-pagination.component";
import { NgFor, NgIf } from '@angular/common';
import { PageInformation, Pagination } from '@models/pagination.model';

@Component({
  selector: 'app-data-table',
  imports: [CardComponent,TableDirective, CardBodyComponent, CardHeaderComponent, CustomPaginationComponent, NgIf, NgFor],
  templateUrl: './data-table.component.html',
  styleUrl: './data-table.component.scss'
})
export class DataTableComponent {
  @Input() data : PageInformation = new PageInformation();
  @Input() striped: boolean = true;
 @Output() changePageIndex: EventEmitter<number> = new EventEmitter<number>();
 @Output() changePageSize: EventEmitter<number> = new EventEmitter<number>();
 paseSizeOptions = [5, 10, 20, 50, 100];
 pageIndexChange(index: any) {
   this.changePageIndex.emit(index);
 }
 pageSizeChange(event: any) {
  this.changePageSize.emit(event.target.value);
  }
}
