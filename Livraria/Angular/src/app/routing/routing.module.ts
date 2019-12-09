import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { LivrosComponent } from '../livros/livros.component';
import { EditorasComponent } from '../editoras/editoras.component';
import { CategoriasComponent } from '../categorias/categorias.component';

const routes: Routes = [
  { path: 'home', component: LivrosComponent },
  { path: 'editoras', component: EditorasComponent },
  { path: 'categorias', component: CategoriasComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class RoutingModule { }