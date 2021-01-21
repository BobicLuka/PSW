import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MedicamentService } from '../services/medicamentService';

@Component({
  selector: 'app-add-medicaments',
  templateUrl: './add-medicaments.component.html',
  styleUrls: ['./add-medicaments.component.scss']
})
export class AddMedicamentsComponent implements OnInit {

  medicamentForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private medicamentService: MedicamentService) 
  {
    this.medicamentForm = this.formBuilder.group({
      name: ['', Validators.required],
      quantity: ['', Validators.required]
  });
  }

  ngOnInit(): void {
  }

  get f() { return this.medicamentForm.controls; }

  onSubmit() {
    // stop here if form is invalid
    if (this.medicamentForm.invalid) {
        return;
    }

    this.medicamentService.addMedicament({
      name: this.medicamentForm.value.name,
      quantity: parseInt(this.medicamentForm.value.quantity)
    }).subscribe(data => {
      console.log(data);
    });
  }

}
