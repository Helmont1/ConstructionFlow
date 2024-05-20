import { Component } from '@angular/core';
import { LeftNavbarComponent } from '../../_components/left-navbar/left-navbar.component';
import { NgClass } from '@angular/common';
import { TimelineComponent } from '../../_components/timeline/timeline.component';

@Component({
  selector: 'app-flow',
  standalone: true,
  imports: [
    LeftNavbarComponent,
    NgClass,
    TimelineComponent
  ],
  templateUrl: './flow.component.html',
  styleUrl: './flow.component.scss'
})
export class FlowComponent {
  page: string = 'Linha do tempo';

  changePage(page: string) {
    this.page = page;
  }
}
