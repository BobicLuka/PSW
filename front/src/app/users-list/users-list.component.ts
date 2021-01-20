import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/userService';

export interface User {
  id: number,
  email: string;
  firstName: string;
  lastName: string;
}

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {


  displayedColumns: string[] = ['email', 'firstName', 'lastName', 'action'];
  elements: User[] = [];

  constructor(private userService: UserService) { }

  ngOnInit(): void {

    this.userService.getAllUsers().subscribe(result => {

      this.elements = result;
    });
  }

  block(event: any, element: User) {
    this.userService.block(element.id).subscribe(data => {
      this.ngOnInit();
    })
  }

  unblock(event: any, element: User) {
    this.userService.unblock(element.id).subscribe(data => {
      this.ngOnInit();
    })
  }

}
