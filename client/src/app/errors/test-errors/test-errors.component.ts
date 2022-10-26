import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.scss'],
})
export class TestErrorsComponent implements OnInit {
  private baseUrl = 'https://localhost:5001';
  validationErrors: string[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {}

  get404Error = () => {
    this.http.get<IServerError>(`${this.baseUrl}/errors/not-found`).subscribe({
      next: this.onSuccess,
      error: this.onError,
    });
  };

  get500Error = () => {
    this.http
      .get<IServerError>(`${this.baseUrl}/errors/server-error`)
      .subscribe({
        next: this.onSuccess,
        error: this.onError,
      });
  };

  get400Error = () => {
    this.http
      .get<IServerError>(`${this.baseUrl}/errors/bad-request`)
      .subscribe({
        next: this.onSuccess,
        error: this.onError,
      });
  };

  get400ValidationError = () => {
    this.http
      .post<IServerError>(`${this.baseUrl}/api/accounts/register`, {
        username: '',
        password: '',
      })
      .subscribe({
        next: this.onSuccess,
        error: (errors) => {
          this.validationErrors = errors;
        },
      });
  };

  get401Error = () => {
    this.http.get<IServerError>(`${this.baseUrl}/errors/auth`).subscribe({
      next: this.onSuccess,
      error: this.onError,
    });
  };

  private onError(error: HttpErrorResponse) {
    console.error(error);
  }

  private onSuccess(response: IServerError) {
    console.log(response);
  }
}

interface IServerError {
  statusCode: number;
  message?: string;
  details?: string;
}
