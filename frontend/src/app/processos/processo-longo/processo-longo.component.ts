import { Component, OnDestroy, OnInit } from '@angular/core';
import { FuncionariosService } from 'src/app/services/funcionarios.service';

@Component({
  selector: 'app-processo-longo',
  templateUrl: './processo-longo.component.html',
  styleUrls: ['./processo-longo.component.scss']
})
export class ProcessoLongoComponent implements OnInit, OnDestroy {

  statusFolha?: string = undefined;
  intervalFolha?: any = undefined;
  progress: number = 0;

  constructor(private funcionarioService: FuncionariosService) { }

  ngOnDestroy(): void {
    clearInterval(this.intervalFolha!);
  }

  ngOnInit(): void {
    this.intervalFolha = setInterval(() => {
      this.funcionarioService.statusFolha().subscribe({
        next: (response) => {
          if(response.body){
          this.statusFolha = response!.body.status;
          this.progress = Number(response!.body.progress);
          } else {
            this.statusFolha = response.errors[0];
          }
        }
      });
    }, 1000);
  }
}
