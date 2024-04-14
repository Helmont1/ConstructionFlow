import { HTTP_INTERCEPTORS, HttpHandler, HttpInterceptor, HttpInterceptorFn, HttpRequest } from "@angular/common/http";
import { environment } from "../environments/environment.development";
import { inject } from "@angular/core";
import { NgxSpinnerService } from "ngx-spinner";
import { catchError, finalize, map, throwError } from "rxjs";
import { AuthService } from "./auth.service";

export const authInterceptor: HttpInterceptorFn = (req, next) => {

  const spinner = inject(NgxSpinnerService);
  const authService = inject(AuthService);
  const request = req.clone({
    url: environment.apiUrl + `${req.url}`
  });


  if (authService.isLoggedIn()) {
    request.headers.set('Authorization', `Bearer ${authService.getToken()}`);
  } else if (!request.url.includes('login')) {
    return throwError(() => new Error('Unauthorized'));
  }

  spinner.show();
  return next(request).pipe(
    map(event => { return event }),
    finalize(() => { spinner.hide() }),
    catchError(error => {
      if (spinner) {
        spinner.hide();
      }
      return throwError(() => error);
    })
  );
};


