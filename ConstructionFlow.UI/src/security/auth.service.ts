import { Injectable } from '@angular/core';
import { UserService } from '../_services/user.service';
import { Router } from '@angular/router';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private userService: UserService, private routerService: Router) { }
  logout(): void {
    localStorage.setItem('isLoggedIn', 'false');
    localStorage.removeItem('user');
  }

  login(userEmail: string, userPassword: string) {
    return this.userService.login(userEmail, userPassword).subscribe({
      next: (response) => {
        localStorage.setItem('isLoggedIn', 'true');
        localStorage.setItem('token', response);
        this.routerService.navigate(['/home']);
      },
      error: (error) => {
        console.error(error);
        alert('Usuário ou senha inválidos');
      }
    });
  }

  isLoggedIn(): boolean {
    return localStorage.getItem('isLoggedIn') === 'true';
  }

  getToken(): string {
    return localStorage.getItem('token') || '';
  }
}
