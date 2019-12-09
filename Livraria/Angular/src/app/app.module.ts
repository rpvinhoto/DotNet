import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MaterialModule } from './material/material.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
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
import { EditorasComponent } from './editoras/editoras.component';
import { EditoraComponent } from './editoras/editora/editora.component';
import { EditoraListaComponent } from './editoras/editora-lista/editora-lista.component';
import { CategoriasComponent } from './categorias/categorias.component';
import { CategoriaComponent } from './categorias/categoria/categoria.component';
import { CategoriaListaComponent } from './categorias/categoria-lista/categoria-lista.component';
import { RoutingModule } from './routing/routing.module';
import { HeaderComponent } from './navigation/header/header.component';
import { SidenavListComponent } from './navigation/sidenav-list/sidenav-list.component'

@NgModule({
  declarations: [
    AppComponent,
    LivrosComponent,
    LivroDetalhesComponent,
    LivroListaComponent,
    EditorasComponent,
    EditoraComponent,
    EditoraListaComponent,
    CategoriasComponent,
    CategoriaComponent,
    CategoriaListaComponent,
    HeaderComponent,
    SidenavListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    RoutingModule
  ],
  providers: [LivroDetalhesService, EditoraService, CategoriaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
