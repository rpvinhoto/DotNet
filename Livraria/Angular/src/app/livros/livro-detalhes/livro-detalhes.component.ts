import { Component, OnInit } from '@angular/core';
import { LivroDetalhesService } from '../../shared/livro-detalhes.service';
import { EditoraService } from '../../shared/editora.service';
import { CategoriaService } from '../../shared/categoria.service';
import { NotificacaoService } from '../../shared/notificacao.service';

@Component({
  selector: 'app-livro-detalhes',
  templateUrl: './livro-detalhes.component.html',
  styles: []
})
export class LivroDetalhesComponent implements OnInit {

  constructor(private livroService: LivroDetalhesService,
    private editoraService: EditoraService,
    private categoriaService: CategoriaService,
    private notificacaoService: NotificacaoService) { }

  ngOnInit() {
    this.carregarTodasEditoras();
    this.carregarTodasCategorias();
  }

  carregarTodasEditoras() {
    this.editoraService.updateLista();
  }

  carregarTodasCategorias() {
    this.categoriaService.updateLista();
  }

  onClear() {
    this.livroService.form.reset();
    this.livroService.iniciarFormGroup();
  }

  onSubmit() {
    if (this.livroService.form.valid) {
      this.inserirRegistro();
    }
  }

   inserirRegistro() {
     this.livroService.adicionarLivro().subscribe(
       res => {
         debugger;
         this.notificacaoService.sucesso("Registro inserido com sucesso.");
         this.onClear();
       },
       err => {
         debugger;
         this.notificacaoService.falha(err.error);
         console.log(err);
       }
     )
   }

  // atualizarRegistro() {
  //   this.livroService.atualizarLivro().subscribe(
  //     res => {
  //       this.onClear();
  //       //this.livroService.atualizarLista();
  //     },
  //     err => {
  //       console.log(err);
  //     }
  //   )
  // }
}
