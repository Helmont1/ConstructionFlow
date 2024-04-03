import { CommonModule, NgClass } from '@angular/common';
import { Component, Input } from '@angular/core';

export interface carouselItem {
  constructionId: string,
  status: {
    statusName: string,
    statusId?: string
  }
  endDate: Date,
  startDate: Date,
  customer: {
    customerId?: string,
    name: string, //-----------
    cpf?: string,
    cnpj?: string
  },
  title: string, //-------------
  image: string,
}

@Component({
  selector: 'app-carousel',
  standalone: true,
  imports: [
    NgClass,
    CommonModule
  ],
  templateUrl: './carousel.component.html',
  styleUrl: './carousel.component.scss'
})
export class CarouselComponent{

  @Input() carouselItems: carouselItem[] = [];
  @Input() indicators: boolean = true;
  @Input() controls: boolean = true;
  @Input() itemsPerSlide: number = 3;
  
  selectedIndex = 0;
  getActiveClass(index: number): string {
    if (index >= this.selectedIndex && index < this.selectedIndex + this.itemsPerSlide) {
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
    this.selectedIndex = this.selectedIndex === 0 ? this.calculateNextIndexForZero() : this.selectedIndex - this.itemsPerSlide;
  }

  onNextClick(): void {
    this.selectedIndex = this.selectedIndex >= this.carouselItems.length - this.itemsPerSlide ? 0 : this.selectedIndex + this.itemsPerSlide;
  }
}
