import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { OptionModel } from '@models/option.model';
import { NzSelectModule } from 'ng-zorro-antd/select';

@Component({
  selector: 'app-select-search',
  imports: [FormsModule, CommonModule, NzSelectModule],
  templateUrl: './select-search.component.html',
  styleUrl: './select-search.component.scss'
})
export class SelectSearchComponent {
  @Input() placeholder: string = 'Search...';
  @Input() selectedValue: any = null;
  @Input() disabled: boolean = false;
  @Input() options: OptionModel[] = [];
  @Output() onChangeValue = new EventEmitter<any>();

  onChangeInput(event: any) {
      if (event) {
        this.onChangeValue.emit(event);
        //console.log('onChangeInput', event);

      }else{
        this.onChangeValue.emit(-1);
        //console.log('onChangeInput', -1);
      }
  }
}
