using Livraria.Dominio.Entidades;
using Livraria.Dominio.Exceptions;
using Livraria.Dominio.Interfaces.Repositorios;
using Livraria.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace Livraria.Dominio.Servicos
{
    public class LivroServico : ServicoBase<Livro>, ILivroServico
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroServico(ILivroRepositorio livroRepositorio) : base(livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public IEnumerable<Livro> ObterPorTitulo(string titulo)
        {
            return _livroRepositorio.ObterPorTitulo(titulo);
        }

        public IEnumerable<Livro> ObterTodosOrdenadosPorTitulo()
        {
            return _livroRepositorio.ObterTodosOrdenadosPorTitulo();
        }

        public void Validar(Livro livro)
        {
            if (string.IsNullOrEmpty(livro.Titulo))
                throw new DomainException("Campo título é obrigatório.");

            if (livro.Titulo.Length > 100)
                throw new DomainException("Campo título não pode ter mais que 100 caracteres.");

            if (livro.EditoraId == 0)
                throw new DomainException("Campo editora inválido.");

            if (livro.CategoriaId == 0)
                throw new DomainException("Campo categoria inválido.");

            if (livro.DataPublicacao.HasValue && livro.DataPublicacao.Value.Date > DateTime.Now)
                throw new DomainException("Data da publicação não pode ser uma data futura.");
        }
    }
}