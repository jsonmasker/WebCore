import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GptComponent } from './gpt.component';

describe('GptComponent', () => {
  let component: GptComponent;
  let fixture: ComponentFixture<GptComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GptComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GptComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
