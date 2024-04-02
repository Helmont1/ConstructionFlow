import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { FormBuilder, FormGroup, FormsModule, Validators, ReactiveFormsModule } from '@angular/forms'
import { get } from 'http';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    RouterLink,
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  registerForm: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.registerForm = this.formBuilder.group({
      email: [''],
      name: [''],
      cnpj: [''],
      senha: [''],
    });

    this.registerForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      name: ['', [Validators.required, Validators.maxLength(15), Validators.pattern("^[a-zA-Z]+$")]],
      cnpj: ['', [Validators.required, Validators.minLength(14), Validators.maxLength(14), Validators.pattern("^[0-9]*$")]],
      senha: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  get email() { return this.registerForm.get('email'); }
  get name() { return this.registerForm.get('name'); }
  get cnpj() { return this.registerForm.get('cnpj'); }
  get senha() { return this.registerForm.get('senha'); } 
  onSubmit() {
    console.log(this.registerForm.value);
  }
  
}



