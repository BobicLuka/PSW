import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  
  logged = false;
  
  

  constructor( private router:Router) { }

  admin = false;
  doctor = false;
  patient = false;

  logout() {

    localStorage.removeItem('token');
    localStorage.removeItem('user');

    this.router.navigate(['/login']);
  }

  ngOnInit() {

    let userString = localStorage.getItem('user');
    let user;
    if(userString) {
       user = JSON.parse(userString);
    }


    if(user) {
      this.logged = true;
    }

    if(user && user.type == "PATIENT") {
      this.patient = true;
    }

    if(user && user.type == "ADMIN") {
      this.admin = true;
    }

    if(user && user.type == "DOCTOR") {
      this.doctor = true;
    }

    
  }
}