import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import {AuthService} from '../auth/auth.service';
import {environment} from '../../environments/environment';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private authenticationService: AuthService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const currentPerson = this.authenticationService.currentPersonValue;
    // @ts-ignore
    const isLoggedIn = currentPerson && currentPerson.token;
    const isApiUrl = request.url.startsWith(environment.api);
    if (isLoggedIn && isApiUrl) {
      request = request.clone({
        setHeaders: {
          // @ts-ignore
          Authorization: `Bearer ${currentPerson.token}`
        }
      });
    }

    return next.handle(request);
  }
}
