import { Component, Input, OnInit, Output } from '@angular/core';
import { User } from '../_models/user';

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

  @Input() users: User[] = [];
  @Output() cancelRegister = false;

  constructor() {}

  ngOnInit(): void {
    console.log(this.users);
  }

  onRegister() {
    console.log(this.model);
  }

  onCancel() {
    console.log('cancel');
  }
}

interface IRegister {
  username: string;
  password: string;
}
