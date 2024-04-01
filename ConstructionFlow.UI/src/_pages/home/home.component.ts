import { NgStyle } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    NgStyle
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  findById: boolean = true;
  hActivedButton: string = '#5C97CF';
  hDeactivatedButton: string = '#2B3D49';

  setFindById( findById: boolean ) {
    this.findById = findById;
  }
}
