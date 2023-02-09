import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from 'src/app/services/alert.service';
import { FuncionariosService } from 'src/app/services/funcionarios.service';

@Component({
  selector: 'app-funcionario-editar',
  templateUrl: './funcionario-editar.component.html',
  styleUrls: ['./funcionario-editar.component.scss']
})
export class FuncionarioEditarComponent implements OnInit {
  funcionario: any = {}
  isWaiting = false;
  validateForm: boolean = false;

  constructor(private funcionariosServices: FuncionariosService,
    private alertService: AlertService,
    private activateRouter: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.funcionariosServices
      .buscarPorId(this.activateRouter.snapshot.paramMap.get('id')!)
      .subscribe({
        next: (response) => this.funcionario = response.body
      });
  }

  salvar() {
    if (!this.funcionario.nome || !this.funcionario.cpf || !this.funcionario.eMail) {
      this.validate();
      this.alertService.show('Todos os dados devem ser preenchidos', { classname: 'text-bg-warning' });
      return;
    }
    this.isWaiting = true;

    this.funcionariosServices.alterar(this.funcionario)
      .subscribe({
        next: (response) => {
          if (response.status === 'Success') {
            this.alertService.show('Funcionário atualizado', { classname: 'text-bg-success' });
          } else {
            this.alertService.show(JSON.stringify(response.errors), { classname: 'text-bg-danger' });
          }
          this.isWaiting = false;
        }
      });
  }

  validate() {
    this.validateForm = true;
  }

}
