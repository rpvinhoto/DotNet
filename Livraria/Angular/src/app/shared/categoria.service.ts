import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Categoria } from './categoria.model';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {
  readonly url = 'http://localhost:62982/api/categoria';
  lista : Categoria[];

  constructor(private http: HttpClient) { }

  obterTodasCategorias(){
    this.http.get(this.url)
    .toPromise()
    .then(res => this.lista = res as Categoria[]);
  }
}
