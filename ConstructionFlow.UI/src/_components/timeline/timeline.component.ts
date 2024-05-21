import { Component, Input, OnInit } from '@angular/core';
import { Activity } from '../../_models/activity.model';
import { ActivityComponent } from '../activity/activity.component';

@Component({
  selector: 'app-timeline',
  standalone: true,
  imports: [ActivityComponent],
  templateUrl: './timeline.component.html',
  styleUrl: './timeline.component.scss',
})
export class TimelineComponent {
  @Input() atividades: Activity[] = [];

  // ngOnInit(): void {
  //   this.atividades = [
  //     {
  //       id: 1,
  //       startDate: new Date(2024, 0, 1),
  //       endDate: new Date(2024, 0, 5),
  //       status: {
  //         id: 2,
  //         statusName: 'Em Andamento',
  //       },
  //     },
  //     {
  //       id: 2,
  //       startDate: new Date(2024, 0, 6),
  //       endDate: new Date(2024, 0, 10),
  //       status: {
  //         id: 1,
  //         statusName: 'Concluído',
  //       },
  //     },
  //     {
  //       id: 3,
  //       startDate: new Date(2024, 0, 11),
  //       endDate: new Date(2024, 0, 15),
  //       status: {
  //         id: 3,
  //         statusName: 'Atrasado',
  //       },
  //     },
  //   ];
  // }

  hasTimeLine(atividade: Activity, atividadeNext: Activity) {
    return (
      atividade.startDate.getFullYear() != atividadeNext.startDate.getFullYear()
    );
  }
}
