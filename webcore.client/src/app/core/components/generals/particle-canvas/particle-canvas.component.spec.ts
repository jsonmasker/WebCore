import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParticleCanvasComponent } from './particle-canvas.component';

describe('ParticleCanvasComponent', () => {
  let component: ParticleCanvasComponent;
  let fixture: ComponentFixture<ParticleCanvasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ParticleCanvasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParticleCanvasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
