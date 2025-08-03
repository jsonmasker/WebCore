import { NgFor } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-rating',
  imports: [NgFor],
  templateUrl: './rating.component.html',
  styleUrl: './rating.component.scss'
})
export class RatingComponent {

  @Input() rating: number = 0; // Giá trị rating ban đầu
  @Input() maxStars: number = 5; // Số sao tối đa
  @Input() readOnly: boolean = false; // Cho phép click để đánh giá hoặc không
  @Output() ratingChange = new EventEmitter<number>(); // Sự kiện khi rating thay đổi
  ratingArr: number[] = [];
  ngOnInit() {
    for (let index = 0; index < this.maxStars; index++) {
      this.ratingArr.push(index);
    }
  }

  setRating(star: number) {
    if (!this.readOnly) {
      this.rating = star;
      this.ratingChange.emit(this.rating); // Emit giá trị mới
    }
  }
}
export enum StarRatingColor {
  primary = "primary",
  accent = "accent",
  warn = "warn"
}