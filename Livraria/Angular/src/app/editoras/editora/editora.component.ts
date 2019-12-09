import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EditoraService } from './../../shared/editora.service';
import { NotificacaoService } from '../../shared/notificacao.service';

@Component({
  selector: 'app-editora',
  templateUrl: './editora.component.html',
  styles: []
})
export class EditoraComponent implements OnInit {

  constructor(private editoraService: EditoraService,
    private notificacaoService: NotificacaoService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();

    this.editoraService.formData = {
      EditoraId: 0,
      Nome: ''
    }
  }

  onSubmit(form: NgForm) {
    if (this.editoraService.formData.EditoraId == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.editoraService.postEditora().subscribe(
      res => {
        debugger;
        this.resetForm(form);
        this.notificacaoService.sucesso("Registro inserido com sucesso.");
        this.editoraService.updateLista();
      },
      err => {
        debugger;
        console.log(err);
        this.notificacaoService.falha(err.error);
      }
    )
  }

  updateRecord(form: NgForm) {
    this.editoraService.putEditora().subscribe(
      res => {
        this.resetForm(form);
        this.notificacaoService.sucesso("Registro atualizado com sucesso.");
        this.editoraService.updateLista();
      },
      err => {
        debugger;
        console.log(err);
        this.notificacaoService.falha(err.error);
      }
    )
  }
}