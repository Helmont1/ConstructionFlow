import {
  HTTP_INTERCEPTORS,
  HttpHandler,
  HttpInterceptor,
  HttpInterceptorFn,
  HttpRequest,
} from '@angular/common/http';
import { environment } from '../environments/environment.development';
import { inject } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { catchError, finalize, map, throwError } from 'rxjs';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const spinner = inject(NgxSpinnerService);
  const authService = inject(AuthService);
  const router = inject(Router);
  const request = req.clone({
    url: environment.apiUrl + `${req.url}`,
  });

  if (authService.isLoggedIn()) {
    request.headers.set('Authorization', `Bearer ${authService.getToken()}`);
  } else if (!request.url.includes('login') && !(request.url.endsWith('User') && request.method == 'POST')) {
    return throwError(() => new Error('Unauthorized'));
  }

  spinner.show();
  return next(request).pipe(
    map((event) => {
      return event;
    }),
    finalize(() => {
      spinner.hide();
    }),
    catchError((error) => {
      if (spinner) {
        spinner.hide();
      }
      if (error.status === 500) {
        alert('Tempo de espera excedido');
        if (authService.isLoggedIn()) authService.logout();
        router.navigate(['/login']);
      }
      return throwError(() => error);
    })
  );
};
