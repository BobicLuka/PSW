import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {


  loginForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
) {

  this.loginForm = this.formBuilder.group({
    username: ['', Validators.required],
    password: ['', Validators.required]
});
}

ngOnInit() {
    this.loginForm = this.formBuilder.group({
        username: ['', Validators.required],
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
}

}