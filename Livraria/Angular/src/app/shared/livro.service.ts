import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Livro } from './livro.model';


@Injectable({
  providedIn: 'root'
})
export class LivroService {
  formData: Livro;
  readonly url = 'http://localhost:5000/api/livro';
  lista : Livro[];

  constructor(private http: HttpClient) { }

  postLivro() {
    return this.http.post(this.url, this.formData);
  }

  putLivro() {
    return this.http.put(this.url + '/'+ this.formData.LivroId, this.formData);
  }

  deleteLivro(id: number) {
    return this.http.delete(this.url + '/'+ id);
  }

  updateLista(){
    this.http.get(this.url)
    .toPromise()
    .then(res => this.lista = res as Livro[]);
  }
}