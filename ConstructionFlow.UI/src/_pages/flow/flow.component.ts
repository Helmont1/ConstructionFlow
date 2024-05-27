import { ActivityService } from './../../_services/activity.service';
import { Component, Input, OnInit } from '@angular/core';
import { LeftNavbarComponent } from '../../_components/left-navbar/left-navbar.component';
import { NgClass } from '@angular/common';
import { TimelineComponent } from '../../_components/timeline/timeline.component';
import { Activity } from '../../_models/activity.model';
import { Construction } from '../../_models/construction.model';
import { ConstructionService } from '../../_services/construction.service';
import { catchError } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-flow',
  standalone: true,
  imports: [LeftNavbarComponent, NgClass, TimelineComponent],
  templateUrl: './flow.component.html',
  styleUrl: './flow.component.scss',
})
export class FlowComponent implements OnInit {
  page: string = 'Linha do tempo';
  @Input('data') data!: number;
  atividades: Activity[] = [];
  construction!: Construction;

  constructor(
    private activityService: ActivityService,
    private constructionService: ConstructionService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.constructionService
      .getConstructionById(this.data)
      .pipe(
        catchError((error) => {
          alert('Erro ao encontrar a obra');
          this.router.navigate(['/home']);
          return error;
        })
      )
      .subscribe((data) => {
        this.construction = data as Construction;
      });
    this.activityService
      .getActivitiesByConstruction(this.data)
      .subscribe((data) => {
        this.atividades = data as Activity[];
      });
  }

  changePage(page: string) {
    this.page = page;
  }
}
