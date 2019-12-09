import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LivroService } from '../../shared/livro.service';
import { EditoraService } from '../../shared/editora.service';
import { CategoriaService } from '../../shared/categoria.service';
import { NotificacaoService } from '../../shared/notificacao.service';

@Component({
  selector: 'app-livro',
  templateUrl: './livro.component.html',
  styles: []
})
export class LivroComponent implements OnInit {

  constructor(private livroService: LivroService,
    private editoraService: EditoraService,
    private categoriaService: CategoriaService,
    private notificacaoService: NotificacaoService) { }

  ngOnInit() {
    this.resetForm();
    this.carregarEditoras();
    this.carregarCategorias();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();

    this.livroService.formData = {
      LivroId: 0,
      Titulo: '',
      EditoraId: null,
      CategoriaId: null,
      DataPublicacao: null
    }
  }

  carregarEditoras() {
    this.editoraService.updateLista();
  }

  carregarCategorias() {
    this.categoriaService.updateLista();
  }

  onSubmit(form: NgForm) {
    if (this.livroService.formData.LivroId == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.livroService.postLivro().subscribe(
      res => {
        debugger;
        this.resetForm(form);
        this.notificacaoService.sucesso("Registro inserido com sucesso.");
        this.livroService.updateLista();
      },
      err => {
        debugger;
        console.log(err);
        this.notificacaoService.falha(err.error);
      }
    )
  }

  updateRecord(form: NgForm) {
    this.livroService.putLivro().subscribe(
      res => {
        this.resetForm(form);
        this.notificacaoService.sucesso("Registro atualizado com sucesso.");
        this.livroService.updateLista();
      },
      err => {
        debugger;
        console.log(err);
        this.notificacaoService.falha(err.error);
      }
    )
  }
}