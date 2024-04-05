import { Component } from '@angular/core';
import { Construction } from '../../_models/construction.model';
import { Status } from '../../_models/status.model';
import { StatusService } from '../../_services/status.service';
import { ConstructionService } from '../../_services/construction.service';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivityService } from '../../_services/activity.service';
import { NgIf } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-construction',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, NgIf],
  templateUrl: './construction.component.html',
  styleUrl: './construction.component.scss'
})
export class ConstructionComponent {
  construction!: Construction
  defaultStatus!: Status

  registerForm: FormGroup;
  
  constructor(private statusService: StatusService, private constructionService: ConstructionService, private formBuilder: FormBuilder, private activitiService: ActivityService, private routerService: Router) {
    this.registerForm = this.formBuilder.group({
      startDate: ['', [Validators.required, Validators.email]],
      endDate: ['', [Validators.required, Validators.maxLength(15), Validators.pattern("^[a-zA-Z]+$")]],
      customer: ['', [Validators.required, Validators.minLength(14), Validators.maxLength(14), Validators.pattern("^[0-9]*$")]],
      user: ['', [Validators.required] ],
      name: ['', [Validators.required] ]
    });
  }

  saveConstruction() {
    this.routerService.navigate(['/profile']);
    this.registerForm.patchValue({
    user: JSON.parse(sessionStorage.getItem('user') || '{}')
  });
    this.constructionService.createConstruction(this.registerForm.getRawValue()).subscribe(() => {
      console.log('Construction created successfully!')
    });
    
  }

  saveActivities() {
    // this.activitiService.createActivity(this.registerForm.getRawValue()).subscribe(() => {
    //   console.log('Activities created successfully!')
    // });
  }
}
