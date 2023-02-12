import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { KeycloakService } from 'keycloak-angular';
import { KeycloakProfile } from 'keycloak-js';
import { AlertService } from './services/alert.service';
import { MenuService } from './services/menu.service';
import { QueueService } from './services/queue.service';

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

  loggedUserStr?: string;
  aux?: string;

  constructor(
    private alertService: AlertService,
    private menuService: MenuService,
    private queueService: QueueService,
    private modalService: NgbModal,
    protected readonly keycloak: KeycloakService,
    protected readonly router: Router) {
  }

  queueList: Array<any> = [];
  closeResult = '';

  async ngOnInit() {
    // this.modalService.open(document.getElementById('splashModal')!, { windowClass: 'vh-100' });
    // setTimeout(() => {
    //   this.modalService.dismissAll();
    // }, 1700);

    setInterval(async () => {
      const _isLoggedIn = await this.keycloak.isLoggedIn();
      if (!this.keycloak.isLoggedIn()) {
        await this.keycloak.login({
          // redirectUri: window.location.origin + this.router.routerState.snapshot.url,
        });
      } else {
        await this.keycloak.updateToken().catch(err => {
          this.keycloak.login({
            // redirectUri: window.location.origin + this.router.routerState.snapshot.url,
          }).then().catch();
        });
      }

      if (_isLoggedIn) this.loadQueue();
    }, 5000);

    this.notifications!.warning = 1;

    const token = await this.keycloak.getToken();
    const userInfo: KeycloakProfile = await this.keycloak.loadUserProfile(true);
    // @ts-ignore
    this.aux = JSON.stringify(this.keycloak.isUserInRole('lab-arquitetura-admin-role'));
    this.loggedUserStr = JSON.stringify(userInfo, null, 4);
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

  async logoff() {
    await this.keycloak.logout('http://localhost:8080/realms/master/account/');
  }

  openModalQueue(content: any) {
    this.loadQueue();

    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then(
      (result) => {
        this.closeResult = `Closed with: ${result}`;
      },
      (reason) => {
        // this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      },
    );
  }

  loadQueue() {
    this.queueService.listarTodos().subscribe({
      next: (result) => {
        this.queueList = result;
      }
    });
  }

  marcarComoLida(id: number) {
    this.queueService.marcarComoLida(id).subscribe(
      { complete: () => this.loadQueue() }
    );
  }
}
