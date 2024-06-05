import { Component, Input, OnInit } from '@angular/core';
import { Activity } from '../../_models/activity.model';
import { ActivityComponent } from '../activity/activity.component';
import { ProgressCircleComponent } from '../progress-circle/progress-circle.component';
@Component({
  selector: 'app-timeline',
  standalone: true,
  imports: [ActivityComponent, ProgressCircleComponent],
  templateUrl: './timeline.component.html',
  styleUrl: './timeline.component.scss',
})
export class TimelineComponent implements OnInit {
  @Input() atividades: Activity[] = [];
  budget = 0;
  Intl = Intl.NumberFormat('pt-BR', { style: 'currency', currency: 'BRL' });
  @Input() construction: any;
  endExpectedIn = '';
  conclusionPercentage = 0;
  budgetPercentage = 0;

  ngOnInit(): void {
    let finishedActivities = 0;
    this.atividades.forEach((atividade) => {
      atividade.startDate = new Date(atividade.startDate);
      atividade.endDate = new Date(atividade.endDate);
      if (atividade.budget) {
        if (atividade.status!.id == 3) this.budget += atividade.budget;
        else if (atividade.status!.id == 2) this.budget += atividade.budget / 2;
      }
      if (atividade.status!.id == 3) {
        finishedActivities++;
      } else if (atividade.status!.id == 2) {
        finishedActivities += 0.5;
      }
    });
    this.conclusionPercentage =
      Math.round((finishedActivities / this.atividades.length) * 10000) / 100;
    this.budgetPercentage =
      Math.round((this.budget / this.construction.budget) * 10000) / 100;
    this.endExpectedIn = this.getEndExpectedIn();
  }

  getEndExpectedIn() {
    if (this.construction.status.id == 3) return 'Concluído';

    const endDate = this.construction.endDate;
    const now = new Date();
    const end = new Date(endDate);

    let years = end.getFullYear() - now.getFullYear();
    let months = end.getMonth() - now.getMonth();
    let days = end.getDate() - now.getDate();

    // Ajustar os valores para evitar números negativos
    if (days < 0) {
      months--;
      days += new Date(now.getFullYear(), now.getMonth() + 1, 0).getDate();
    }

    if (months < 0) {
      years--;
      months += 12;
    }

    if (
      years < 0 ||
      (years === 0 && months < 0) ||
      (years === 0 && months === 0 && days < 0)
    ) {
      years = now.getFullYear() - end.getFullYear();
      months = now.getMonth() - end.getMonth();
      days = now.getDate() - end.getDate();

      if (days < 0) {
        months--;
        days += new Date(end.getFullYear(), end.getMonth() + 1, 0).getDate();
      }

      if (months < 0) {
        years--;
        months += 12;
      }

      return `Atrasado em ${years} anos ${months} meses e ${days} dias`;
    }

    return `${years} anos ${months} meses e ${days} dias`;
  }

  hasTimeLine(atividade: Activity, atividadeNext: Activity) {
    if (!atividadeNext) return false;
    return (
      new Date(atividade.startDate).getFullYear() !=
      new Date(atividadeNext.startDate).getFullYear()
    );
  }

  getData(atividade: Activity) {
    return {
      year: new Date(atividade.startDate).getFullYear(),
      date:
        '' +
        this.getMonthName(new Date(atividade.startDate).getMonth()) +
        ' ' +
        new Date(atividade.startDate).getDate(),
      name: atividade.activityName,
    };
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
