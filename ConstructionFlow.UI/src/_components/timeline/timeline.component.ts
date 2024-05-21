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
export class TimelineComponent implements OnInit{
  @Input() atividades: Activity[] = [];
  ngOnInit(): void {
    this.atividades.forEach(atividade => {
      atividade.startDate = new Date(atividade.startDate);
      atividade.endDate = new Date(atividade.endDate);
    });
    console.log(this.atividades);
  }

  hasTimeLine(atividade: Activity, atividadeNext: Activity) {
    if (!atividadeNext) return false;
    console.log(atividade, atividadeNext);
    return (
      atividade.startDate.getFullYear() != atividadeNext.startDate.getFullYear()
    );
  }

  getMonthName(month: number) {
    const months = [
      'Jan',
      'Fev',
      'Mar',
      'Abr',
      'Mai',
      'Jun',
      'Jul',
      'Ago',
      'Set',
      'Out',
      'Nov',
      'Dez',
    ];
    return months[month];
  }
}
