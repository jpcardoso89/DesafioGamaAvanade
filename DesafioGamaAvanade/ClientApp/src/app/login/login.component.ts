import { Component, Inject, ViewChild } from '@angular/core';
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { AuthenticationService } from '../services/providers/authentication/authentication.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  @ViewChild('loginForm', { static: false }) loginForm: NgForm;
  isExpanded = false;
  public userName: string;
  public password: string;

  constructor(private http: HttpClient,
              @Inject('BASE_URL') baseUrl: string,
              private router: Router,
              private authService: AuthenticationService ) {
  }

  submit() {
    if (!this.loginForm.valid) {
      return;
    }

    this.authService
      .login(this.userName, this.password)
      .subscribe((user) => {
        this.router.navigateByUrl('/fetch-data');
      }, (error) => {
        alert("Não foi possivel fazer o login, tente novamente!")
      });
  }
}
