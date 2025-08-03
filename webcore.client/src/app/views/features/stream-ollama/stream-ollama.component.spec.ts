import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StreamOllamaComponent } from './stream-ollama.component';

describe('StreamOllamaComponent', () => {
  let component: StreamOllamaComponent;
  let fixture: ComponentFixture<StreamOllamaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StreamOllamaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StreamOllamaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
