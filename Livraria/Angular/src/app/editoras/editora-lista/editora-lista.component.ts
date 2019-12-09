import { Component, OnInit } from '@angular/core';
import { Editora } from './../../shared/editora.model';
import { EditoraService } from './../../shared/editora.service';
import { NotificacaoService } from '../../shared/notificacao.service';

@Component({
  selector: 'app-editora-lista',
  templateUrl: './editora-lista.component.html',
  styles: []
})
export class EditoraListaComponent implements OnInit {

  constructor(private editoraService: EditoraService,
    private notificacaoService: NotificacaoService) { }

  ngOnInit() {
    this.editoraService.updateLista();
  }

  popularForm(ed: Editora) {
    this.editoraService.formData = Object.assign({}, ed);
  }

  onDelete(id: number) {
    if (confirm('Deseja remover esse registro?')) {
      this.editoraService.deleteEditora(id)
        .subscribe(res => {
          debugger;
          this.editoraService.updateLista();
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