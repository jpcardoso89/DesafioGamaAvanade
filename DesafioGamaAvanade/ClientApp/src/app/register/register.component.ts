import { Component, Inject } from '@angular/core';
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  isExpanded = false;
  public userName: string;
  public password: string;
  public confirmPassword: string;
  public Role: string;
  public ArtisaForm: FormGroup;
  public Idade: Number;
  public Sexo: string;
  public Cache: Number;
  public Generos: string[];
  public ProdutorForm: FormGroup;
  public Nome: string;
  public generosOptions;
  private baseUrl: string;
  private logou: boolean;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.baseUrl = baseUrl;
    this.Sexo = 'masc';
    this.userName = 'joabe';
    this.password = '123456';
    this.confirmPassword = '123456';
    this.Role = 'ARTISTA';
    this.Nome = 'joabe';
    this.Idade = 25;
    this.Cache = 500;
    this.Generos = [];

  }

  submit(stg) {
    var requestBody = {};
    if (this.Role === "ARTISTA") {
      requestBody = {
        Login: this.userName,
        Password: this.password,
        Role: this.Role,
        Name: this.Nome,
        Idade: this.Idade,
        Cache: this.Cache,
        Generos: this.Generos
      }
    } else {

    }
    this.http.post<string>(this.baseUrl + 'api/User', JSON.stringify(requestBody), { headers: { 'Content-Type': 'application/json' } }).subscribe(result => {
      console.log(result);
    }, error => { console.error(error.status); });
  }

  ngOnInit(): void {
    this.http.get<string>(this.baseUrl + 'api/Genero').subscribe(result => {
      this.generosOptions = result;
    }, error => { console.error(error.status); });
  }

  onGeneroChange(generoId: string, isChecked: boolean) {
    if (isChecked) {
      this.Generos.push(generoId);
    } else {
      const index = this.Generos.findIndex(nome => nome === generoId);
      this.Generos.splice(index, 1);
    }
  }

  teste(value) {
    console.log(value);
  }

}
