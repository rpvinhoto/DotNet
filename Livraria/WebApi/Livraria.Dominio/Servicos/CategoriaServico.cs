using Livraria.Dominio.Entidades;
using Livraria.Dominio.Exceptions;
using Livraria.Dominio.Interfaces.Repositorios;
using Livraria.Dominio.Interfaces.Servicos;

namespace Livraria.Dominio.Servicos
{
    public class CategoriaServico : ServicoBase<Categoria>, ICategoriaServico
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly ILivroRepositorio _livroRepositorio;

        public CategoriaServico(ICategoriaRepositorio categoriaRepositorio,
            ILivroRepositorio livroRepositorio) : base(categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _livroRepositorio = livroRepositorio;
        }

        public new bool Remover(Categoria categoria)
        {
            if (_livroRepositorio.ExisteComCategoria(categoria.CategoriaId))
                return false;

            _categoriaRepositorio.Remover(categoria);

            return true;
        }

        public void Validar(Categoria categoria)
        {
            if (string.IsNullOrEmpty(categoria.Nome))
                throw new DomainException("Campo nome é obrigatório.");

            if (categoria.Nome.Length > 100)
                throw new DomainException("Campo nome não pode ter mais que 100 caracteres.");
        }
    }
}