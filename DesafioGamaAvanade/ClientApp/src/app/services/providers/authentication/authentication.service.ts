import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';


import { ProviderService } from '../provider.service';
import jwt_decode from "jwt-decode";

import { map } from 'rxjs/operators'
import { Auth } from '../../models/auth';
import { UserLogged } from '../../models/userLogged';
import { UserLogin } from '../../models/userLogin';

@Injectable({
  providedIn: 'root'
})

export class AuthenticationService extends ProviderService{
private http: HttpClient;
private currentUserSubject: BehaviorSubject<Auth>;
public currentUser: Observable<Auth>;
  
  constructor(_http: HttpClient, @Inject('BASE_URL') baseUrl: string) 
  { 
    super("api/login", baseUrl);
    this.http = _http;
    this.currentUserSubject = new BehaviorSubject<Auth>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser= this.currentUserSubject.asObservable();
  }

  public get currentUserValue() : Auth {
    return this.currentUserSubject.value;
  }

  public get userInformations() {
    try {
      return jwt_decode(this.currentUserValue.accessToken);
    } catch(Error)
    {
      return null;
    }
  }

  login(username: string, password: string)
  {
    return this.http.post<any>(`${this.url}`, { Login: username, Password: password } ,{})
            .pipe(map(user => {
              localStorage.setItem('currentUser', JSON.stringify(user));
              this.currentUserSubject.next(user);
              return user;
            }))
  }

  logout() {
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}

