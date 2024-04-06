import { Component } from '@angular/core';
import { NgbAlert } from '@ng-bootstrap/ng-bootstrap';

export interface Alert {
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
  
  show(alerts: Alert[]) {
    this.alerts = alerts;
  }
  
  close(alert: Alert) {
		this.alerts.splice(this.alerts.indexOf(alert), 1);
	}
}
