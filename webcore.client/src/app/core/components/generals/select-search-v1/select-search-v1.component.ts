// import { Component, EventEmitter, Input, Output } from '@angular/core';
// import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
// // import { MatAutocompleteModule } from '@angular/material/autocomplete';
// // import { MatInputModule } from '@angular/material/input';
// // import { MatFormFieldModule } from '@angular/material/form-field';
// import { FormControlDirective } from '@coreui/angular';
// import { OptionModel } from '@models/option.model';

// @Component({
//   selector: 'app-select-search-v1',
//   templateUrl: './select-search-v1.component.html',
//   styleUrl: './select-search-v1.component.scss',
//   imports: [
//     FormsModule,
//     // MatFormFieldModule,
//     // MatInputModule,
//     // MatAutocompleteModule,
//     ReactiveFormsModule,
//    // FormControlDirective
//   ]
// })
// export class SelectSearchV1Component {
//   @Input() placeholder: string = 'Typing...';
//   @Input() selectedValue: any = null;
//   @Input() disabled: boolean = false;
//   @Input() options: OptionModel[] = [];
//   @Output() onChangeValue = new EventEmitter<any>();
//   // Form control for the autocomplete input
//   myControl = new FormControl<string | OptionModel>('');
//   filteredOptions: OptionModel[] = [];
//   /**
//    * Initialize the component and set up filtered options for the autocomplete.
//    */
//   // ngOnInit() {
//   //   this.filteredOptions = this.options.slice();
//   // }
//   /**
//    * Handle changes to the input properties and update the filtered options and selected value.
//    */
//   ngOnChanges() {
//     if (this.options && this.options.length > 0) {
//       this.filteredOptions = this.options.slice();
//     }
//     if (this.selectedValue) {
//       console.log('Selected Value:', this.selectedValue);
//       const selectedOption = this.options.find(o => o.id === this.selectedValue);
//       if (selectedOption) {
//         this.myControl.setValue(selectedOption);
//       } else {
//         this.myControl.setValue('');
//       }
//     } 
//   }
//   //when myControl value changes, update the selectedValue
//   onChangeInput(event: any) {
//     const value = event.target.value;
//       if (!value) {
//         this.onChangeValue.emit(-1);
//       }
//   }
  
//   /**
//    * Display function for showing the selected province name in the input.
//    * @param data The province object
//    * @returns The province name or an empty string
//    */
//   displayFn(data: OptionModel): string {
//     return data && data.name ? data.name : '';
//   }

//   /**
//    * Handler for when an option is selected from the autocomplete.
//    */
//   onOptionSelected(event: any) {
//     this.onChangeValue.emit(event.option.value.id);
//   }

//   filter(event: any): void {
//     const filterValue = event.target.value.toLowerCase();
//     this.filteredOptions = this.options.filter(o => o.name.toLowerCase().includes(filterValue));
//   }

// }
