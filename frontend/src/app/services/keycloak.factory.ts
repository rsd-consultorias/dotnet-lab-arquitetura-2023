import { KeycloakService } from "keycloak-angular";

export function initializeKeycloak(
    keycloak: KeycloakService
) {
    return () =>
        keycloak.init({
            config: {
                url: 'http://localhost:8080/',
                realm: 'master',
                clientId: 'lab-arquitetura',
            },
            initOptions: {
                flow: 'implicit',
                scope: 'profile email',
                pkceMethod: 'S256',
                // must match to the configured value in keycloak
                redirectUri: 'http://localhost:4200',
                // this will solved the error 
                checkLoginIframe: false,
            }
        });
}
