import { ActivityService } from './../../_services/activity.service';
import { Component, Input, OnInit } from '@angular/core';
import { LeftNavbarComponent } from '../../_components/left-navbar/left-navbar.component';
import { NgClass } from '@angular/common';
import { TimelineComponent } from '../../_components/timeline/timeline.component';
import { Activity } from '../../_models/activity.model';
import { Construction } from '../../_models/construction.model';
import { ConstructionService } from '../../_services/construction.service';

@Component({
  selector: 'app-flow',
  standalone: true,
  imports: [LeftNavbarComponent, NgClass, TimelineComponent],
  templateUrl: './flow.component.html',
  styleUrl: './flow.component.scss',
})
export class FlowComponent implements OnInit {
  page: string = 'Linha do tempo';
  @Input('data') data: any;
  atividades: Activity[] = [];

  constructor(
    private activityService: ActivityService,
    private constructionService: ConstructionService
  ) {}

  ngOnInit(): void {
    this.data = JSON.parse(this.data);
    console.log(this.data);
    this.activityService
      .getActivitiesByConstruction(this.data.id)
      .subscribe((data) => {
        this.atividades = data as Activity[];
      });
  }

  changePage(page: string) {
    this.page = page;
  }
}
