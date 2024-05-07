import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { DefaultActivity } from "../_models/default-activity.model";

@Injectable(
  { providedIn: 'root' }
)

export class DefaultActivityService {
  url = 'DefaultActivity'
  constructor(private http: HttpClient) {}

  getDefaultActivities() {
    return this.http.get<DefaultActivity[]>(this.url);
  }
}
