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
    const _isLoggedIn = this.keycloak.isLoggedIn();
    if (!_isLoggedIn) {
      await this.keycloak.login({
        // redirectUri: window.location.origin + this.router.routerState.snapshot.url,
      });
    } else {
      await this.keycloak.updateToken()
        .then(refreshed => {
        })
        .catch(err => {
          this.keycloak.login({
            // redirectUri: window.location.origin + this.router.routerState.snapshot.url,
          })
            .then(response => console.warn(JSON.stringify(response)))
            .catch(reason => console.error(reason));
        });
    }
    
    if (this.authenticated) {
      await this.keycloak.loadUserProfile(true);
      if (!this.keycloak.isUserInRole(route.data['role'])) {
        this.router.navigate(['http-401']);
      }
    }

    return this.authenticated;
  }
}
