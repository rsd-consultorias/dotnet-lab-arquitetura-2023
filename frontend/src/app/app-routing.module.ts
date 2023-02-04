import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrosComponent } from './cadastros/cadastros.component';
import { ConfiguracoesComponent } from './configuracoes/configuracoes.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuardService } from './guards/auth-guard.service';
import { HomeComponent } from './home/home.component';
import { IntegracoesComponent } from './integracoes/integracoes.component';
import { LoginCallbackComponent } from './login-callback/login-callback.component';
import { ProcessosComponent } from './processos/processos.component';
import { RelatoriosComponent } from './relatorios/relatorios.component';

const routes: Routes = [
  { path: 'dashboard/:id', component: DashboardComponent, canActivate: [AuthGuardService] },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuardService] },
  { path: 'callback-login/:state', component: LoginCallbackComponent, canActivate: [AuthGuardService] },
  { path: 'callback-login', component: LoginCallbackComponent, canActivate: [AuthGuardService] },
  
  {path: 'cadastros', component: CadastrosComponent, canActivate: [AuthGuardService]},
  {path: 'processos', component: ProcessosComponent, canActivate: [AuthGuardService]},
  {path: 'relatorios', component: RelatoriosComponent, canActivate: [AuthGuardService]},
  {path: 'integracoes', component: IntegracoesComponent, canActivate: [AuthGuardService]},
  {path: 'configuracoes', component: ConfiguracoesComponent, canActivate: [AuthGuardService]},
  
  { path: '**', component: HomeComponent, canActivate: [AuthGuardService] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
