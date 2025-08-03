import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputSeparatorComponent } from './input-separator.component';

describe('InputSeparatorComponent', () => {
  let component: InputSeparatorComponent;
  let fixture: ComponentFixture<InputSeparatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InputSeparatorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputSeparatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
