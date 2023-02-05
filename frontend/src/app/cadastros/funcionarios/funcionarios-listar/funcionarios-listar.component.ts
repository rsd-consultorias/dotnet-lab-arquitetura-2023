import { Component, OnInit } from '@angular/core';
import { AlertService } from 'src/app/services/alert.service';
import { OnboardingService } from 'src/app/services/onboarding.service';

@Component({
  selector: 'app-funcionarios-listar',
  templateUrl: './funcionarios-listar.component.html',
  styleUrls: ['./funcionarios-listar.component.scss']
})
export class FuncionariosListarComponent implements OnInit {
  funcionarios: Array<any> = [];

  constructor(private onboardingService: OnboardingService,
    private alertService: AlertService) { }

  ngOnInit(): void {
    this.onboardingService.listarTodos().subscribe(data => this.funcionarios = data);
  }

  atualizar() {
    this.onboardingService.listarTodos().subscribe(data => {
      this.funcionarios = data;
      this.alertService.show('Tabela atualizada.', { classname: 'text-bg-success' })
    });
  }
}
