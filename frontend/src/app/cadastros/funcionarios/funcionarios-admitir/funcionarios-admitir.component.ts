import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AlertService } from 'src/app/services/alert.service';
import { OnboardingService } from 'src/app/services/onboarding.service';

@Component({
  selector: 'app-funcionarios-admitir',
  templateUrl: './funcionarios-admitir.component.html',
  styleUrls: ['./funcionarios-admitir.component.scss']
})
export class FuncionariosAdmitirComponent {

  funcionario: any = {};
  isWaiting = false;
  validateForm: boolean = false;

  constructor(private onboardService: OnboardingService,
    private alertService: AlertService,
    private router: Router) {

  }

  salvar() {
    if (!this.funcionario.nome || !this.funcionario.cpf || !this.funcionario.eMail) {
      this.validate();
      this.alertService.show('Todos os dados devem ser preenchidos', { classname: 'text-bg-warning' });
      return;
    }
    this.isWaiting = true;
    this.onboardService.salvar(this.funcionario)
      .subscribe({
        next: (response) => {
          if (response.success) {
            let data = response.body!;
            if (data?.funcionarioSalvo!) {
              this.alertService.show('Funcionário salvo.', { classname: 'text-bg-success' });
              this.router.navigate(['cadastros/funcionarios']);
            } else {
              let msg = `Máquina pronta: ${data.maquinaPronta ? 'OK' : 'NOK'}. Usuário de Rede: ${data.usuarioRedeCriado ? 'OK' : 'NOK'}. Parâmetro da Folha: ${data.parametroFolhaHabilitado ? 'OK' : 'NOK'}`;
              this.alertService.show(msg, { classname: 'text-bg-warning' });
            }
          } else {
            this.alertService.show(response.errors, { classname: 'text-bg-warning' });
          }
        },
        error: (error) => {
          this.alertService.show(`Ocorreu um erro. \n${error.message}`, { classname: 'text-bg-danger' });
        },
        complete: () => { this.isWaiting = false; }
      });
  }

  validate() {
    this.validateForm = true;
  }
}
