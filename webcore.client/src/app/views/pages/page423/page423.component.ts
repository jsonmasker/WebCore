import {  Component, HostListener, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-page423',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './page423.component.html',
  styleUrl: './page423.component.scss',
  encapsulation: ViewEncapsulation.None
})

export class Page423Component implements OnInit, OnDestroy {

  private snowflakeInterval: any;
  private isTabActive: boolean = true;
  private snowflakes: HTMLElement[] = [];
  private particlesPerThousandPixels = 0.1;
  private fallSpeed = 1.25;
  private maxSnowflakes = 200;
  private pauseWhenNotActive = true;

  ngOnInit(): void {
    this.generateSnowflakes();

    document.addEventListener('visibilitychange', this.handleVisibilityChange.bind(this));
  }

  ngOnDestroy(): void {
    clearInterval(this.snowflakeInterval);
    document.removeEventListener('visibilitychange', this.handleVisibilityChange.bind(this));
  }

  private createSnowflake(): void {
    const snowContainer = document.querySelector('.snow-container') as HTMLElement;
    if (this.snowflakes.length < this.maxSnowflakes) {
      const snowflake = document.createElement('div');
      snowflake.classList.add('snowflake');
      this.snowflakes.push(snowflake);
      snowContainer.appendChild(snowflake);
      this.resetSnowflake(snowflake);
    }
  }

  private resetSnowflake(snowflake: HTMLElement): void {
    const size = Math.random() * 5 + 1;
    const viewportWidth = window.innerWidth - size;
    const viewportHeight = window.innerHeight;

    snowflake.style.width = `${size}px`;
    snowflake.style.height = `${size}px`;
    snowflake.style.left = `${Math.random() * viewportWidth}px`;
    snowflake.style.top = `-${size}px`;

    const animationDuration = (Math.random() * 3 + 2) / this.fallSpeed;
    snowflake.style.animationDuration = `${animationDuration}s`;
    snowflake.style.animationTimingFunction = 'linear';
    snowflake.style.animationName = Math.random() < 0.5 ? 'fall' : 'diagonal-fall';

    setTimeout(() => {
      if (parseInt(snowflake.style.top, 10) < viewportHeight) {
        this.resetSnowflake(snowflake);
      } else {
        snowflake.remove();
      }
    }, animationDuration * 1000);
  }

  private generateSnowflakes(): void {
    const numberOfParticles = Math.ceil((window.innerWidth * window.innerHeight) / 1000) * this.particlesPerThousandPixels;
    const interval = 5000 / numberOfParticles;

    clearInterval(this.snowflakeInterval);
    this.snowflakeInterval = setInterval(() => {
      if (this.isTabActive && this.snowflakes.length < this.maxSnowflakes) {
        requestAnimationFrame(() => this.createSnowflake());
      }
    }, interval);
  }

  private handleVisibilityChange(): void {
    if (!this.pauseWhenNotActive) return;

    this.isTabActive = !document.hidden;
    if (this.isTabActive) {
      this.generateSnowflakes();
    } else {
      clearInterval(this.snowflakeInterval);
    }
  }

  @HostListener('window:resize', ['$event'])
  onResize(): void {
    clearInterval(this.snowflakeInterval);
    setTimeout(() => this.generateSnowflakes(), 1000);
  }
}