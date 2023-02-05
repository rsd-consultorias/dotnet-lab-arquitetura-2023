import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FuncionariosAdmitirComponent } from './cadastros/funcionarios/funcionarios-admitir/funcionarios-admitir.component';
import { FuncionariosListarComponent } from './cadastros/funcionarios/funcionarios-listar/funcionarios-listar.component';
import { FuncionariosComponent } from './cadastros/funcionarios/funcionarios.component';
import { AuthGuardService } from './guards/auth-guard.service';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {path: 'cadastros', canActivate: [AuthGuardService], children: [
    { path: 'funcionarios', component: FuncionariosComponent, canActivate: [AuthGuardService], children: [
      { path: 'admitir', component: FuncionariosAdmitirComponent, canActivate: [AuthGuardService] },
      { path: '**', component: FuncionariosListarComponent, canActivate: [AuthGuardService] }
    ] }
  ]},
  { path: '**', component: HomeComponent, canActivate: [AuthGuardService] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
