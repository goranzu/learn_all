import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { catchError, map, ReplaySubject, throwError } from 'rxjs';
import { ILogin } from '../_models/ILogin';
import { IRegister } from '../_models/IRegister';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private baseUrl = 'https://localhost:5001/api';
  private _currentUserSource = new ReplaySubject<User | null>(1);
  userKey = 'user';
  currentUser$ = this._currentUserSource.asObservable();

  constructor(private http: HttpClient, private toastr: ToastrService) {}

  login = (model: ILogin) => {
    return this.http
      .post<User>(`${this.baseUrl}/accounts/login`, model)
      .pipe(map(this.setUserInLocalStorage));
    // .pipe(catchError(this.handleErrors));
  };

  register = (model: IRegister) => {
    return this.http
      .post<User>(`${this.baseUrl}/accounts/register`, model)
      .pipe(map(this.setUserInLocalStorage));
    // .pipe(catchError(this.handleErrors));
  };

  logout = () => {
    localStorage.removeItem(this.userKey);
    this._currentUserSource.next(null);
  };

  setCurrentUser = (user: User) => {
    this._currentUserSource.next(user);
  };

  private setUserInLocalStorage = (response: User) => {
    const user = response;
    if (user) {
      localStorage.setItem(this.userKey, JSON.stringify(user));
      this._currentUserSource.next(user);
    }
    return user;
  };

  // private handleErrors = (error: HttpErrorResponse) => {
  //   if (error.status === 0) {
  //     console.error('An error occurred: ', error.error);
  //   } else {
  //     console.error(
  //       `Backend returned code ${error.status}, body was`,
  //       error.error
  //     );
  //     console.error(error);
  //   }

  //   return throwError(
  //     () => new Error('Something bad happened; please try again later.')
  //   );
  // };
}
