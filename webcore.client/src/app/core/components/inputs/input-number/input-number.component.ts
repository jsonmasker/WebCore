import { Component, Input, Output, EventEmitter, forwardRef, OnChanges, SimpleChanges } from '@angular/core';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ThousandSeparatorDirective } from '@common/directives/thousand-separator.directive';

@Component({
  selector: 'app-input-number',
  imports: [ReactiveFormsModule, CommonModule, ThousandSeparatorDirective],
  templateUrl: './input-number.component.html',
  styleUrl: './input-number.component.scss',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputNumberComponent),
      multi: true
    }
  ]
})
export class InputNumberComponent implements ControlValueAccessor, OnChanges {
  @Input() placeholder: string = 'Enter number';
  @Input() disabled: boolean = false;
  @Input() min: number = 0;
  @Input() max: number = Number.MAX_SAFE_INTEGER;
  @Input() allowDecimal: boolean = true;
  @Input() maxDecimals: number = 3;
  @Input() currentValue: number = 0;

  @Output() valueChange = new EventEmitter<number>();

  numberCtrl = new FormControl<string | null>(null);
  private numericValue: number = 0;

  private onChange = (value: number) => {};
  private onTouched = () => {};

  constructor() {}

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['currentValue'] && this.currentValue !== undefined) {
      this.numericValue = this.currentValue;
      if (this.currentValue > 0) {
        const formattedValue = this.currentValue.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
        this.numberCtrl.setValue(formattedValue, { emitEvent: false });
      } else {
        this.numberCtrl.setValue('', { emitEvent: false });
      }
    }
  }

  // ControlValueAccessor implementation
  writeValue(value: number): void {
    if (value !== null && value !== undefined) {
      this.numericValue = value;
      if (value > 0) {
        const formattedValue = value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
        this.numberCtrl.setValue(formattedValue, { emitEvent: false });
      } else {
        this.numberCtrl.setValue('', { emitEvent: false });
      }
    }
  }

  registerOnChange(fn: (value: number) => void): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: () => void): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this.disabled = isDisabled;
    if (isDisabled) {
      this.numberCtrl.disable();
    } else {
      this.numberCtrl.enable();
    }
  }

  onNumericValueChange(value: number | null): void {
    const numericValue = value || 0;
    
    // Apply min/max constraints
    const constrainedValue = Math.max(this.min, Math.min(this.max, numericValue));
    
    if (constrainedValue !== numericValue) {
      // If value was constrained, update the display
      const formattedValue = constrainedValue.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
      this.numberCtrl.setValue(formattedValue, { emitEvent: false });
    }
    
    this.numericValue = constrainedValue;
    this.onChange(constrainedValue);
    this.valueChange.emit(constrainedValue);
  }

  onInputBlur(): void {
    this.onTouched();
  }

  // Get current numeric value
  get value(): number {
    return this.numericValue;
  }
}
