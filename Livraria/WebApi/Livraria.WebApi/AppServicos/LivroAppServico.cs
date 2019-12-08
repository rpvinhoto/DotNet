using Livraria.Dominio.Entidades;
using Livraria.Dominio.Exceptions;
using Livraria.Dominio.Interfaces.Servicos;
using Livraria.WebApi.Interfaces.AppServicos;
using System.Collections.Generic;

namespace Livraria.WebApi.AppServicos
{
    public class LivroAppServico : AppServicoBase<Livro>, ILivroAppServico
    {
        private readonly ILivroServico _livroServico;
        private readonly IEditoraServico _editoraServico;
        private readonly ICategoriaServico _categoriaServico;

        public LivroAppServico(ILivroServico livroServico,
            IEditoraServico editoraServico,
            ICategoriaServico categoriaServico) : base(livroServico)
        {
            _livroServico = livroServico;
            _editoraServico = editoraServico;
            _categoriaServico = categoriaServico;
        }

        public IEnumerable<Livro> ObterPorTitulo(string titulo)
        {
            return _livroServico.ObterPorTitulo(titulo);
        }

        public IEnumerable<Livro> ObterTodosOrdenadosPorTitulo()
        {
            return _livroServico.ObterTodosOrdenadosPorTitulo();
        }

        public void Validar(Livro livro)
        {
            _livroServico.Validar(livro);

            if (!ExisteEditora(livro.EditoraId))
                throw new DomainException("Editora não encontrada.");

            if (!ExisteCategoria(livro.CategoriaId))
                throw new DomainException("Categoria não encontrada.");
        }

        private bool ExisteCategoria(long id)
        {
            return _categoriaServico.Existe(id);
        }

        private bool ExisteEditora(long id)
        {
            return _editoraServico.Existe(id);
        }
    }
}