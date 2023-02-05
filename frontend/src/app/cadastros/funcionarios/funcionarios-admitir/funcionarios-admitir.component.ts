import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from 'src/app/services/alert.service';
import { OnboardingService } from 'src/app/services/onboarding.service';
import { QueueService } from 'src/app/services/queue.service';

@Component({
  selector: 'app-funcionarios-admitir',
  templateUrl: './funcionarios-admitir.component.html',
  styleUrls: ['./funcionarios-admitir.component.scss']
})
export class FuncionariosAdmitirComponent implements OnInit {

  funcionario: any = {};
  isWaiting = false;
  validateForm: boolean = false;

  constructor(private onboardService: OnboardingService,
    private alertService: AlertService,
    private queueService: QueueService,
    private router: Router,
    private activateRouter: ActivatedRoute) {

  }

  ngOnInit(): void {
    if (this.router.url.endsWith('/retry')) {
      const id: number = Number(this.activateRouter.snapshot.paramMap.get('id'));
      if (id) {
        this.queueService.buscarPorId(id).subscribe({
          next: (result) => {
            const bodyResult = JSON.parse(result.body);

            this.funcionario = {};
            this.funcionario.nome = bodyResult.Nome;
            this.funcionario.cpf = bodyResult.CPF;
            this.funcionario.eMail = bodyResult.EMail;
          },
          complete: () => this.queueService.marcarComoLida(id).subscribe()
        });
      }
    }
  }

  salvar() {
    if (!this.funcionario.nome || !this.funcionario.cpf || !this.funcionario.eMail) {
      this.validate();
      this.alertService.show('Todos os dados devem ser preenchidos', { classname: 'text-bg-warning' });
      return;
    }
    this.isWaiting = true;
    this.funcionario.referrer = '/cadastros/funcionarios/admitir';
    this.onboardService.salvar(this.funcionario)
      .subscribe({
        next: (response) => {
          if (response.status === 'SUCCESS') {
            let data = response.body!;
            if (data?.funcionarioSalvo!) {
              this.alertService.show('Funcionário salvo.', { classname: 'text-bg-success' });
              this.router.navigate(['cadastros/funcionarios']);
            } else {
              let msg = `Máquina pronta: ${data.maquinaPronta ? 'OK' : 'NOK'}. Usuário de Rede: ${data.usuarioRedeCriado ? 'OK' : 'NOK'}. Parâmetro da Folha: ${data.parametroFolhaHabilitado ? 'OK' : 'NOK'}`;
              this.alertService.show(msg, { classname: 'text-bg-warning' });
            }
          } else if (response.status === 'QUEUED') {
            this.alertService.show('Processamento longo. Operação enfileirada.', { classname: 'text-bg-warning' });
            this.router.navigate(['cadastros/funcionarios']);
          }
          else {
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
