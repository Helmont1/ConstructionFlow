import { HTTP_INTERCEPTORS, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "../environments/environment.development";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor() {

  }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const request = req.clone({
      url: environment.apiUrl + `${req.url}`
    });
    return next.handle(request);
  }
}

export const AuthInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: AuthInterceptor,
  multi: true
};
