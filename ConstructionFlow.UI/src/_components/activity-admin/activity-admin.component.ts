import { ActivityService } from './../../_services/activity.service';
import { Component, Input, OnInit } from '@angular/core';
import { Activity } from '../../_models/activity.model';
import { Construction } from '../../_models/construction.model';
import { ActivityModalComponent } from '../activity-modal/activity-modal.component';

@Component({
  selector: 'app-activity-admin',
  standalone: true,
  imports: [
    ActivityModalComponent
  ],
  templateUrl: './activity-admin.component.html',
  styleUrls: ['./activity-admin.component.scss']
})

export class ActivityAdminComponent implements OnInit{
  activities: Activity[] = [];
  @Input() construction: Construction = {} as Construction;
  showActivityModal: boolean = false;
  activityEditing: Activity = {} as Activity;
  isEditing: boolean = false;

  constructor(private activityService: ActivityService) {
  }

  ngOnInit(): void {
    this.activityService.getActivitiesByConstruction(this.construction.id!).subscribe(activities => {
      this.activities = activities as Activity[];
    });
  }

  currencyFormatter = new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL'
  });

  showModal(){
    this.isEditing = false;
    this.activityEditing = {} as Activity;
    this.showActivityModal = true;
  }

  formatDateToInput(date: Date | string){
    return new Date(date).toISOString().split('T')[0];
  }

  saveActivity(activity: Activity) {
    activity.constructionId = this.construction.id!;
    activity.startDate = new Date(activity.startDate);
    activity.endDate = new Date(activity.endDate);
    if(this.isEditing){
      this.activityService.editActivity(activity).subscribe(() => {
        this.ngOnInit();
      }
      );
    }
    else{
      activity.statusId = 1;
      activity.order = this.activities.length;
      this.activityService.createActivity(activity).subscribe(() => {
        this.ngOnInit();
      });
    }
    this.showActivityModal = false;
  }


  editActivity(activity: Activity) {
    this.activityEditing = activity;
    this.activityEditing.startDate = this.formatDateToInput(activity.startDate);
    this.activityEditing.endDate = this.formatDateToInput(activity.endDate);
    this.isEditing = true;
    this.showActivityModal = true;
  }

  deleteActivity(id: number) {
    this.activityService.deleteActivity(id).subscribe(() => {
      this.activities = this.activities.filter(activity => activity.id !== id);
    });
  }

  trackByActivity(index: number, activity: Activity) {
    return activity.id;
  }

  getDate(date: Date | string){
    return new Date(date).toLocaleDateString()
  }
}
