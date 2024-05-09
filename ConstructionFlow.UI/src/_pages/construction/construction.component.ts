import { Component, Output, ViewChild } from '@angular/core';
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
import { MatRadioModule } from '@angular/material/radio';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';
import { Alert } from '../../_components/alert/alert.component';
import { DefaultActivity } from '../../_models/default-activity.model';
import { DefaultActivityService } from '../../_services/default-activity.service';
import { OnInit } from '@angular/core';
import { AuthService } from '../../security/auth.service';
import { User } from '../../_models/user.model';
import {
  CdkDragDrop,
  CdkDropList,
  CdkDrag,
  moveItemInArray,
} from '@angular/cdk/drag-drop';
import { Activity } from '../../_models/activity.model';
import { DialogModule, DialogRef } from '@angular/cdk/dialog';
import { Customer } from '../../_models/customer.model';
import { Observable, catchError, map } from 'rxjs';

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
    NgxMaskDirective,
    NgxMaskPipe,
    CdkDropList,
    CdkDrag,
    DialogModule
  ],
  providers: [provideNgxMask()],
  templateUrl: './construction.component.html',
  styleUrl: './construction.component.scss',
})
export class ConstructionComponent implements OnInit {
  construction!: Construction;
  defaultStatus!: Status;
  findById: boolean = true;
  company: boolean = false;
  user: User = {} as User;
  activities: Activity[] = [
    {
      defaultActivity: {
        defaultActivityName: 'Jogar tudo fora',
        icon: '😊',
      } as DefaultActivity,
    } as Activity,
    {
      defaultActivity: {
        defaultActivityName: 'Jogar tudo fora',
        icon: '🏠',
      } as DefaultActivity,
    } as Activity,
    {
      defaultActivity: {
        defaultActivityName: 'Jogar tudo fora',
        icon: '🐆',
      } as DefaultActivity,
    } as Activity,
    {
      defaultActivity: {
        defaultActivityName: 'Jogar tudo fora',
        icon: '🤡',
      } as DefaultActivity,
    } as Activity,
    {
      defaultActivity: {
        defaultActivityName: 'Jogar tudo fora',
        icon: '😊',
      } as DefaultActivity,
    } as Activity,
  ];

  alerts: Alert[] = [
    {
      type: 'success',
      message: 'Construção criada com sucesso!',
    },
  ];

  registerForm: FormGroup;

  defaultActivities: DefaultActivity[] = [];

  constructor(
    private constructionService: ConstructionService,
    private formBuilder: FormBuilder,
    private routerService: Router,
    private customerService: CustomerService,
    private defaultActivityService: DefaultActivityService,
    private authService: AuthService
  ) {
    this.registerForm = this.formBuilder.group({
      startDate: ['', [Validators.required]],
      endDate: ['', [Validators.required]],
      register: ['', [Validators.required, Validators.minLength(11)]],
      name: ['', [Validators.required]],
      userId: [0],
      statusId: [1],
      customerId: [1],
    });
  }
  onSubmit() {
    this.authService.getUser().then((user) => {
      this.verifyCustomer().subscribe(() => {
        this.createConstruction(user);
      });
    });
  }
  createConstruction(user: User) {
    this.construction = {
      statusId: this.registerForm.value.statusId,
      startDate: new Date(this.registerForm.value.startDate),
      endDate: new Date(this.registerForm.value.endDate),
      userId: user.id ?? 0,
      customerId: this.registerForm.value.customerId,
      title: this.registerForm.value.name,
    };
    console.log('vou criar a construcao heim hmhm ');
    console.log(this.construction);
    this.constructionService.createConstruction(this.construction).subscribe({
      next: (response) => {
        this.alerts[0].message = 'Construção criada com sucesso!';
        this.alerts[0].type = 'success';
        this.routerService.navigate(['/profile'], {
          queryParams: { data: JSON.stringify(this.alerts) },
        });
      },
      error: (error) => {
        this.alerts[0].message = 'Erro ao criar construção';
        this.alerts[0].type = 'danger';
      },
    });
  }
  verifyCustomer() {
    return this.customerService.getCustomerByCustomerRegister(this.registerForm.controls['register'].value).pipe(
      map(customer => {
        if (customer) {
          this.registerForm.controls['customerId'].setValue(customer.id);
          return customer.id;
        } else {
          return this.customerService.createCustomer(this.mountCustomer()).pipe(
            map(response => {
              this.registerForm.controls['customerId'].setValue(response.id);
              return response.id;
            }),
            catchError(error => {
              this.alerts[0].message = 'Erro ao criar cliente';
              this.alerts[0].type = 'danger';
              throw error;
            })
          );
        }
      })
    );
  }

  mountCustomer(): Customer {
    return {
      customerCpf:
        this.registerForm.controls['register'].value.length == 11
          ? this.registerForm.controls['register'].value
          : null,
      customerCnpj:
        this.registerForm.controls['register'].value.length == 14
          ? this.registerForm.controls['register'].value
          : null,
    } as Customer;
  }

  ngOnInit() {
    this.getDefaultActivities();
    this.authService.getUser().then((user) => {
      this.user = user;
    });
  }

  getDefaultActivities() {
    this.defaultActivityService.getDefaultActivities().subscribe((data) => {
      this.defaultActivities = data;
    });
  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.activities, event.previousIndex, event.currentIndex);
  }

  saveActivities() {
    this.activities.forEach((activity, index) => {
      activity.order = index + 1;
    });
    console.log(this.activities);
  }
}
