import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  public baseUrl = "https://localhost:44378";

  constructor(
    private http: HttpClient
  ) { }

  public composeHeaders(token) {
    if (token) {
      const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
      return headers;
    } else {
      return null;
    }
  }

  public teste() {
    return this.http.get(`${this.baseUrl}/v1/leiloes/teste`);

  }

  public GetUser(token) {
    return this.http.get(`${this.baseUrl}/v1/leiloes/user`, { headers: this.composeHeaders(token) });
  }

  public postLeilao(data, token) {
    return this.http.post(`${this.baseUrl}/v1/leiloes`, data, { headers: this.composeHeaders(token) });
  }

  public putLeilao(data, token) {
    return this.http.put(`${this.baseUrl}/v1/leiloes`, data, { headers: this.composeHeaders(token) });
  }

  public deleteLeilao(id, token) {
    return this.http.delete(`${this.baseUrl}/v1/leiloes/` + id, { headers: this.composeHeaders(token) });
  }

  public getAll(token) {
    return this.http.get(`${this.baseUrl}/v1/leiloes/all`, { headers: this.composeHeaders(token) });
  }

  public getAllByUser(token) {
    return this.http.get(`${this.baseUrl}/v1/leiloes`, { headers: this.composeHeaders(token) });
  }

  public getById(id, token) {
    return this.http.get(`${this.baseUrl}/v1/leiloes/` + id, { headers: this.composeHeaders(token) });
  }
}
