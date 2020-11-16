import { Routes, RouterModule } from "@angular/router";

import { HomeComponent } from "./home/home.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { SearchProdutorComponent } from "./SearchProdutor/SearchProdutor.component";
import { AuthGuard } from "./helpers/auth.guard";

const routes: Routes = [
  { path: "", component: LoginComponent, pathMatch: "full" },
  {
    path: "fetch-data",
    canActivate: [AuthGuard],
    data: { expectedRole: "ARTISTA" },
    component: FetchDataComponent,
  },
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent },
  { path: "produtor/search", component: SearchProdutorComponent },
];

export const AppRoutingModule = RouterModule.forRoot(routes);
