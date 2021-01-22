import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class TerminService {

  apiUrl: string = 'https://localhost:44328/api';
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }

  addTermin(data: any){
      return this.http.post(this.apiUrl + '/termins', data)
  }

  getTermins() {
    return this.http.get(this.apiUrl + '/termins');
  }

  freeTermin(id: any) {
    return this.http.post(this.apiUrl + '/termins/free/' + id, {});
  }

  takeTermin(id: any) {
    return this.http.post(this.apiUrl + '/termins/take/' + id, {});
  }

}