import { Component, OnInit } from '@angular/core';
import { Construction } from '../../_models/construction.model';
import { Status } from '../../_models/status.model';
import { StatusService } from '../../_services/status.service';
import { ConstructionService } from '../../_services/construction.service';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { NgIf } from '@angular/common';
import { Router } from '@angular/router';
import { LeftNavbarComponent } from '../../_components/left-navbar/left-navbar.component';
import { CustomerService } from '../../_services/customer.service';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatRadioModule} from '@angular/material/radio';
import { AlertComponent } from '../../_components/alert/alert.component';

@Component({
  selector: 'app-construction',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    NgIf,
    LeftNavbarComponent,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatRadioModule,
    AlertComponent
  ],
  templateUrl: './construction.component.html',
  styleUrl: './construction.component.scss',
})
export class ConstructionComponent{
  construction!: Construction;
  defaultStatus!: Status;
  findById: boolean = true;
  company: boolean = false;
  alerts= [
    {
      type: 'success',
      message: 'Construction created successfully!',
    },
  ];

  registerForm: FormGroup;

  constructor(
    private constructionService: ConstructionService,
    private formBuilder: FormBuilder,
    private routerService: Router,
    private customerService: CustomerService,
  ) {
    this.registerForm = this.formBuilder.group({
      startDate: ['', [Validators.required, Validators.email]],
      endDate: [
        '',
        [
          Validators.required,
          Validators.maxLength(15),
          Validators.pattern('^[a-zA-Z]+$'),
        ],
      ],
      cpf: [
        '',
        [
          Validators.required,
          Validators.minLength(11),
          Validators.maxLength(11),
          Validators.pattern('^[0-9]*$'),
        ],
      ],
      cnpj: [
        '',
        [
          Validators.required,
          Validators.minLength(11),
          Validators.maxLength(11),
          Validators.pattern('^[0-9]*$'),
        ],
      ],
      user: ['', [Validators.required]],
      name: ['', [Validators.required]],
    });
  }

  saveConstruction() {
    this.routerService.navigate(['/profile']);
    this.registerForm.patchValue({
      user: JSON.parse(sessionStorage.getItem('user') || '{}'),
    });
    this.constructionService
      .createConstruction(this.registerForm.getRawValue())
      .subscribe(() => {
        console.log('Construction created successfully!');
      });
  }

  saveActivities() {
    // this.activitiService.createActivity(this.registerForm.getRawValue()).subscribe(() => {
    //   console.log('Activities created successfully!')
    // });
  }

  searchCustomer(): void {
    this.findById
      ? this.customerService.getCustomerById(1).subscribe((data) => {
          console.log(data);
        })
      : this.customerService
          .getCustomerByCustomerRegister('123456789')
          .subscribe((data) => {
            console.log(data);
          });
  }
}
