import { Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import { UserModel } from '../Model/Usermodel';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { loginModel } from '../Model/Loginmodel';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  apiurl = environment.apiUrl;
  public _isLoggedIn$ = new BehaviorSubject<boolean>(false);
  private _notLoggedIn$ = new BehaviorSubject<boolean>(false);
  private readonly token_name = 'token';
  isLoggedIn$ = this._isLoggedIn$.asObservable();
  notLoggedIn$ = this._notLoggedIn$.asObservable();
  user!: UserModel | null;

  constructor(private http: HttpClient, private router: Router) {
    this._isLoggedIn$.next(!!this.token);
    this._notLoggedIn$.next(!!!this.token);
    this.user = this.getUser(this.token);
  }

  get token(): any {
    console.log(localStorage.getItem(this.token_name));
    return localStorage.getItem(this.token_name);
  }

  loginService(model: loginModel) {
    const url = this.apiurl + 'Account/Login';
    return this.http.post(url, model).pipe(
      tap((response: any) => {
        console.log(response);
        this._isLoggedIn$.next(true);
        this._notLoggedIn$.next(false);
        console.log(response.token);
        localStorage.setItem(this.token_name, response.token);
        console.log(response);
        this.user = this.getUser(response.token);
      })
    );
  }

  private getUser(token: string): UserModel | null {
    if (!token) {
      return null;
    }
    return JSON.parse(atob(token.split('.')[1])) as UserModel;
  }

  logout() {
    localStorage.removeItem('token');
    window.location.reload();
  }
}
