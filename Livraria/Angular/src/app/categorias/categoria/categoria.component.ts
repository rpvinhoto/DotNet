import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CategoriaService } from './../../shared/categoria.service';
import { NotificacaoService } from '../../shared/notificacao.service';

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styles: []
})
export class CategoriaComponent implements OnInit {

  constructor(private categoriaService: CategoriaService,
    private notificacaoService: NotificacaoService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();

    this.categoriaService.formData = {
      CategoriaId: 0,
      Nome: ''
    }
  }

  onSubmit(form: NgForm) {
    if (this.categoriaService.formData.CategoriaId == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.categoriaService.postCategoria().subscribe(
      res => {
        debugger;
        this.resetForm(form);
        this.notificacaoService.sucesso("Registro inserido com sucesso.");
        this.categoriaService.updateLista();
      },
      err => {
        debugger;
        console.log(err);
        this.notificacaoService.falha(err.error);
      }
    )
  }

  updateRecord(form: NgForm) {
    this.categoriaService.putCategoria().subscribe(
      res => {
        this.resetForm(form);
        this.notificacaoService.sucesso("Registro atualizado com sucesso.");
        this.categoriaService.updateLista();
      },
      err => {
        debugger;
        console.log(err);
        this.notificacaoService.falha(err.error);
      }
    )
  }
}