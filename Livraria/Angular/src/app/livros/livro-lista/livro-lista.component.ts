import { Component, OnInit } from '@angular/core';
import { Livro } from '../../shared/livro.model';
import { LivroService } from '../../shared/livro.service';
import { EditoraService } from '../../shared/editora.service';
import { NotificacaoService } from '../../shared/notificacao.service';
import { strictEqual } from 'assert';
import { stringify } from 'querystring';

@Component({
  selector: 'app-livro-lista',
  templateUrl: './livro-lista.component.html',
  styles: []
})
export class LivroListaComponent implements OnInit {

  constructor(private livroService: LivroService,
    private editoraService: EditoraService,
    private notificacaoService: NotificacaoService) { }

  ngOnInit() {
    this.livroService.updateLista();
  }

  popularForm(liv: Livro) {
    this.livroService.formData = Object.assign({}, liv);
  }

  obterNomeEditora(id: number): string {
    if (id == null || id == 0)
      return "";

    var nome = "";

    this.editoraService.getEditora(id).subscribe(
      item => nome = item['Nome']);

    return nome;
  }

  onDelete(id: number) {
    if (confirm('Deseja remover esse registro?')) {
      this.livroService.deleteLivro(id)
        .subscribe(res => {
          debugger;
          this.livroService.updateLista();
          this.notificacaoService.sucesso("Registro removido com sucesso.");
        },
          err => {
            debugger;
            console.log(err);
            this.notificacaoService.falha(err.error);
          })
    }
  }
}