using Livraria.Dominio.Entidades;
using Livraria.Dominio.Interfaces.Servicos;
using Livraria.WebApi.Interfaces.AppServicos;
using System.Collections.Generic;

namespace Livraria.WebApi.AppServicos
{
    public class LivroAppServico : AppServicoBase<Livro>, ILivroAppServico
    {
        private readonly ILivroServico _livroServico;

        public LivroAppServico(ILivroServico livroServico) : base(livroServico)
        {
            _livroServico = livroServico;
        }

        public IEnumerable<Livro> ObterPorTitulo(string titulo)
        {
            return _livroServico.ObterPorTitulo(titulo);
        }

        public IEnumerable<Livro> ObterTodosOrdenadosPorTitulo()
        {
            return _livroServico.ObterTodosOrdenadosPorTitulo();
        }
    }
}