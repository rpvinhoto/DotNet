import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Editora } from '../shared/editora.model';

@Injectable({
  providedIn: 'root'
})
export class EditoraService {
  readonly url = 'http://localhost:62982/api/editora';
  lista : Editora[];

  constructor(private http: HttpClient) { }

  obterTodasEditoras(){
    this.http.get(this.url)
    .toPromise()
    .then(res => this.lista = res as Editora[]);
  }
}
