import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { catchError, Observable, of, throwError } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'The Dating App';
  users: User[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getUsers().subscribe((data) => (this.users = data));
  }

  getUsers() {
    return this.http
      .get<User[]>('https://localhost:5001/api/users')
      .pipe(catchError(this.handleError));
  }

  handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred: ', error.error);
    } else {
      console.error(
        `Backend returned code ${error.status}, body was`,
        error.error
      );
    }

    return throwError(
      () => new Error('Something bad happened; please try again later.')
    );
  }
}

export interface User {
  id: number;
  username: string;
}
