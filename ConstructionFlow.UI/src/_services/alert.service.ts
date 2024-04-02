import { Injectable } from "@angular/core";
import { BehaviorSubject, Subject } from "rxjs";

@Injectable(
  { providedIn: 'root' }
)
export class AlertService {
  subject: Subject<any> = new Subject<any>();
  alert = this.subject.asObservable();

  addAlert(alert:any) {
    this.subject.next(alert);
  }

}
