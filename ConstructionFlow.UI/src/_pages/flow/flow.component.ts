import { Component } from '@angular/core';
import { LeftNavbarComponent } from '../../_components/left-navbar/left-navbar.component';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-flow',
  standalone: true,
  imports: [
    LeftNavbarComponent,
    NgClass
  ],
  templateUrl: './flow.component.html',
  styleUrl: './flow.component.scss'
})
export class FlowComponent {
  page: string = 'timeline';

  changePage(page: string) {
    this.page = page;
  }
}
