import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CkeditorComponent } from './ckeditor.component';

describe('CkeditorComponent', () => {
  let component: CkeditorComponent;
  let fixture: ComponentFixture<CkeditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CkeditorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CkeditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
