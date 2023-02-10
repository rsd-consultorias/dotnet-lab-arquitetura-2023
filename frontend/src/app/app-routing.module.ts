import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FuncionarioEditarComponent } from './cadastros/funcionarios/funcionario-editar/funcionario-editar.component';
import { FuncionariosAdmitirComponent } from './cadastros/funcionarios/funcionarios-admitir/funcionarios-admitir.component';
import { FuncionariosListarComponent } from './cadastros/funcionarios/funcionarios-listar/funcionarios-listar.component';
import { FuncionariosComponent } from './cadastros/funcionarios/funcionarios.component';
import { Http401Component } from './errors/http401/http401.component';
import { Http404Component } from './errors/http404/http404.component';
import { AuthGuardService } from './guards/auth-guard.service';
import { HomeComponent } from './home/home.component';
import { LogoffComponent } from './logoff/logoff.component';
import { ProcessoLongoComponent } from './processos/processo-longo/processo-longo.component';

const routes: Routes = [
  {
    path: 'cadastros', data: { role: 'lab-arquitetura-user' }, canActivate: [AuthGuardService], children: [
      {
        path: 'funcionarios', data: { role: 'lab-arquitetura-user' }, component: FuncionariosComponent, canActivate: [AuthGuardService], children: [
          { path: 'admitir/:id/retry', data: { role: 'lab-arquitetura-admin' }, component: FuncionariosAdmitirComponent, canActivate: [AuthGuardService] },
          { path: 'admitir', data: { role: 'lab-arquitetura-admin' }, component: FuncionariosAdmitirComponent, canActivate: [AuthGuardService] },
          { path: 'editar/:id', data: { role: 'lab-arquitetura-admin' }, component: FuncionarioEditarComponent, canActivate: [AuthGuardService] },
          { path: '**', data: { role: 'lab-arquitetura-user' }, component: FuncionariosListarComponent, canActivate: [AuthGuardService] }
        ]
      }
    ]
  },
  {
    path: 'processos', data: { role: 'lab-arquitetura-user' }, canActivate: [AuthGuardService], children: [
      { path: 'processo-longo', data: { role: 'lab-arquitetura-user' }, canActivate: [AuthGuardService], component: ProcessoLongoComponent }
    ]
  },
  { path: 'logoff', data: { role: 'lab-arquitetura-user' }, component: LogoffComponent },
  { path: 'http-401', component: Http401Component },
  { path: 'http-404', component: Http404Component },
  { path: '**', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
