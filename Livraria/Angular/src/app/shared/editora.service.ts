import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Editora } from '../shared/editora.model';


@Injectable({
  providedIn: 'root'
})
export class EditoraService {
  formData: Editora;
  readonly url = 'http://localhost:5000/api/editora';
  lista : Editora[];

  constructor(private http: HttpClient) { }

  postEditora() {
    return this.http.post(this.url, this.formData);
  }

  putEditora() {
    return this.http.put(this.url + '/'+ this.formData.EditoraId, this.formData);
  }

  deleteEditora(id: number) {
    return this.http.delete(this.url + '/'+ id);
  }

  updateLista(){
    this.http.get(this.url)
    .toPromise()
    .then(res => this.lista = res as Editora[]);
  }
}