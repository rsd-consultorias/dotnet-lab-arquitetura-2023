import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { KeycloakAuthGuard, KeycloakService } from 'keycloak-angular';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService extends KeycloakAuthGuard {

  constructor(protected override readonly router: Router,
    protected readonly keycloak: KeycloakService) {
    super(router, keycloak);
  }

  async isAccessAllowed(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Promise<boolean | UrlTree> {

    if (!this.keycloak.isLoggedIn()) {
      await this.keycloak.login({
        redirectUri: window.location.origin + this.router.routerState.snapshot.url,
      });
    } else {
      await this.keycloak.updateToken().catch(err => {
        this.keycloak.login({
          redirectUri: window.location.origin + this.router.routerState.snapshot.url,
        }).then().catch();
      });
    }
    return this.authenticated;
  }
}
