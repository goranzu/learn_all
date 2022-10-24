import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'The Dating App';
  users: User[] = [];

  constructor(private accountService: AccountService) {}

  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const userFromStorage = localStorage.getItem(this.accountService.userKey);
    if (userFromStorage == null) {
      throw new Error('User is null');
    }
    const user: User = JSON.parse(userFromStorage);
    this.accountService.setCurrentUser(user);
  }
}
