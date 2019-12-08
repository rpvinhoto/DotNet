import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig, MatSnackBarRef } from '@angular/material';

@Injectable({
  providedIn: 'root'
})
export class NotificacaoService {

  constructor(public snackBar: MatSnackBar) { }

  config: MatSnackBarConfig = {
    duration: 3000,
    horizontalPosition: "center",
    verticalPosition: "top"
  };

  sucesso(mensagem: string) {
    this.config['panelClass'] = ['notification', 'success'];
    this.snackBar.open(mensagem, '', this.config);
  }

  falha(mensagem: string) {
    this.config['panelClass'] = ['notification', 'fail'];
    this.snackBar.open(mensagem, '', this.config);
  }
}
