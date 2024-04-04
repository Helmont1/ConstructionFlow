import { HTTP_INTERCEPTORS, HttpHandler, HttpInterceptor, HttpInterceptorFn, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "../environments/environment.development";

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const request = req.clone({
    url: environment.apiUrl + `${req.url}`
  });
  return next(request);
};
