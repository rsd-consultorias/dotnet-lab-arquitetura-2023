import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule, NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './home/home.component';
import { MenuLateralComponent } from './shared/menu-lateral/menu-lateral.component';
import { MenuLateralItemComponent } from './shared/menu-lateral-item/menu-lateral-item.component';
import { BreadCrumbComponent } from './shared/bread-crumb/bread-crumb.component';
import { ToastsContainer } from './shared/toasts-container.component';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    BreadCrumbComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MenuLateralComponent,
    MenuLateralItemComponent,
    NgbTooltipModule, 
    ToastsContainer,
    NgbModule
  ],
  providers: [MenuLateralComponent, MenuLateralItemComponent],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
