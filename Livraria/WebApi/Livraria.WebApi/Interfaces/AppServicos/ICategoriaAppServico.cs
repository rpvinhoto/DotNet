using Livraria.Dominio.Entidades;

namespace Livraria.WebApi.Interfaces.AppServicos
{
    public interface ICategoriaAppServico : IAppServicoBase<Categoria>
    {
        new bool Remover(Categoria categoria);
    }
}