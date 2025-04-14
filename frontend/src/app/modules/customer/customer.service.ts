import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  baseUrl: string = 'http://localhost:5000/';
  // baseUrl: string = 'http://localhost:5165/';

  constructor(private httpClient: HttpClient) {}

  getAll(): Observable<any> {
    return this.httpClient.get(this.baseUrl + 'cliente');
  }

  add(data: any): Observable<any> {
    return this.httpClient.post(this.baseUrl + 'cliente', data);
  }

  update(data: any): Observable<any> {
    return this.httpClient.put(this.baseUrl + 'cliente', data);
  }

  delete(data: any): Observable<any> {
    return this.httpClient.delete(this.baseUrl + 'cliente', data);
  }
}
