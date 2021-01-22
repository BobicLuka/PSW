import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
  })
export class CustomInterceptor implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
    const tokenString = (String)(localStorage.getItem('token') ? localStorage.getItem('token') : "");
    const token = tokenString ? JSON.parse(tokenString) : null;

    if(token) {
        const modifiedReq = req.clone({ 
            headers: req.headers.set('Authorization', `Bearer ${token.token}`),
          });
          return next.handle(modifiedReq);
    }

    return next.handle(req);
  }
}