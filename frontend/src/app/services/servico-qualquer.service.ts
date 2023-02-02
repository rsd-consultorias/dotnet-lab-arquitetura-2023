import { Injectable } from '@angular/core';
import { AlertService } from './alert.service';

@Injectable({
  providedIn: 'root'
})
export class ServicoQualquerService {

  constructor(private alertService: AlertService) { }

  executar() {
    this.alertService.show('Pedido enviado. Em breve respondo ;)');
    setTimeout(() => {
      this.alertService.show('Mensagem da outra tela', { classname: 'bg-success text-light', delay: 10000 });
    }, 10000);
  }
}
