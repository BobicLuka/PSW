import { Component, OnInit } from '@angular/core';
import { FeedbackService } from '../services/feedbackService';

export interface Feedback {
  id: number,
  komentar: string;
  kom: string;
}

@Component({
  selector: 'app-feedback-list',
  templateUrl: './feedback-list.component.html',
  styleUrls: ['./feedback-list.component.scss']
})
export class FeedbackListComponent implements OnInit {

  displayedColumns: string[] = ['comment', 'action'];
  elements: Feedback[] = [];

  constructor(private feedbackService: FeedbackService) { }

  ngOnInit(): void {
    this.feedbackService.getFeedbacks().subscribe(result => {

      this.elements = result;
    });
  }

  publish(event: any, element: Feedback) {
    this.feedbackService.publish(element.id).subscribe(data => {
      this.ngOnInit();
    })
  }

  unpublish(event: any, element: Feedback) {
    this.feedbackService.unpublish(element.id).subscribe(data => {
      this.ngOnInit();
    })
  }
}
