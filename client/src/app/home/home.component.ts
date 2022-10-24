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
  users: User[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getUsers();
  }

  onRegisterClick() {
    this.registerMode = !this.registerMode;
  }

  onCancel() {
    console.log('cancel');
  }

  getUsers() {
    this.http.get<User[]>('https://localhost:5001/api/users').subscribe({
      next: (response) => {
        this.users = response;
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
}
