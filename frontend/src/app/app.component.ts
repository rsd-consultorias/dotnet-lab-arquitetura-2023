import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
// import { OAuthService } from 'angular-oauth2-oidc';
import { AlertService } from './services/alert.service';
import { MenuService } from './services/menu.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent implements OnInit {
  title = 'Lab Arquitetura 2023';
  menus?: Array<any> = [];

  constructor(
    private alertService: AlertService,
    private menuService: MenuService,
    private oauthService: OAuthService) {
  }

  ngOnInit() {
    this.oauthService.setupAutomaticSilentRefresh();
    let claims = this.oauthService.getIdentityClaims();
    this.menuService.listarMenu({}).subscribe(data => this.menus = data);
  }

  async handleCredentialResponse(response: any) {
    // Here will be your response from Google.
    // alert(JSON.stringify(response));
    localStorage.setItem('id_token', JSON.stringify(response.credential));
    this.menuService.listarMenu(response).subscribe(data => this.menus = data);
    this.iniciarWatcher();
  }

  iniciarWatcher() {
    setInterval(async () => {
      this.alertService.show("Nenhuma mensagem encontrada.", { classname: 'bg-primary text-white' });
    }, 15000);
  }
}
