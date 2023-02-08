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
        return this.httpClient.get<Array<any>>('https://localhost:7090/api/v1/queue');
    }

    buscarPorId(id: string): Observable<any> {
        return this.httpClient.get<any>(`https://localhost:7090/api/v1/funcionarios/${id}`);
    }

    marcarComoLida(id: number) {
        return this.httpClient.post<void>(`https://localhost:7090/api/v1/queue/${id}`, {});
    }
}
