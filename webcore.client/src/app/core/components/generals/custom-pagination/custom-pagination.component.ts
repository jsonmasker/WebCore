import { NgFor, NgIf } from '@angular/common';
import { Component, EventEmitter, Input, Output, computed, signal } from '@angular/core';

@Component({
  selector: 'app-custom-pagination',
  templateUrl: './custom-pagination.component.html',
  styleUrl: './custom-pagination.component.scss',
  imports: [NgFor, NgIf]
})
export class CustomPaginationComponent {
  @Input() totalPages = 0;
  @Output() pageChanged = new EventEmitter<number>();
  pages: (number | string)[] = [];
  currentPage = signal(1);

  ngOnChanges() {
    if(this.totalPages > 1) 
      this.computed();
  }

  computed() {
    this.pages = [];
    const total = this.totalPages;
    const current = this.currentPage();
    if (total <= 1) {
      this.pages = [];
      return;
    }
    if (total <= 7) {
      this.pages = Array.from({ length: total }, (_, i) => i + 1);
      return;
    }

    this.pages.push(1);
    if (current > 4) this.pages.push('...');

    const start = Math.max(2, current - 2);
    const end = Math.min(total - 1, current + 2);

    for (let i = start; i <= end; i++) {
      this.pages.push(i);
    }

    if (current < total - 3) this.pages.push('...');
    this.pages.push(total);
  }

  selectPage(page: number | string) {
    if (typeof page === 'number') {
      this.currentPage.set(page);
      this.pageChanged.emit(page);
      this.computed();
    }
  }

  previousPage() {
    if (this.currentPage() > 1) {
      this.selectPage(this.currentPage() - 1);
    }
  }

  nextPage() {
    if (this.currentPage() < this.totalPages) {
      this.selectPage(this.currentPage() + 1);
    }
  }
}
