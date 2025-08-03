import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ThousandSeparatorDirective } from '@common/directives/thousand-separator.directive';
import { FormControlDirective } from '@coreui/angular';

@Component({
  selector: 'app-input-separator',
  imports: [ThousandSeparatorDirective, CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './input-separator.component.html',
  styleUrl: './input-separator.component.scss'
})
export class InputSeparatorComponent {
  @Input() currentValue: number = 0;
  @Input() allowDecimal: boolean = false;
  @Input() placeholder: string = '';
  @Input() maxDecimals: number = 3;
  myControl = new FormControl<string | null>(null);
  @Output() onChangeValue = new EventEmitter<any>();
  onIntegerNumericChange(value: number | null): void {
    this.onChangeValue.emit(value);
  }
  ngOnChanges() {
    if (this.currentValue) {
      let formattedValue = this.currentValue.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
      this.myControl.setValue(formattedValue);
    } else {
      this.myControl.setValue('');
    }
  }
}
