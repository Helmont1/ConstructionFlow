import { CommonModule, NgClass } from '@angular/common';
import { Component, Input } from '@angular/core';
@Component({
  selector: 'app-carousel',
  standalone: true,
  imports: [NgClass, CommonModule],
  templateUrl: './carousel.component.html',
  styleUrl: './carousel.component.scss',
})
export class CarouselComponent {
  @Input() carouselItems: any = [];
  @Input() indicators: boolean = true;
  @Input() controls: boolean = true;
  @Input() itemsPerSlide: number = 3;
  defaultImage = 'https://static.thenounproject.com/png/4595376-200.png';
  // defaultImage = `data:image/jpeg;base64,/...`;

  format(register: string): string {
    if (!register || register.length !== 14) {
      if (!register || register.length !== 11) {
        return register;
      }
      return `${register.substring(0, 3)}.${register.substring(3, 6)}.${register.substring(
        6,
        9
      )}-${register.substring(9)}`;
    }
    return `${register.substring(0, 2)}.${register.substring(2, 5)}.${register.substring(
      5,
      8
    )}/${register.substring(8, 12)}-${register.substring(12)}`;
  }

  selectedIndex = 0;
  getActiveClass(index: number): string {
    if (
      index >= this.selectedIndex &&
      index < this.selectedIndex + this.itemsPerSlide
    ) {
      return 'item-active';
    }
    return '';
  }

  calculateSliceLength(): number {
    return Math.ceil(this.carouselItems.length / this.itemsPerSlide);
  }

  selectItem(index: number): void {
    this.selectedIndex = index;
  }

  calculateNextIndexForZero(): number {
    let rest = this.carouselItems.length % this.itemsPerSlide;
    if (rest === 0) {
      return this.carouselItems.length - this.itemsPerSlide;
    }
    return this.carouselItems.length - rest;
  }
  onPrevClick(): void {
    this.selectedIndex =
      this.selectedIndex === 0
        ? this.calculateNextIndexForZero()
        : this.selectedIndex - this.itemsPerSlide;
  }

  onNextClick(): void {
    this.selectedIndex =
      this.selectedIndex >= this.carouselItems.length - this.itemsPerSlide
        ? 0
        : this.selectedIndex + this.itemsPerSlide;
  }
}
