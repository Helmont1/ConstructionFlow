import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Status } from "../_models/status.model";

@Injectable(
  { providedIn: 'root' }
)
export class StatusService {
  url = 'Status'
  constructor(private http: HttpClient) {}

  getStatuses() {
    return this.http.get<Status>(this.url);
  }

  getStatus(name: string) {
    return this.http.get<Status>(`${this.url}/${name}`);
  }
}