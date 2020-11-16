import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthenticationService } from '../services/providers/authentication/authentication.service';
import jwt_decode from "jwt-decode";
import { User } from '../services/models/User';


@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(
        private router: Router,
        private authenticationService: AuthenticationService
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const currentUser = this.authenticationService.currentUserValue;

        const expectedRole = route.data.expectedRole;

        const token = currentUser.accessToken;

        var tokenPayload : any = jwt_decode(token);



        if (expectedRole && tokenPayload.role === expectedRole) {
            return true;
        }
        if (currentUser) {
            // logged in so return true
            return true;
        }


        // not logged in so redirect to login page with the return url
        this.router.navigate(['/'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}
