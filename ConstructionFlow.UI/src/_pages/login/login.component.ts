import { CommonModule, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { UserService } from '../../_services/user.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    RouterLink,
    ReactiveFormsModule,
    NgIf
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  loginForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private userService: UserService) {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });

  }
  onSubmit() {
    this.userService.getUser('3b8b20f9-019a-4d9d-3f9e-08dc5365e5bb').subscribe((user) => {
      sessionStorage.setItem('user', JSON.stringify(user));
    });
  }

  debugEmailErrors() {
    console.log('Email inválido:', this.loginForm.get('email')?.errors);
  }
}
