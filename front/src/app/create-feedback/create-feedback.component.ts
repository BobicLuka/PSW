import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FeedbackService } from '../services/feedbackService';

@Component({
  selector: 'app-create-feedback',
  templateUrl: './create-feedback.component.html',
  styleUrls: ['./create-feedback.component.scss']
})
export class CreateFeedbackComponent implements OnInit {

  feedbackForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private feedbackService: FeedbackService) 
  {
    this.feedbackForm = this.formBuilder.group({
      komentar: ['', Validators.required]
  });
  }

  ngOnInit(): void {
  }

  get f() { return this.feedbackForm.controls; }

  onSubmit() {
    // stop here if form is invalid
    if (this.feedbackForm.invalid) {
        return;
    }

    this.feedbackService.addFeedback(this.feedbackForm.value).subscribe(data => {
      console.log(data);
    });
  }

}
