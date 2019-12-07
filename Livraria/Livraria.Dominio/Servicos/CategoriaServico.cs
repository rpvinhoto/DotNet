using Livraria.Dominio.Entidades;
using Livraria.Dominio.Interfaces.Repositorios;
using Livraria.Dominio.Interfaces.Servicos;

namespace Livraria.Dominio.Servicos
{
    public class CategoriaServico : ServicoBase<Categoria>, ICategoriaServico
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaServico(ICategoriaRepositorio categoriaRepositorio) : base(categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public new bool Remover(Categoria categoria)
        {
            return _categoriaRepositorio.Remover(categoria);
        }
    }
}