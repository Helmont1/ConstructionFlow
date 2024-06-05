import { Component, OnInit } from '@angular/core';
import { Construction } from '../../_models/construction.model';
import { Status } from '../../_models/status.model';
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
import { DefaultActivityService } from '../../_services/default-activity.service';
import { AuthService } from '../../security/auth.service';
import { User } from '../../_models/user.model';
import {
  CdkDragDrop,
  CdkDropList,
  CdkDrag,
  moveItemInArray,
} from '@angular/cdk/drag-drop';
import { Activity } from '../../_models/activity.model';
import { DialogModule } from '@angular/cdk/dialog';
import { Customer } from '../../_models/customer.model';
import { Observable, catchError, map } from 'rxjs';
import { ActivityModalComponent } from '../../_components/activity-modal/activity-modal.component';
import { ActivityService } from '../../_services/activity.service';
import { DefaultActivity } from '../../_models/default-activity.model';

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
    DialogModule,
    ActivityModalComponent,
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
  showActivityModal: boolean = false;
  alerts: Alert[] = [
    {
      type: 'success',
      message: 'Construção criada com sucesso!',
    },
  ];
  registerForm: FormGroup;
  defaultActivities: Activity[] = [];
  currencyFormat = new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL',
  });

  constructor(
    private constructionService: ConstructionService,
    private formBuilder: FormBuilder,
    private routerService: Router,
    private customerService: CustomerService,
    private defaultActivityService: DefaultActivityService,
    private authService: AuthService,
    private activityService: ActivityService
  ) {
    this.registerForm = this.formBuilder.group({
      startDate: ['', [Validators.required]],
      endDate: ['', [Validators.required]],
      register: ['', [Validators.required, Validators.minLength(11)]],
      name: ['', [Validators.required]],
      budget: ['', [Validators.required, Validators.min(1)]],
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
      budget: '' + this.registerForm.value.budget,
    };
    this.constructionService.createConstruction(this.construction).subscribe({
      next: (response) => {
        this.construction = response as Construction;
        this.saveActivities().subscribe({
          next: (response) => {
            this.alerts[0].message = 'Construção criada com sucesso!';
            this.alerts[0].type = 'success';
            this.routerService.navigate(['/profile'], {
              queryParams: { data: JSON.stringify(this.alerts) },
            });
          },
          error: (error) => {
            this.alerts[0].message = 'Erro ao criar atividades';
            this.alerts[0].type = 'danger';
            this.constructionService.deleteConstruction(this.construction.id!).subscribe({
              next: (response) => {
                this.routerService.navigate(['/profile'], {
                  queryParams: { data: JSON.stringify(this.alerts) },
                });
              },
              error: (error) => {
                console.log(error);
              },
            });
          },
        });
      },
      error: (error) => {
        this.alerts[0].message = 'Erro ao criar construção';
        this.alerts[0].type = 'danger';
      },
    });
  }
  verifyCustomer() {
    return this.customerService
      .getCustomerByCustomerRegister(
        this.registerForm.controls['register'].value
      )
      .pipe(
        map((customer) => {
          if (customer) {
            this.registerForm.controls['customerId'].setValue(customer.id);
            return customer.id;
          } else {
            return this.customerService
              .createCustomer(this.mountCustomer())
              .pipe(
                map((response) => {
                  this.registerForm.controls['customerId'].setValue(
                    response.id
                  );
                  return response.id;
                }),
                catchError((error) => {
                  this.alerts.push({
                    type: 'danger',
                    message: 'Erro ao criar cliente',
                  });
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
    this.defaultActivityService
      .getDefaultActivities()
      .subscribe((data: DefaultActivity[]) => {
        data.forEach((activity) => {
          this.defaultActivities.push({
            id: parseInt(activity.id!),
            activityName: activity.defaultActivityName,
            icon: activity.icon,
            startDate: new Date(),
            endDate: new Date(),
            budget: 0,
          });
        });
      });
  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(
      this.defaultActivities,
      event.previousIndex,
      event.currentIndex
    );
  }

  deleteActivity(activity: Activity) {
    this.defaultActivities = this.defaultActivities.filter(
      (act) => act.id !== activity.id
    );
  }

  addActivity(activity: Activity) {
    this.showActivityModal = false;
    this.defaultActivities.push(activity);
  }

  saveActivities() {
    return new Observable((observer) => {
      this.defaultActivities.forEach((activity, index) => {
        activity.id = undefined;
        activity.constructionId = this.construction.id;
        activity.statusId = 1;
        activity.startDate = new Date(activity.startDate);
        activity.endDate = new Date(activity.endDate);
        activity.order = index + 1;
        this.activityService.createActivity(activity).subscribe({
          next: (response) => {
            observer.next(response);
          },
          error: (error) => {
            observer.error(error);
          },
        });
      });
    });
  }
}
