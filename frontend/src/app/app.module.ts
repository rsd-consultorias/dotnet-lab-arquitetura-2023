import { APP_INITIALIZER, CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule, NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './home/home.component';
import { MenuLateralComponent } from './shared/menu-lateral/menu-lateral.component';
import { MenuLateralItemComponent } from './shared/menu-lateral-item/menu-lateral-item.component';
import { BreadCrumbComponent } from './shared/bread-crumb/bread-crumb.component';
import { ToastsContainer } from './shared/toasts-container.component';
import { LoginCallbackComponent } from './login-callback/login-callback.component';
import { initializeKeycloak } from './services/keycloak.factory';
import { KeycloakAngularModule, KeycloakService } from 'keycloak-angular';
import { BrowserModule } from '@angular/platform-browser';
import { NgChartsModule } from 'ng2-charts';
import { FuncionariosComponent } from './cadastros/funcionarios/funcionarios.component';
import { FuncionariosAdmitirComponent } from './cadastros/funcionarios/funcionarios-admitir/funcionarios-admitir.component';
import { FuncionariosListarComponent } from './cadastros/funcionarios/funcionarios-listar/funcionarios-listar.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    BreadCrumbComponent,
    LoginCallbackComponent,
    FuncionariosComponent,
    FuncionariosAdmitirComponent,
    FuncionariosListarComponent
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
    NgChartsModule,
    NgbModule,
    NgChartsModule,
    FormsModule
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
