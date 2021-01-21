import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class MedicamentService {

  apiUrl: string = 'https://localhost:44328/api';
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }

  addMedicament(data: any){
      return this.http.post(this.apiUrl + '/medicaments', data)
  }

  getMedicaments() {
    return this.http.get(this.apiUrl + '/medicaments/get-all');
  }

}