import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OllamaComponent } from './ollama.component';

describe('OllamaComponent', () => {
  let component: OllamaComponent;
  let fixture: ComponentFixture<OllamaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OllamaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OllamaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
