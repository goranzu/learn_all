import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ILogin } from '../_models/ILogin';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
})
export class NavComponent implements OnInit {
  model: ILogin = {
    username: '',
    password: '',
  };

  constructor(public accountService: AccountService) {}

  ngOnInit(): void {}

  login() {
    this.accountService.login(this.model).subscribe((response) => {
      console.log(response);
    });
  }

  logout() {
    this.accountService.logout();
  }
}
