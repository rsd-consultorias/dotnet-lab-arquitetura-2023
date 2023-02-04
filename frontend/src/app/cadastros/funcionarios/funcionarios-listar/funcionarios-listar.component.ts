import { Component, OnInit } from '@angular/core';
import { OnboardingService } from 'src/app/services/onboarding.service';

@Component({
  selector: 'app-funcionarios-listar',
  templateUrl: './funcionarios-listar.component.html',
  styleUrls: ['./funcionarios-listar.component.scss']
})
export class FuncionariosListarComponent implements OnInit {
  funcionarios: Array<any> = [];

  constructor(private onboardingService: OnboardingService) { }

  ngOnInit(): void {
    this.onboardingService.listarTodos().subscribe(data => this.funcionarios = data);
  }
}
