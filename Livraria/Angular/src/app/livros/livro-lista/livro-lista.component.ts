import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { LivroDetalhesService } from '../../shared/livro-detalhes.service';
import { EditoraService } from '../../shared/editora.service';
import { CategoriaService } from '../../shared/categoria.service';
import { LivroDetalhes } from 'src/app/shared/livro-detalhes.model';

@Component({
  selector: 'app-livro-lista',
  templateUrl: './livro-lista.component.html',
  styles: []
})
export class LivroListaComponent implements OnInit {

  constructor(private livroService: LivroDetalhesService,
    private editoraService: EditoraService,
    private categoriaService: CategoriaService) { }

  listaRegistros: MatTableDataSource<any>;
  displayedColumns: string[] = ['titulo', 'editora', 'categoria', 'dataPublicacao', 'acoes'];
  @ViewChild(MatSort, {static: false}) sort: MatSort;
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  searchKey: string;

  ngOnInit() {
    this.livroService.obterTodos().subscribe(
      list => {
        let array = list;
        this.listaRegistros = new MatTableDataSource(array);
        this.listaRegistros.sort = this.sort;
        this.listaRegistros.paginator = this.paginator;
        this.listaRegistros.filterPredicate = (data, filter) => {
          return this.displayedColumns.some(ele => {
            return ele != 'acoes' && data[ele].toLowerCase().indexOf(filter) != -1;
          });
        };
      });
  }

  //ngOnInit() {
  //  this.livroService.obterTodos().subscribe(data => {
  //    console.log("data>>>>>",data);
  //    this.listaRegistros = data.map(a:);
  //  });
  //  this.listaRegistros = new MatTableDataSource(this.livroService.obterTodos().subscribe());
    //this.listaRegistros.sort = this.sort;
    //this.listaRegistros.paginator = this.paginator;
    //this.listaRegistros.filterPredicate = (data, filter) => {
    //  return this.displayedColumns.some(ele => {
    //    return ele != 'acoes' && data[ele].toLowerCase().indexOf(filter) != -1;
    //  });
    //};
  //}

  carregarTodosLivros(){
    this.livroService.obterTodosLivros();
  }

  onSearchClear() {
    this.searchKey = "";
    this.filtrar();
  }

  filtrar() {
    this.listaRegistros.filter = this.searchKey.trim().toLowerCase();
  }

}