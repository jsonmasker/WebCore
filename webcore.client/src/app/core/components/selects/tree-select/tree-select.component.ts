import { Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { OptionModel } from '@models/option.model';
import { NzTreeNodeOptions } from 'ng-zorro-antd/tree';

import { NzTreeSelectModule } from 'ng-zorro-antd/tree-select';

@Component({
  selector: 'app-tree-select',
  templateUrl: './tree-select.component.html',
  styleUrl: './tree-select.component.scss',
  imports: [FormsModule, NzTreeSelectModule]
})
export class TreeSelectComponent {
  @Input() placeholder = 'Please select';
  @Input() expandKeys = [];
  @Input() options: OptionModel[] = [];
  @Input() selectedValue: any = null;
  @Input() isDisabled = false;
  @Output() onChangeValue = new EventEmitter<any>();
  nodes: NzTreeNodeOptions[] = [];


  onChangeInput(event: any) {
      if (event) {
        const myArray = event.split("_");
        if (myArray.length > 1) {
          this.onChangeValue.emit(myArray[1]);
        }
      }else{
        this.onChangeValue.emit(-1);
      }
  }


  ngOnChanges(): void {
   this.nodes = this.handleData(this.options);
  }
  // ngOnInit(): void {
  //   this.nodes = this.handleData(this.options);
  //   // if (this.selectedValue) {
  //   //   this.expandKeys = [String(this.selectedValue)];
  //   // }
  // }

  handleData(options: OptionModel[]): NzTreeNodeOptions[] {
    return options.map(option => ({
      title: option.name,
      key: option.parentId + '_' + option.id,
      isLeaf: !option.children?.length,
      children: option.children ? this.handleData(option.children) : [],
      selectable: !option.children?.length
      //selected: !option.children?.length && option.name == this.selectedValue
    }));
  }

}