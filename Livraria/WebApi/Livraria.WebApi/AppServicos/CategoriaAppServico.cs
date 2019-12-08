using Livraria.Dominio.Entidades;
using Livraria.Dominio.Interfaces.Servicos;
using Livraria.WebApi.Interfaces.AppServicos;

namespace Livraria.WebApi.AppServicos
{
    public class CategoriaAppServico : AppServicoBase<Categoria>, ICategoriaAppServico
    {
        private readonly ICategoriaServico _categoriaServico;

        public CategoriaAppServico(ICategoriaServico categoriaServico) : base(categoriaServico)
        {
            _categoriaServico = categoriaServico;
        }

        public new bool Remover(Categoria categoria)
        {
            return _categoriaServico.Remover(categoria);
        }
    }
}