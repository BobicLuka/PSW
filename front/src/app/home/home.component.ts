import { Component, OnInit } from '@angular/core';
import { Feedback } from '../feedback-list/feedback-list.component';
import { FeedbackService } from '../services/feedbackService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  displayedColumns: string[] = ['comment'];
  elements: Feedback[] = [];

  constructor(private feedbackService: FeedbackService) { }

  ngOnInit(): void {
    this.feedbackService.getPublicFeedbacks().subscribe(result => {

      this.elements = result;
    });
  }
}
