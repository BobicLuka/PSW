import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class FeedbackService {

  apiUrl: string = 'https://localhost:44328/api';
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }

  getFeedbacks() {
    return this.http.get<any[]>(this.apiUrl + '/feedbacks/all');
  }

  getPublicFeedbacks() {
    return this.http.get<any[]>(this.apiUrl + '/feedbacks/public');
  }

  addFeedback(data: any) {
    return this.http.post(this.apiUrl + '/feedbacks', data);
  }

  publish(id: number) {
    return this.http.post(this.apiUrl + '/feedbacks/publish/' + id, {});
  }

  unpublish(id: number) {
    return this.http.post(this.apiUrl + '/feedbacks/unpublish/' + id, {});
  }
}