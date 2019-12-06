using Livraria.Dominio.Entidades;
using Livraria.Dominio.Interfaces.Repositorios;
using Livraria.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace Livraria.Dominio.Servicos
{
    public class LivroServico : ServicoBase<Livro>, ILivroServico
    {
        private readonly ILivroRepositorio livroRepositorio;

        public LivroServico(ILivroRepositorio livroRepositorio) : base(livroRepositorio)
        {
            this.livroRepositorio = livroRepositorio;
        }

        public IEnumerable<Livro> ObterPorTitulo(string titulo)
        {
            return livroRepositorio.ObterPorTitulo(titulo);
        }

        public IEnumerable<Livro> ObterTodosOrdenadosPorTitulo()
        {
            return livroRepositorio.ObterTodosOrdenadosPorTitulo();
        }
    }
}