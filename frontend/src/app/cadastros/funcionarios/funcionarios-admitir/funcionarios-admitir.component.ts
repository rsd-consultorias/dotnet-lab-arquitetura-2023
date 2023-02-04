import { Component } from '@angular/core';
import { AlertService } from 'src/app/services/alert.service';
import { OnboardingService } from 'src/app/services/onboarding.service';

@Component({
  selector: 'app-funcionarios-admitir',
  templateUrl: './funcionarios-admitir.component.html',
  styleUrls: ['./funcionarios-admitir.component.scss']
})
export class FuncionariosAdmitirComponent {

  funcionario: any = {};

  constructor(private onboardService: OnboardingService,
    private alertService: AlertService) {

  }

  salvar() {
    this.onboardService.salvar(this.funcionario)
      .subscribe(data => {
        if (data?.funcionarioSalvo!) {
          this.alertService.show('Funcionário salvo.', { classname: 'text-bg-success' });
        } else {
          let msg = `Máquina pronta: ${data.maquinaPronta ? 'OK' : 'NOG'}\n
          Usuário de Rede: ${data.usuarioRede ? 'OK' : 'NOK'}\n
          Parâmetro da Folha: ${data.parametroFolha ? 'OK' : 'NOK'}
          `;
          this.alertService.show(msg, { classname: 'text-bg-danger' });
        }
      });
  }
}
