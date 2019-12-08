using Livraria.Dados.Contexto;
using Livraria.Dominio.Entidades;
using Livraria.Dominio.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Dados.Repositorios
{
    public class LivroRepositorio : RepositorioBase<Livro>, ILivroRepositorio
    {
        public LivroRepositorio(LivrariaContext context) : base(context)
        {
        }

        public bool ExisteComCategoria(long categoriaId)
        {
            return _db.Livros.FirstOrDefault(l => l.CategoriaId == categoriaId) != null;
        }

        public bool ExisteComEditora(long editoraId)
        {
            return _db.Livros.FirstOrDefault(l => l.EditoraId == editoraId) != null;
        }

        public IEnumerable<Livro> ObterPorTitulo(string titulo)
        {
            return _db.Livros.Where(l => l.Titulo.Contains(titulo));
        }

        public IEnumerable<Livro> ObterTodosOrdenadosPorTitulo()
        {
            return _db.Livros.OrderBy(l => l.Titulo);
        }
    }
}