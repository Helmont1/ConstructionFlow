import {
  AfterViewInit,
  Component,
  Input,
  OnInit,
  ViewChild,
} from '@angular/core';
import { CarouselComponent } from '../../_components/carousel/carousel.component';
import { Router, RouterLink } from '@angular/router';
import { User } from '../../_models/user.model';
import { LeftNavbarComponent } from '../../_components/left-navbar/left-navbar.component';
import { AlertComponent } from '../../_components/alert/alert.component';
import { ConstructionService } from '../../_services/construction.service';
import { AuthService } from '../../security/auth.service';
import { StarRatingComponent } from '../../_components/star-rating/star-rating.component';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [
    CarouselComponent,
    RouterLink,
    LeftNavbarComponent,
    AlertComponent,
    StarRatingComponent
  ],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss',
})
export class ProfileComponent implements OnInit, AfterViewInit {
  showPending: boolean = true;
  user: User = {} as User;
  constructions: any[] = [];
  finishedConstructions: any[] = [];
  @ViewChild(AlertComponent) alertComponent!: AlertComponent;
  @Input('data') alerts: any;
  defaultImage = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTBg9zkf0PWdFupdiDjLIkF1rWzE_oC76dNaQ&s';
  greenScore: number = 6.9;

  constructor(
    private router: Router,
    private constructionService: ConstructionService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.authService.getUser().then((user) => {
      this.user = user;
      this.constructionService
        .getConstructionsByUser(this.user)
        .subscribe((data) => {
          let dataArray = data as Array<any>;
          let { finishedConstructions, pendingConstructions } =
            dataArray.reduce(
              (acc, item) => {
                if (item.status.id === 3) {
                  acc.finishedConstructions.push(item);
                } else {
                  acc.pendingConstructions.push(item);
                }
                return acc;
              },
              { finishedConstructions: [], pendingConstructions: [] }
            );
          this.constructions = pendingConstructions;
          this.finishedConstructions = finishedConstructions;
        });
    });
  }

  ngAfterViewInit(): void {
    if (this.alerts)
      setTimeout(() => {
        this.alertComponent.show(JSON.parse(this.alerts));
      });
  }

  getRating(){
    return Math.round(this.greenScore * 10)/20;
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
