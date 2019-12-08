using Livraria.Dominio.Entidades;

namespace Livraria.WebApi.Interfaces.AppServicos
{
    public interface IEditoraAppServico : IAppServicoBase<Editora>
    {
        new bool Remover(Editora editora);
    }
}