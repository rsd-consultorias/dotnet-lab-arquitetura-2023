import { APP_INITIALIZER, CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule, NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './home/home.component';
import { MenuLateralComponent } from './shared/menu-lateral/menu-lateral.component';
import { MenuLateralItemComponent } from './shared/menu-lateral-item/menu-lateral-item.component';
import { BreadCrumbComponent } from './shared/bread-crumb/bread-crumb.component';
import { ToastsContainer } from './shared/toasts-container.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginCallbackComponent } from './login-callback/login-callback.component';
import { initializeKeycloak } from './services/keycloak.factory';
import { KeycloakAngularModule, KeycloakService } from 'keycloak-angular';
import { BrowserModule } from '@angular/platform-browser';
import { CadastrosComponent } from './cadastros/cadastros.component';
import { ProcessosComponent } from './processos/processos.component';
import { RelatoriosComponent } from './relatorios/relatorios.component';
import { ConfiguracoesComponent } from './configuracoes/configuracoes.component';
import { IntegracoesComponent } from './integracoes/integracoes.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    BreadCrumbComponent,
    DashboardComponent,
    LoginCallbackComponent,
    CadastrosComponent,
    ProcessosComponent,
    RelatoriosComponent,
    ConfiguracoesComponent,
    IntegracoesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MenuLateralComponent,
    MenuLateralItemComponent,
    NgbTooltipModule,
    ToastsContainer,
    HttpClientModule,
    KeycloakAngularModule,
    NgbModule
  ],
  providers: [MenuLateralComponent, MenuLateralItemComponent, {
    provide: APP_INITIALIZER,
    useFactory: initializeKeycloak,
    multi: true,
    deps: [KeycloakService]
  }],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
