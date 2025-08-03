import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { NzSelectModule } from 'ng-zorro-antd/select';

function alphabet(): string[] {
  const children: string[] = [];
  for (let i = 10; i < 36; i++) {
    children.push(i.toString(36) + i);
  }
  return children;
}

@Component({
  selector: 'app-multiple-select',
  templateUrl: './multiple-select.component.html',
  styleUrl: './multiple-select.component.scss',
  imports: [FormsModule, NzSelectModule]
})
export class MultipleSelectComponent {
  readonly listOfOption: string[] = alphabet();
  listOfSelectedValue = ['a10', 'c12'];
}