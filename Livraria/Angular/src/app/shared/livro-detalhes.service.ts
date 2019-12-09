import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { LivroDetalhes } from '../shared/livro-detalhes.model'

@Injectable({
  providedIn: 'root'
})
export class LivroDetalhesService {
  readonly url = 'http://localhost:5000/api/livro';
  lista: LivroDetalhes[];

  constructor(private http: HttpClient) { }

  form: FormGroup = new FormGroup({
    livroId: new FormControl(0),
    titulo: new FormControl('', [Validators.required, Validators.maxLength(100)]),
    editoraId: new FormControl('', [Validators.required, Validators.min(1)]),
    categoriaId: new FormControl('', [Validators.required, Validators.min(1)]),
    dataPublicacao: new FormControl('')
  });

  iniciarFormGroup() {
    this.form.setValue({
      livroId: 0,
      titulo: '',
      editoraId: 0,
      categoriaId: 0,
      dataPublicacao: ''
    });
  }

  adicionarLivro() {
    return this.http.post(this.url, this.form.value);
  }

  atualizarLivro() {
    return this.http.put(this.url + '/' + this.form.value['livroId'], this.form.value);
  }

  removerLivro(id: number) {
    return this.http.delete(this.url + '/' + id);
  }

  obterTodosLivros(){
    this.http.get(this.url)
    .toPromise()
    .then(res => this.lista = res as LivroDetalhes[]);
  }

  obterTodos() {
    return this.http.get<LivroDetalhes[]>(this.url);
  }
}