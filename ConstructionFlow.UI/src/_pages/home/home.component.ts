import { NgStyle } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../security/auth.service';
import { CustomerService } from '../../_services/customer.service';

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
  searchText: string = "Digite o ID da obra"

  constructor(private authService: AuthService, private router: Router) {
  }

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
    this.searchText = findById ? "Digite o id da obra" : "Digite o CPF/CNPJ"
  }

}
