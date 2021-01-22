import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TerminService } from '../services/terminService';
import { UserService } from '../services/userService';

@Component({
  selector: 'app-termins',
  templateUrl: './termins.component.html',
  styleUrls: ['./termins.component.scss']
})
export class TerminsComponent implements OnInit {

  displayedColumns: string[] = ['date', 'patient', 'doctor', 'free', 'action'];
  elements: any;
  customForm : FormGroup;
  doctors: any;

  constructor(private terminService: TerminService,
    private userService: UserService, private formBuilder: FormBuilder) {
    this.customForm = this.formBuilder.group({
      dateFrom: [null, Validators.required],
      dateTo: [null, Validators.required],
      doctor: [null, Validators.required],
      type: [null, Validators.required],
    });
   }

  ngOnInit(): void {

    this.elements = [];

    this.terminService.getTermins().subscribe(result => {

      this.elements = result;
    });

    this.doctors = [];

    this.userService.getDoctors().subscribe(data => {
      this.doctors = data
    });
  }

  take(event :any, element :any) {
    this.terminService.takeTermin(element.id).subscribe(result => {

      this.ngOnInit();
    });
  }

  cancel(event:any, element:any) {
    this.terminService.freeTermin(element.id).subscribe(result => {

      this.ngOnInit();
    });
  }

  search() {
    this.terminService.getTermins().subscribe(result => {

      this.elements = result;
    });
  }

}
