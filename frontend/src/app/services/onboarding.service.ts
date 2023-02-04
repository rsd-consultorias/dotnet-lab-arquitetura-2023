import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OnboardingService {

  constructor(private httpClient: HttpClient) { }

  listarTodos(): Observable<Array<any>> {
    return this.httpClient.get<Array<any>>('https://localhost:7090/api/v1/onboard/todos', {
      headers: new HttpHeaders({
        'Authorization': `${localStorage.getItem('id_token')}`
      })
    });
  }

  salvar(funcionario: any): Observable<any> {
    return this.httpClient.post<any>('https://localhost:7090/api/v1/onboard',
      funcionario, {
      headers: new HttpHeaders({
        'Authorization': `${localStorage.getItem('id_token')}`
      })
    });
  }
}
