import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ThousandSeparatorDemoComponent } from './thousand-separator-demo.component';

describe('ThousandSeparatorDemoComponent', () => {
  let component: ThousandSeparatorDemoComponent;
  let fixture: ComponentFixture<ThousandSeparatorDemoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ThousandSeparatorDemoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ThousandSeparatorDemoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
