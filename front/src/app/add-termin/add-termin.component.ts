import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TerminService } from '../services/terminService';
import { UserService } from '../services/userService';

@Component({
  selector: 'app-add-termin',
  templateUrl: './add-termin.component.html',
  styleUrls: ['./add-termin.component.scss']
})
export class AddTerminComponent implements OnInit {

  customForm : FormGroup;
  doctors: any;

  constructor(private formBuilder: FormBuilder, private userService: UserService ,
    private terminService : TerminService) { 


      this.customForm = this.formBuilder.group({
        date: [null, Validators.required],
        doctor: [null, Validators.required],
      });
    }

  ngOnInit(): void {


    this.doctors = [];

    this.userService.getDoctors().subscribe(data => {
      this.doctors = data
    });

  }

  onSubmit() {

    if (!this.customForm.valid) {
      return;
    }

    this.terminService.addTermin({
      doctor: { id: this.customForm.value.doctor} ,
      date: this.customForm.value.date,
    }).subscribe(data => {
      
    });
  }

}