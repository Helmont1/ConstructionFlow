import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { AuthService } from '../../security/auth.service';
import { Router, RouterLink } from '@angular/router';
import { NgIf, NgStyle } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    RouterLink, 
    ReactiveFormsModule, 
    NgIf,
    NgStyle
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  loginForm: FormGroup;
  loading: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private routerService: Router,
    private authService: AuthService
  ) {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }
  onSubmit() {
    this.authService.login().subscribe(() => {
      this.routerService.navigate(['/home']);
    });
  }

  debugEmailErrors() {
    console.log('Email inválido:', this.loginForm.get('email')?.errors);
  }
}
