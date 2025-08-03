// import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnChanges, SimpleChanges, Output, ViewEncapsulation } from '@angular/core';
// import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
// // import { provideNativeDateAdapter } from '@angular/material/core';
// // import { MatDatepickerModule } from '@angular/material/datepicker';
// // import { MatFormFieldModule } from '@angular/material/form-field';
// import { DatePipe } from '@angular/common';

// @Component({
//   selector: 'app-date-range-picker',
//   standalone: true,
//   templateUrl: './date-range-picker.component.html',
//   styleUrls: ['./date-range-picker.component.scss'],
//   providers: [
//     //provideNativeDateAdapter(),
//     DatePipe
//   ],
//   imports: [
//     //MatFormFieldModule, MatDatepickerModule,
//      FormsModule, ReactiveFormsModule],
//   changeDetection: ChangeDetectionStrategy.OnPush,
//   encapsulation: ViewEncapsulation.None,
// })
// export class DateRangePickerComponent implements OnChanges {

//   @Input() startTimeInput: Date | null = null;
//   @Input() endTimeInput: Date | null = null;
//   @Input() required: boolean = true;
//   @Output() startTimeOutput = new EventEmitter<string | null>();
//   @Output() endTimeOutput = new EventEmitter<string | null>();

//   range = new FormGroup({
//     start: new FormControl<Date | null>(null, this.required ? Validators.required : null),
//     end: new FormControl<Date | null>(null, this.required ? Validators.required : null),
//   });

//   constructor(private datePipe: DatePipe) {
//     this.range.get('start')?.valueChanges.subscribe((value) => {
//       const formattedValue = value ? this.datePipe.transform(value, 'MM/dd/yyyy') : null;
//       this.startTimeOutput.emit(formattedValue);
//     });

//     this.range.get('end')?.valueChanges.subscribe((value) => {
//       const formattedValue = value ? this.datePipe.transform(value, 'MM/dd/yyyy') : null;
//       this.endTimeOutput.emit(formattedValue);
//     });
//   }

//   ngOnChanges(changes: SimpleChanges): void {
//     if (changes['startTimeInput'] && changes['startTimeInput'].currentValue !== undefined) {
//       this.range.get('start')?.setValue(this.startTimeInput);
//     }
//     if (changes['endTimeInput'] && changes['endTimeInput'].currentValue !== undefined) {
//       this.range.get('end')?.setValue(this.endTimeInput);
//     }
//     if(changes['required'] && changes['required'].currentValue !== undefined) {
//       if(changes['required'].currentValue === false) {
//         this.range.get('start')?.clearValidators();
//         this.range.get('end')?.clearValidators();
//       } else {
//         this.range.get('start')?.setValidators([Validators.required]);
//         this.range.get('end')?.setValidators([Validators.required]);
//       }
//     }
//   }
// }
