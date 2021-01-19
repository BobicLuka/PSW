import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../services/userService';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {


  loginForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService
) {

  this.loginForm = this.formBuilder.group({
    email: ['', Validators.required],
    password: ['', Validators.required]
});
}

ngOnInit() {
    this.loginForm = this.formBuilder.group({
        email: ['', Validators.required],
        password: ['', Validators.required]
    });
}

// convenience getter for easy access to form fields
get f() { return this.loginForm.controls; }

onSubmit() {
    // stop here if form is invalid
    if (this.loginForm.invalid) {
        return;
    }

    this.userService.login(this.loginForm.value).subscribe(data => {
      localStorage.setItem('token', data['token']);
    });
}

}