import { Injectable } from '@angular/core';
import { AlertService } from './alert.service';

@Injectable({
  providedIn: 'root'
})
export class ServicoQualquerService {

  constructor(private alertService: AlertService) { }

  executar() {
    this.alertService.show('Pedido enviado. Em breve respondo ;)', {classname: 'bg-white'});
    setTimeout(() => {
      this.alertService.show('Mensagem da outra tela', { classname: 'bg-danger text-light', delay: 10000 });
    }, 10000);
  }
}
