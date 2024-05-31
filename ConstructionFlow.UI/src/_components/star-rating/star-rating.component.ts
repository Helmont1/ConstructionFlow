import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-star-rating',
  standalone: true,
  imports: [],
  templateUrl: './star-rating.component.html',
  styleUrl: './star-rating.component.scss'
})
export class StarRatingComponent {
  @Input() rating: number=5;
  @Input() size: number=5;

  get stars() {
    console.log(this.rating)
    return Array(Math.floor(this.size)).fill(0);
  }
}
