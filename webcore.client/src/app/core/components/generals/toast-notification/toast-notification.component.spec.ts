import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToastNotificationComponent } from './toast-notification.component';

describe('ToastNotificationComponent', () => {
  let component: ToastNotificationComponent;
  let fixture: ComponentFixture<ToastNotificationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ToastNotificationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ToastNotificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
