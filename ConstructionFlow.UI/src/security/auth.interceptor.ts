import { HTTP_INTERCEPTORS, HttpHandler, HttpInterceptor, HttpInterceptorFn, HttpRequest } from "@angular/common/http";
import { environment } from "../environments/environment.development";
import { inject } from "@angular/core";
import { NgxSpinnerService } from "ngx-spinner";
import { catchError, finalize, map, throwError } from "rxjs";

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const spinner = inject(NgxSpinnerService);
  const request = req.clone({
    url: environment.apiUrl + `${req.url}`
  });

  spinner.show();
  return next(request).pipe(
    map(event => {return event}),
    finalize(() => {spinner.hide()}),
    catchError(error => {
      if (spinner) {
        spinner.hide();
      }
      return throwError(error);
    })
  );

};


