import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputCurrencyComponent } from './input-currency.component';

describe('InputCurrencyComponent', () => {
  let component: InputCurrencyComponent;
  let fixture: ComponentFixture<InputCurrencyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InputCurrencyComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputCurrencyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
