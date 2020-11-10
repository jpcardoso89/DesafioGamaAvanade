import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  isExpanded = false;
  public userName: string;
  public password: string;
  private baseUrl: string;
  private http: HttpClient;
  private logou: boolean;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  submit(stg) {
    console.log(this.userName);
    this.http.post<string>(this.baseUrl + 'login', `{username: ${this.userName}, password: ${this.password} }`).subscribe(result => {
      this.logou = true
    }, error => console.error(error));
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
