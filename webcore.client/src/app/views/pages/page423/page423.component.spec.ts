import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Page423Component } from './page423.component';

describe('Page403Component', () => {
  let component: Page423Component;
  let fixture: ComponentFixture<Page423Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Page423Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Page423Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
