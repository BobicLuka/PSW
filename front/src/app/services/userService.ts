import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  apiUrl: string = 'https://localhost:44328/api';
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }

  login(data: any) {
    return this.http.post(this.apiUrl + '/token', data);
  }

  getCurrentUser() {
    return this.http.get(this.apiUrl + '/token/get-current');
}

getDoctors() {
  return this.http.get(this.apiUrl + '/users/doctors')
}

  getUser(id: string) {
    return this.http.get(this.apiUrl + '/users/' + id)
  }

  register(data: any) {
      return this.http.post(this.apiUrl + '/users', data);
  }

  getAllUsers() {
    return this.http.get<any[]>(this.apiUrl + '/users/all');
  }

  block(id: number) {
    return this.http.post(this.apiUrl + '/users/block/' + id, {});
}

  unblock(id: number) {
    return this.http.post(this.apiUrl + '/users/unblock/' + id, {});
  }

}