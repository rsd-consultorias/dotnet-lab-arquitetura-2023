import { Component, OnInit } from '@angular/core';
import { AlertService } from '../services/alert.service';
import { ServicoQualquerService } from '../services/servico-qualquer.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {

  constructor(private servicoQualquer: ServicoQualquerService) { }

  ngOnInit(): void {
  }

  salvar() {
    this.servicoQualquer.executar();
  }

}
