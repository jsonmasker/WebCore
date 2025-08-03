import { Component, AfterViewInit, HostListener, ViewEncapsulation, input, Input } from '@angular/core';

@Component({
  selector: 'app-particle-canvas',
  templateUrl: './particle-canvas.component.html',
  styleUrls: ['./particle-canvas.component.scss'],
  standalone: true,
  //encapsulation: ViewEncapsulation.None
})
export class ParticleCanvasComponent implements AfterViewInit {
  @Input() id: string = 'canvas';
  private canvas!: HTMLCanvasElement;
  private ctx!: CanvasRenderingContext2D;
  private particles: Particle[] = [];

  @HostListener('window:resize', ['$event'])
  onResize(event: Event) {
    this.canvas.width = window.innerWidth;
    this.canvas.height = window.innerHeight;
  }
  

  ngAfterViewInit() {
    this.canvas = document.getElementById(this.id) as HTMLCanvasElement;
    this.ctx = this.canvas.getContext('2d')!;
    this.initializeParticles();
    this.update();
  }

  initializeParticles() {
    //random particles from 40 to 60
    const randomParticles = Math.floor(Math.random() * 20) + 40;
    for (let i = 0; i < randomParticles; i++) {
      this.particles.push(new Particle());
    }
  }

  update = () => {
    this.canvas.width = window.innerWidth;
    this.canvas.height = window.innerHeight;
    const MAX_DISTANCE = (window.innerWidth + window.innerHeight) / 20;

    for (let i = 0; i < this.particles.length; i++) {
      this.particles[i].update();

      for (let j = i; j < this.particles.length; j++) {
        const distance = this.particles[i].position.distance(this.particles[j].position);
        if (distance < MAX_DISTANCE) {
          this.ctx.strokeStyle = `rgba(255, 255, 255, ${1 - distance / MAX_DISTANCE})`;
          this.ctx.beginPath();
          this.ctx.moveTo(this.particles[i].position.x, this.particles[i].position.y);
          this.ctx.lineTo(this.particles[j].position.x, this.particles[j].position.y);
          this.ctx.stroke();
        }
      }

      this.ctx.fillStyle = 'rgba(255, 255, 255, 0.5)';
      this.ctx.beginPath();
      this.ctx.arc(
        this.particles[i].position.x,
        this.particles[i].position.y,
        this.particles[i].radius,
        0, 2 * Math.PI
      );
      this.ctx.fill();
    }

    requestAnimationFrame(this.update);
  }
}

class Vec2 extends Array<number> {
  constructor(...values: number[]) {
    switch (values.length) {
      case 2:
        super(values[0], values[1]);
        break;
      case 1:
        super(values[0], values[0]);
        break;
      default:
        super(2);
    }
  }

  get x() { return this[0]; }
  set x(value: number) { this[0] = value; }

  get y() { return this[1]; }
  set y(value: number) { this[1] = value; }

  add(b: Vec2) {
    this[0] += b[0];
    this[1] += b[1];
  }

  distance(b: Vec2) {
    return Math.hypot(b[0] - this[0], b[1] - this[1]);
  }
}

class Particle {
  position: Vec2;
  speed: Vec2;
  radius: number;

  constructor() {
    this.speed = new Vec2(Math.random(), Math.random());
    this.position = new Vec2(Math.random() * window.innerWidth, Math.random() * window.innerHeight);
    this.radius = Math.random() * 4 + 1;
  }

  update() {
    if (this.position.x > window.innerWidth || this.position.x < 0) {
      this.speed.x *= -1;
    }
    if (this.position.y > window.innerHeight || this.position.y < 0) {
      this.speed.y *= -1;
    }
    this.position.add(this.speed);
  }
}
