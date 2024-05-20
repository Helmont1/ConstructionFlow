import { Component } from '@angular/core';
import { Activity } from '../../_models/activity.model';
import { ActivityComponent } from '../activity/activity.component';

@Component({
  selector: 'app-timeline',
  standalone: true,
  imports: [
    ActivityComponent
  ],
  templateUrl: './timeline.component.html',
  styleUrl: './timeline.component.scss'
})
export class TimelineComponent {
  atividades: Activity[] = [];
}
