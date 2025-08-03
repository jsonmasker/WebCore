import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ThousandSeparatorDirective } from '@common/directives/thousand-separator.directive';

@Component({
  selector: 'app-thousand-separator-demo',
  imports: [FormsModule, ThousandSeparatorDirective, CommonModule],
  templateUrl: './thousand-separator-demo.component.html',
  styleUrl: './thousand-separator-demo.component.scss'
})
export class ThousandSeparatorDemoComponent {
// Display values (formatted strings)
  currencyValue: string = '';
  integerValue: string = '';
  customSeparatorValue: string = '';
  
  // Raw numeric values for backend submission
  currencyNumericValue: number | null = null;
  integerNumericValue: number | null = null;
  customSeparatorNumericValue: number | null = null;

  // Handlers for numeric value changes
  onCurrencyNumericChange(value: number | null): void {
    this.currencyNumericValue = value;
  }

  onIntegerNumericChange(value: number | null): void {
    this.integerNumericValue = value;
  }

  onCustomSeparatorNumericChange(value: number | null): void {
    this.customSeparatorNumericValue = value;
  }

  // Simulate form submission
  onSubmit(): void {
    const formData = {
      currency: this.currencyNumericValue,
      integer: this.integerNumericValue,
      customSeparator: this.customSeparatorNumericValue
    };
    
    console.log('Form data to send to backend:', formData);
    alert('Check console for form data that would be sent to backend');
        this.currencyValue = '';
    this.integerValue = '';
    this.customSeparatorValue = '';
    
    // Reset numeric values
    this.currencyNumericValue = null;
    this.integerNumericValue = null;
    this.customSeparatorNumericValue = null;
  }
}
