import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  constructor(private httpClient: HttpClient) { }

  listarMenu(token: any): Observable<any> {
    return this.httpClient.get('https://localhost:7090/api/v1/Menu', {
      headers: new HttpHeaders({
        'Authorization': `${localStorage.getItem('id_token')}`
      })
    });
    // return this.httpClient.get('https://localhost:7090/api/v1/Menu', { headers: header });
  }
}
