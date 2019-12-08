using Livraria.Dominio.Entidades;

namespace Livraria.Dominio.Interfaces.Servicos
{
    public interface IEditoraServico : IServicoBase<Editora>
    {
        new bool Remover(Editora editora);
    }
}