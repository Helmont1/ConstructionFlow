import { NgClass } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-activity',
  standalone: true,
  imports: [
    NgClass
  ],
  templateUrl: './activity.component.html',
  styleUrl: './activity.component.scss'
})
export class ActivityComponent{
  @Input() stage: string = 'not started';
  @Input() hasTimeLine: boolean = false;
  @Input() hasBar: boolean = true;
  @Input() data: Data = {
    name: 'Default',
    date: 'Jan 01'
  };
}

interface Data {
  name: string;
  year?: number;
  date: string;
}
