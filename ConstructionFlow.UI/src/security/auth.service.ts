import { Injectable } from '@angular/core';
import { UserService } from '../_services/user.service';
import { Router } from '@angular/router';
import { firstValueFrom, tap } from 'rxjs';
import { User } from '../_models/user.model';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private userService: UserService, private routerService: Router) { }
  logout(): void {
    localStorage.setItem('isLoggedIn', 'false');
    localStorage.removeItem('token');
  }

  login(userEmail: string, userPassword: string) {
    return this.userService.login(userEmail, userPassword).subscribe({
      next: (response) => {
        localStorage.setItem('isLoggedIn', 'true');
        localStorage.setItem('token', response);
        this.routerService.navigate(['/home']);
      },
      error: (error) => {
        if (error.status === 400) alert('Usuário ou senha inválidos');
      }
    });
  }

  isLoggedIn(): boolean {
    return localStorage.getItem('isLoggedIn') === 'true';
  }

  getToken(): string {
    return localStorage.getItem('token') || '';
  }

  async getUser(): Promise<User>{
    const userId = jwtDecode(localStorage.getItem('token') ?? '').sub;
    return await firstValueFrom(this.userService.getUser(Number(userId)))
  }
}
