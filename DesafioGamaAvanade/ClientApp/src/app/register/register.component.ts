import { Component, Inject } from '@angular/core';
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  isExpanded = false;
  public userName: string;
  public password: string;
  public sexo: string;
  private baseUrl: string;
  private logou: boolean;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.baseUrl = baseUrl;
    this.sexo = 'masc';
  }

  submit(stg) {
    this.http.post<string>(this.baseUrl + 'login', `{username: ${this.userName}, password: ${this.password} }`).subscribe(result => {
      this.logou = true
      this.router.navigateByUrl('/fetch-data');
    }, error => { console.error(error.status); });
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
