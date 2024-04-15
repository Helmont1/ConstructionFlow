import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import {
  CarouselComponent
} from '../../_components/carousel/carousel.component';
import { Router, RouterLink } from '@angular/router';
import { User } from '../../_models/user.model';
import { LeftNavbarComponent } from '../../_components/left-navbar/left-navbar.component';
import { AlertComponent } from '../../_components/alert/alert.component';
import { ConstructionService } from '../../_services/construction.service';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CarouselComponent, RouterLink, LeftNavbarComponent, AlertComponent],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss',
})
export class ProfileComponent implements OnInit, AfterViewInit {
  showPending: boolean = true;
  user: User = {} as User;
  constructions: any;
  @ViewChild(AlertComponent) alertComponent!: AlertComponent;
  @Input('data') alerts: any;

  constructor(private router: Router, private constructionService: ConstructionService) {
  }
  
  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('user') ?? '{}');
    this.constructionService.getConstructionsByUser(this.user).subscribe((data) => {
      this.constructions = data;
    });
  }
  
  ngAfterViewInit(): void {
    if (this.alerts)
    setTimeout(() => {
    console.log(this.alertComponent);
    console.log(this.alerts);
    this.alertComponent.show(JSON.parse(this.alerts));
    });
  }

  createConstruction() {
    this.router.navigate(['construction']);
  }

  setShowPending(showPending: boolean) {
    this.showPending = showPending;
  }

  formatCnpj(cnpj: string): string {
    if (!cnpj || cnpj.length !== 14) {
      return cnpj;
    }
    return `${cnpj.substring(0, 2)}.${cnpj.substring(2, 5)}.${cnpj.substring(
      5,
      8
    )}/${cnpj.substring(8, 12)}-${cnpj.substring(12)}`;
  }
}
