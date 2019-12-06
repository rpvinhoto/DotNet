using Livraria.Dominio.Entidades;
using System.Collections.Generic;

namespace Livraria.Dominio.Interfaces.Servicos
{
    public interface ILivroServico : IServicoBase<Livro>
    {
        IEnumerable<Livro> ObterPorTitulo(string titulo);

        IEnumerable<Livro> ObterTodosOrdenadosPorTitulo();
    }
}