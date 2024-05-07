import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../_models/user.model";

@Injectable(
  { providedIn: 'root' }
)
export class UserService {
  url = 'User'

  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get(this.url);
  }

  getUser(id: number) {
    return this.http.get<User>(`${this.url}/${id}`);
  }

  createUser(user: User) {
    return this.http.post(this.url, user);
  }

  editUser(user: User) {
    return this.http.put(`${this.url}/${user.id}`, user);
  }

  deleteUser(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }

  login(userEmail: string, userPassword: string) {
    return this.http.post<string>(`${this.url}/login`, { userEmail, userPassword }, { responseType: 'text' as 'json' });
  }
}
