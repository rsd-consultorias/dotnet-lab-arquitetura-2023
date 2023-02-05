import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { KeycloakService } from 'keycloak-angular';
import { KeycloakProfile } from 'keycloak-js';
import { AlertService } from './services/alert.service';
import { MenuService } from './services/menu.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Lab Arquitetura 2023';
  menus?: Array<any> = [];
  loggedUser?: any = {};
  notifications?: any = {};

  constructor(
    private alertService: AlertService,
    private menuService: MenuService,
    private modalService: NgbModal,
    protected readonly keycloak: KeycloakService,
    protected readonly router: Router) {
  }

  async ngOnInit() {
    // this.modalService.open(document.getElementById('splashModal')!, { windowClass: 'vh-100' });
    // setTimeout(() => {
    //   this.modalService.dismissAll();
    // }, 1700);

    setInterval(async () => {
      if (!this.keycloak.isLoggedIn()) {
        console.log('login');
        await this.keycloak.login({
          redirectUri: window.location.origin + this.router.routerState.snapshot.url,
        });
      } else {
        console.log('updateToken');
        await this.keycloak.updateToken().catch(err => {
          this.keycloak.login({
            redirectUri: window.location.origin + this.router.routerState.snapshot.url,
          }).then().catch();
        });
      }

    }, 5000);

    this.notifications!.warning = 1;

    let token = await this.keycloak.getToken();
    let userInfo: KeycloakProfile = await this.keycloak.loadUserProfile();
    // @ts-ignore
    this.loggedUser.name = `${userInfo.firstName!} ${userInfo.lastName!} [${userInfo.attributes.chapa!}]`;
    // @ts-ignore
    this.loggedUser.company = userInfo.attributes.empresa;
    // @ts-ignore
    this.loggedUser.businessUnit = userInfo.attributes.area;
    // @ts-ignore
    this.loggedUser.costCenter = userInfo.attributes.centro_custos;
    this.menuService.listarMenu(token).subscribe(data => this.menus = data);

  }
}
