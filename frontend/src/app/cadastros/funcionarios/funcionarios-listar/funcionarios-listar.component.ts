import { Component, OnInit } from '@angular/core';
import { AlertService } from 'src/app/services/alert.service';
import { FuncionariosService } from 'src/app/services/funcionarios.service';
import { OnboardingService } from 'src/app/services/onboarding.service';

@Component({
  selector: 'app-funcionarios-listar',
  templateUrl: './funcionarios-listar.component.html',
  styleUrls: ['./funcionarios-listar.component.scss']
})
export class FuncionariosListarComponent implements OnInit {
  funcionarios: Array<any> = [];
  isWaiting: boolean = false;
  idExcluir?: string;

  constructor(private onboardingService: OnboardingService,
    private funcionariosService: FuncionariosService,
    private alertService: AlertService) { }

  ngOnInit(): void {
    this.funcionariosService.listarTodos()
      .subscribe({
        next: (data) => this.funcionarios = data
      });
  }

  atualizar() {
    this.isWaiting = true;
    this.funcionariosService.listarTodos()
      .subscribe({
        next: (data) => {
          this.funcionarios = data;
          this.alertService.show('Tabela atualizada.', { classname: 'text-bg-success' });
        },
        complete: () => this.isWaiting = false
      });
  }

  habilitarExclusao(id: string) {
    if (this.idExcluir) {
      this.idExcluir = undefined;
    } else {
      this.idExcluir = id;
    }
  }

  excluir(id: string) {
    this.isWaiting = true;
    // @ts-ignore
    this.funcionariosService.excluir(id)
      .subscribe({
        next: (data) => {
          this.atualizar();
        },
        error: (reason) => { this.alertService.show(reason, { classname: 'txt-bg-danger' }) },
        complete: () => {
          this.isWaiting = false;
          this.idExcluir = undefined;
        }
      });
  }
}
