import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { KeycloakService } from 'keycloak-angular';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class QueueService {

    constructor(private httpClient: HttpClient) {

    }

    listarTodos(): Observable<Array<any>> {
        return this.httpClient.get<Array<any>>('https://localhost:7090/api/v1/queue');
    }

    buscarPorId(id: number): Observable<any> {
        return this.httpClient.get<any>(`https://localhost:7090/api/v1/queue/${id}`);
    }

    marcarComoLida(id: number) {
        return this.httpClient.post<void>(`https://localhost:7090/api/v1/queue/${id}`, {});
    }
}
