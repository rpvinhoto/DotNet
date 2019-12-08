using Livraria.Dominio.Entidades;
using System.Collections.Generic;

namespace Livraria.WebApi.Interfaces.AppServicos
{
    public interface ILivroAppServico : IAppServicoBase<Livro>
    {
        IEnumerable<Livro> ObterPorTitulo(string titulo);
        IEnumerable<Livro> ObterTodosOrdenadosPorTitulo();
        void Validar(Livro livro);
    }
}