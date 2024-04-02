import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { FormBuilder, FormGroup, FormsModule, Validators, ReactiveFormsModule, ValidationErrors, ValidatorFn, AbstractControl } from '@angular/forms';
import { NgIf } from '@angular/common';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    RouterLink,
    ReactiveFormsModule,
    NgIf,
    NgxMaskDirective, 
    NgxMaskPipe
  ],
  providers: [provideNgxMask()],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  registerForm: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.registerForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      name: ['', [Validators.required, Validators.maxLength(15), Validators.pattern("^[a-zA-Z]+$")]],
      cnpj: ['', [Validators.required, Validators.minLength(14), Validators.maxLength(14), Validators.pattern("^[0-9]*$")]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    }, { validator: passwordsMatchValidator('password', 'confirmPassword') });
  }
  onSubmit() {
    console.log(this.registerForm.value);
  }
  
}



function passwordsMatchValidator(passwordKey: string, confirmPasswordKey: string): ValidatorFn {
  return (formGroup: AbstractControl<any, any>): ValidationErrors | null => {
    const passwordControl = formGroup.get(passwordKey);
    const confirmPasswordControl = formGroup.get(confirmPasswordKey);

    if (passwordControl && confirmPasswordControl && passwordControl.value !== confirmPasswordControl.value) {
      confirmPasswordControl?.setErrors({ notEqual: true });
    } else {
      confirmPasswordControl?.setErrors(null);
    }

    return null;
  };
}

