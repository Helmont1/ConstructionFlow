import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Activity } from '../../_models/activity.model';
import { Status } from '../../_models/status.model';
@Component({
  selector: 'app-activity-modal',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './activity-modal.component.html',
  styleUrl: './activity-modal.component.scss',
})
export class ActivityModalComponent{
  @Input() show: boolean = false;
  @Input() activity: Activity = {} as Activity;
  @Output() saved = new EventEmitter<Activity>();
  @Output() closed = new EventEmitter<void>();
  @Input() showOrderField: boolean = false;
  statuses: Status[] = [
    {id: 1, statusName: 'Não Inciado'},
    {id: 2, statusName: 'Em andamento'},
    {id: 3, statusName: 'Finalizado'},
  ];

  save() {
    this.saved.emit(this.activity);
    this.activity = {} as Activity;
  }

}
