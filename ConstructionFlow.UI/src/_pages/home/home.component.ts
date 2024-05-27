import { NgStyle } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../security/auth.service';
import { FormsModule } from '@angular/forms';
import { ConstructionService } from '../../_services/construction.service';
import { AlertModalComponent } from '../../_components/alert-modal/alert-modal.component';
import { catchError } from 'rxjs';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    NgStyle,
    RouterLink,
    FormsModule,
    AlertModalComponent
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
  constructionId: string = '';
  showAlert: boolean = false;

  constructor(
    private authService: AuthService,
    private router: Router,
    private constructionService: ConstructionService
  ) {
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

  findConstruction(){
    this.constructionService.getConstructionById(Number(this.constructionId))
    .pipe(
      catchError((error) => {
        this.showAlert = true;
        return error;
      })
    )
    .subscribe(
      (data) => {
        this.router.navigate(['/flow'], {
          queryParams: { data: this.constructionId },
        });
      }
    );
  }

}
