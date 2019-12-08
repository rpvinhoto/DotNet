import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MaterialModule } from './material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LivrosComponent } from './livros/livros.component';
import { LivroDetalhesComponent } from './livros/livro-detalhes/livro-detalhes.component';
import { LivroListaComponent } from './livros/livro-lista/livro-lista.component';
import { LivroDetalhesService } from './shared/livro-detalhes.service';
import { EditoraService } from './shared/editora.service';
import { CategoriaService } from './shared/categoria.service';


@NgModule({
  declarations: [
    AppComponent,
    LivrosComponent,
    LivroDetalhesComponent,
    LivroListaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    HttpClientModule
  ],
  providers: [LivroDetalhesService, EditoraService, CategoriaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
