import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../../security/auth.service';
import { Router, RouterLink } from '@angular/router';
import { NgIf } from '@angular/common';

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
  constructor(private formBuilder: FormBuilder,
      private routerService: Router,
      private authService: AuthService
    ){
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });

  }
  onSubmit() {
    this.authService.login();
    this.routerService.navigate(['/profile']);
  }

  debugEmailErrors() {
    console.log('Email inválido:', this.loginForm.get('email')?.errors);
  }
}
