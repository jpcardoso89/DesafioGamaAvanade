import { Component, Inject, ViewChild } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { AuthenticationService } from "../services/providers/authentication/authentication.service";
import { NgForm } from "@angular/forms";

@Component({
  selector: "app-search-prod",
  templateUrl: "./SearchProdutor.component.html",
  styleUrls: ["./SearchProdutor.component.css"],
})
export class SearchProdutorComponent {
  @ViewChild("searchForm", { static: false }) searchForm: NgForm;
  public artistas: Artistas[];

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private router: Router,
    private authService: AuthenticationService
  ) {
    http.get<Artistas[]>(baseUrl + "api/artista").subscribe(
      (result) => {
        this.artistas = result;
      },
      (error) => console.error(error)
    );
  }

  onSubmit() {
    if (!this.searchForm.valid) {
      return;
    }
  }
}
interface Artistas {
  artistaId: string;
  nome: string;
  idade: number;
  cache: number;
}
