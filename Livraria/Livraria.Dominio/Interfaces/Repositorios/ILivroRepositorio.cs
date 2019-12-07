using Livraria.Dominio.Entidades;
using System.Collections.Generic;

namespace Livraria.Dominio.Interfaces.Repositorios
{
    public interface ILivroRepositorio : IRepositorioBase<Livro>
    {
        IEnumerable<Livro> ObterPorTitulo(string titulo);
        IEnumerable<Livro> ObterTodosOrdenadosPorTitulo();
    }
}