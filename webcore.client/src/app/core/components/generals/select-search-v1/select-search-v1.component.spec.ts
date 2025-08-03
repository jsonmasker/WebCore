import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectSearchV1Component } from './select-search-v1.component';

describe('SelectSearchV1Component', () => {
  let component: SelectSearchV1Component;
  let fixture: ComponentFixture<SelectSearchV1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SelectSearchV1Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SelectSearchV1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
