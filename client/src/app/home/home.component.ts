import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  registerMode = false;

  constructor() {}

  ngOnInit(): void {}

  onRegisterClick() {
    this.registerMode = !this.registerMode;
  }

  onCancel(event: boolean) {
    this.registerMode = event;
  }
}
