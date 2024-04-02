import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Activity } from "../_models/activity.model";

@Injectable(
  { providedIn: 'root' }
)
export class ActivityService {
  url = 'Activity'

  constructor(private http: HttpClient) { }

  getActivities() {
    return this.http.get(this.url);
  }

  getActivity(id: number) {
    return this.http.get(`${this.url}/${id}`);
  }

  createActivity(activity: Activity) {
    return this.http.post(this.url, activity);
  }

}
