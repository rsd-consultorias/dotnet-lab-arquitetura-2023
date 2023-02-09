import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class FuncionariosService {

    constructor(private httpClient: HttpClient) {

    }

    listarTodos(): Observable<Array<any>> {
        return this.httpClient.get<Array<any>>('https://localhost:7090/api/v1/funcionarios');
    }

    buscarPorId(id: string): Observable<any> {
        return this.httpClient.get<any>(`https://localhost:7090/api/v1/funcionarios/${id}`);
    }

    alterar(funcionario: any): Observable<any> {
        return this.httpClient.post(`https://localhost:7090/api/v1/funcionarios`, funcionario)
    }

    excluir(id: string): Observable<any>{
        return this.httpClient.delete(`https://localhost:7090/api/v1/funcionarios/${id}`);
    }
}
