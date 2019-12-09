import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Categoria } from '../shared/categoria.model';


@Injectable({
  providedIn: 'root'
})
export class CategoriaService {
  formData: Categoria;
  readonly url = 'http://localhost:5000/api/categoria';
  lista : Categoria[];

  constructor(private http: HttpClient) { }

  postCategoria() {
    return this.http.post(this.url, this.formData);
  }

  putCategoria() {
    return this.http.put(this.url + '/'+ this.formData.CategoriaId, this.formData);
  }

  deleteCategoria(id: number) {
    return this.http.delete(this.url + '/'+ id);
  }

  updateLista(){
    this.http.get(this.url)
    .toPromise()
    .then(res => this.lista = res as Categoria[]);
  }
}