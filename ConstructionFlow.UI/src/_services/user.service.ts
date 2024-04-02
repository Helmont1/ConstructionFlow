import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../_models/user.model";

@Injectable(
  { providedIn: 'root' }
)
export class UserService {
  url = 'http://localhost:5213/User'

  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get(this.url);
  }

  getUser(id: string) {
    return this.http.get(`${this.url}/${id}`);
  }

  createUser(user: User) {
    return this.http.post(this.url, user);
  }

  editUser(user: User) {
    return this.http.put(`${this.url}/${user.userId}`, user);
  }

  deleteUser(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }
}
