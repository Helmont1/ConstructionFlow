import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DefaultActivityService } from '../../_services/default-activity.service';
@Component({
  selector: 'app-activity-modal',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './activity-modal.component.html',
  styleUrl: './activity-modal.component.scss'
})
export class ActivityModalComponent {
  @Input() show: boolean = false;
  activityName: string = '';
  iconClasses: string = '';
  @Output() saved = new EventEmitter<void>();

  constructor(
    private defaultActivityService: DefaultActivityService
  ){}

  save() {
    if (!this.activityName || !this.iconClasses) {
      alert('Preencha todos os campos para continuar');
      return;
    }
    this.defaultActivityService.createDefaultActivity({
      defaultActivityName: this.activityName,
      icon: this.iconClasses
    }).subscribe(() => {
      this.show = false;
      this.saved.emit();
    });
  }
}
