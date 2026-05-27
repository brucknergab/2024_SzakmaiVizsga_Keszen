import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Model } from "../models/model";

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private apiUrl = 'http://localhost:5023/api/Entity';

  constructor(private http: HttpClient) { }

  getById(id: number): Observable<Model> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  getAll(): Observable<Model[]> {
    return this.http.get<any>(`${this.apiUrl}`);
  }

  getAllByGyarto(gyarto: string): Observable<Model[]> {
    return this.http.get<any>(`${this.apiUrl}/gyarto/${gyarto}`);
  }

}