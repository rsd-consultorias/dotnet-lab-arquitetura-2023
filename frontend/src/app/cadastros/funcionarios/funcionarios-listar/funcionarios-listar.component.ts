import { Component, OnInit } from '@angular/core';
import { AlertService } from 'src/app/services/alert.service';
import { FuncionariosService } from 'src/app/services/funcionarios.service';
import { OnboardingService } from 'src/app/services/onboarding.service';

class PaginatedResult {
  collection?: Array<any>;
  totalRecords?: number;
  page?: number;
  totalPages?: number;
  pageSize?: number;
  nextPage?: number;
  previousPage?: number;
}

@Component({
  selector: 'app-funcionarios-listar',
  templateUrl: './funcionarios-listar.component.html',
  styleUrls: ['./funcionarios-listar.component.scss']
})
export class FuncionariosListarComponent implements OnInit {
  funcionarios: Array<any> = [];
  isWaiting: boolean = false;
  idExcluir?: string;
  
  paginas: Array<number> = [];
  previousPage?: number;
  currentPage?: number;
  nextPage?: number;
  totalRecords?: number;
  currentRecords?: number;

  constructor(private onboardingService: OnboardingService,
    private funcionariosService: FuncionariosService,
    private alertService: AlertService) { }

  ngOnInit(): void {
    this.atualizar();
  }

  atualizar(page?: number) {
    this.isWaiting = true;
    this.paginas = [];
    this.nextPage = undefined;
    this.currentPage = undefined;
    this.previousPage = undefined;
    this.totalRecords = undefined;
    this.currentRecords = undefined;

    this.funcionariosService.listarTodos(page)
      .subscribe({
        next: (data: PaginatedResult) => {
          this.funcionarios = data.collection!;
          this.currentPage = data.page!;
          this.previousPage = data.previousPage! === data.page! ? undefined : data.previousPage!;
          this.nextPage = data.nextPage! === data.page! ? undefined : data.nextPage!;
          this.currentRecords = data.collection!.length;
          this.totalRecords = data.totalRecords!;

          for(let i = 0; i < data.totalPages!; i++){
            this.paginas.push(i+1);
          }
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
