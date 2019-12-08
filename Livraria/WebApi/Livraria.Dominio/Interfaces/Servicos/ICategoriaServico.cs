using Livraria.Dominio.Entidades;

namespace Livraria.Dominio.Interfaces.Servicos
{
    public interface ICategoriaServico : IServicoBase<Categoria>
    {
        new bool Remover(Categoria categoria);
        void Validar(Categoria categoria);
    }
}