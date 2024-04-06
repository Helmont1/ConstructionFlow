import { Injectable } from '@angular/core';
import { UserService } from '../_services/user.service';
import { Router } from '@angular/router';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private userService: UserService) {}
  logout(): void {
    localStorage.setItem('isLoggedIn', 'false');
    localStorage.removeItem('user');
  }

  login() {
    return this.userService.getUser(1).pipe(
      tap((user) => {
        localStorage.setItem('isLoggedIn', 'true');
        localStorage.setItem('user', JSON.stringify(user));
      })
    );
  }
}
