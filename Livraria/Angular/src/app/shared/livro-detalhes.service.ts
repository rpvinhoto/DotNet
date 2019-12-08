import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { LivroDetalhes } from '../shared/livro-detalhes.model'

@Injectable({
  providedIn: 'root'
})
export class LivroDetalhesService {
  readonly url = 'http://localhost:62982/api/livro';
  lista: LivroDetalhes[];

  constructor(private http: HttpClient) { }

  form: FormGroup = new FormGroup({
    LivroId: new FormControl(0),
    Titulo: new FormControl('', [Validators.required, Validators.maxLength(100)]),
    EditoraId: new FormControl('', [Validators.required, Validators.min(1)]),
    CategoriaId: new FormControl('', [Validators.required, Validators.min(1)]),
    DataPublicacao: new FormControl('')
  });

  iniciarFormGroup() {
    this.form.setValue({
      LivroId: 0,
      Titulo: '',
      EditoraId: 0,
      CategoriaId: 0,
      DataPublicacao: ''
    });
  }

  adicionarLivro() {
    return this.http.post(this.url, this.form.value);
  }

  atualizarLivro() {
    return this.http.put(this.url + this.form.value['$id'], this.form.value);
  }

  removerLivro(id: number) {
    return this.http.delete(this.url + id);
  }

  atualizarLista(){
    this.http.get(this.url)
    .toPromise()
    .then(res => this.lista = res as LivroDetalhes[]);
  }
}