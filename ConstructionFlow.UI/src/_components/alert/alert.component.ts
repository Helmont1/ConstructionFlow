import { Component, Input } from '@angular/core';
import { NgbAlert } from '@ng-bootstrap/ng-bootstrap';

interface Alert {
	type: string;
	message: string;
}

@Component({
  selector: 'app-alert',
  standalone: true,
  imports: [
    NgbAlert
  ],
  templateUrl: './alert.component.html',
  styleUrl: './alert.component.scss'
})
export class AlertComponent {
  alerts: Alert[] = [];
  @Input() show(alert: Alert) {
    this.alerts.push(alert);
  }
  
  close(alert: Alert) {
		this.alerts.splice(this.alerts.indexOf(alert), 1);
	}
}
