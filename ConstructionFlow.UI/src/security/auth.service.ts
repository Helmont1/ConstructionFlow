import { Injectable } from '@angular/core';
import { UserService } from '../_services/user.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private userService: UserService) {}
  logout(): void {
    localStorage.setItem('isLoggedIn', 'false');
    localStorage.removeItem('user');
  }
  login(): void {
    this.userService.getUser('3b8b20f9-019a-4d9d-3f9e-08dc5365e5bb').subscribe((user) => {
        localStorage.setItem('user', JSON.stringify(user));
        localStorage.setItem('isLoggedIn', 'true');
      });
  }
}
