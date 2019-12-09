import { Component, OnInit } from '@angular/core';
import { Categoria } from './../../shared/categoria.model';
import { CategoriaService } from './../../shared/categoria.service';
import { NotificacaoService } from '../../shared/notificacao.service';

@Component({
  selector: 'app-categoria-lista',
  templateUrl: './categoria-lista.component.html',
  styles: []
})
export class CategoriaListaComponent implements OnInit {

  constructor(private categoriaService: CategoriaService,
    private notificacaoService: NotificacaoService) { }

  ngOnInit() {
    this.categoriaService.updateLista();
  }

  popularForm(ed: Categoria) {
    this.categoriaService.formData = Object.assign({}, ed);
  }

  onDelete(id: number) {
    if (confirm('Deseja remover esse registro?')) {
      this.categoriaService.deleteCategoria(id)
        .subscribe(res => {
          debugger;
          this.categoriaService.updateLista();
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