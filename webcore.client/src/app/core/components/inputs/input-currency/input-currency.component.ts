import { Component, Input, Output, EventEmitter, forwardRef, OnChanges, SimpleChanges } from '@angular/core';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ThousandSeparatorDirective } from '@common/directives/thousand-separator.directive';

@Component({
  selector: 'app-input-currency',
  imports: [ReactiveFormsModule, CommonModule, ThousandSeparatorDirective],
  templateUrl: './input-currency.component.html',
  styleUrl: './input-currency.component.scss',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputCurrencyComponent),
      multi: true
    }
  ]
})
export class InputCurrencyComponent implements ControlValueAccessor, OnChanges {
  @Input() placeholder: string = 'Amount';
  @Input() currency: string = 'VND';
  @Input() currencySymbol: string = 'đ';
  @Input() disabled: boolean = false;
  @Input() min: number = 0;
  @Input() max: number = Number.MAX_SAFE_INTEGER;
  @Input() allowDecimal: boolean = true;
  @Input() maxDecimals: number = 3;
  @Input() initialValue: number = 0;

  @Output() valueChange = new EventEmitter<number>();

  amountCtrl = new FormControl<string | null>(null);
  private numericValue: number = 0;

  private onChange = (value: number) => {};
  private onTouched = () => {};

  constructor() {}

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['initialValue'] && this.initialValue !== undefined) {
      this.numericValue = this.initialValue;
      if (this.initialValue > 0) {
        const formattedValue = this.initialValue.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
        this.amountCtrl.setValue(formattedValue, { emitEvent: false });
      } else {
        this.amountCtrl.setValue('', { emitEvent: false });
      }
    }
  }

  // ControlValueAccessor implementation
  writeValue(value: number): void {
    if (value !== null && value !== undefined) {
      this.numericValue = value;
      if (value > 0) {
        const formattedValue = value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
        this.amountCtrl.setValue(formattedValue, { emitEvent: false });
      } else {
        this.amountCtrl.setValue('', { emitEvent: false });
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
      this.amountCtrl.disable();
    } else {
      this.amountCtrl.enable();
    }
  }

  onNumericValueChange(value: number | null): void {
    const numericValue = value || 0;
    
    // Apply min/max constraints
    const constrainedValue = Math.max(this.min, Math.min(this.max, numericValue));
    
    if (constrainedValue !== numericValue) {
      // If value was constrained, update the display
      const formattedValue = constrainedValue.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
      this.amountCtrl.setValue(formattedValue, { emitEvent: false });
    }
    //console.log('onNumericValueChange', constrainedValue);
    this.numericValue = constrainedValue;
    this.onChange(constrainedValue);
    this.valueChange.emit(constrainedValue);
    
  }

  onInputBlur(): void {
    this.onTouched();
  }

  // Get current numeric value
  get currentValue(): number {
    return this.numericValue;
  }
}
