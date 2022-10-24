import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  model: IRegister = {
    username: '',
    password: '',
  };

  @Output() cancelRegister = new EventEmitter<boolean>();

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {}

  onRegister = () => {
    this.accountService.register(this.model).subscribe((response) => {
      console.log(response);
      this.onCancel();
    });
  };

  onCancel() {
    this.cancelRegister.emit(false);
  }
}

interface IRegister {
  username: string;
  password: string;
}
