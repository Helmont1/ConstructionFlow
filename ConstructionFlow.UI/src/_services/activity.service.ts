import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

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

  createActivity(activity: ) {
    return this.http.post(this.url, activity);
  }

}
