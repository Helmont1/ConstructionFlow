import { Component } from '@angular/core';
import { AuthService } from '../../security/auth.service';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-left-navbar',
  standalone: true,
  imports: [
    RouterLink
  ],
  templateUrl: './left-navbar.component.html',
  styleUrl: './left-navbar.component.scss'
})
export class LeftNavbarComponent {

  constructor(private authService: AuthService, private route: Router){}

  logout() {
    this.authService.logout();
    this.route.navigate(['/home']);
  }
}
