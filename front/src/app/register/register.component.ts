import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../services/userService';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;

  constructor(
      private formBuilder: FormBuilder,
      private userService: UserService
  ) {

    this.registerForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
      firstName: ['',Validators.required],
      lastName: ['',Validators.required]
  });
  }

  ngOnInit() {
      
  }

  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  onSubmit() {
      // stop here if form is invalid
      if (this.registerForm.invalid) {
          return;
      }

      this.userService.register(this.registerForm.value).subscribe(data => {
        console.log(data);
      });
  }
}
