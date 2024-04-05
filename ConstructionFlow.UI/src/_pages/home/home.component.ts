import { NgStyle } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../security/auth.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    NgStyle,
    RouterLink
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit{
  findById: boolean = true;
  hActivedButton: string = '#5C97CF';
  hDeactivatedButton: string = '#2B3D49';
  isLogged: boolean = false;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.isLogged = localStorage.getItem('isLoggedIn') == 'true';
  }

  logout():void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  goTo(route: string): void {
    this.router.navigate([route]);
  }

  setFindById( findById: boolean ) {
    this.findById = findById;
  }
}
