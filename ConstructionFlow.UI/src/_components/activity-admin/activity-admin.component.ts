import { ActivityService } from './../../_services/activity.service';
import { Component, Input, OnInit } from '@angular/core';
import { Activity } from '../../_models/activity.model';
import { Construction } from '../../_models/construction.model';

@Component({
  selector: 'app-activity-admin',
  standalone: true,
  imports: [],
  templateUrl: './activity-admin.component.html',
  styleUrls: ['./activity-admin.component.scss']
})

export class ActivityAdminComponent implements OnInit{
  activities: Activity[] = [];
  @Input() construction: Construction = {} as Construction;

  constructor(private activityService: ActivityService) {
  }

  ngOnInit(): void {
    this.activityService.getActivitiesByConstruction(this.construction.id!).subscribe(activities => {
      this.activities = activities as Activity[];
    });
  }

  // formatador para real
  currencyFormatter = new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL'
  });

  editActivity(activity: Activity) {

  }

  deleteActivity(id: number) {
    // abrir modal para confirmar a exclusão
    // se confirmado, chamar o serviço de exclusão

    this.activityService.deleteActivity(id).subscribe(() => {
      this.activities = this.activities.filter(activity => activity.id !== id);
    });
  }

  trackByActivity(index: number, activity: Activity) {
    return activity.id;
  }

  getDate(date: Date){
    return new Date(date).toLocaleDateString()
  }
}
