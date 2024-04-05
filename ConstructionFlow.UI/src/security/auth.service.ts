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
    this.userService.getUser(1).subscribe((user) => {
      localStorage.setItem('user', JSON.stringify(user));
      localStorage.setItem('isLoggedIn', 'true');
    });
  }
}
