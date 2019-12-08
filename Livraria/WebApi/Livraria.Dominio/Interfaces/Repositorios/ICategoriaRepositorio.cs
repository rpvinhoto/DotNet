using Livraria.Dominio.Entidades;

namespace Livraria.Dominio.Interfaces.Repositorios
{
    public interface ICategoriaRepositorio : IRepositorioBase<Categoria>
    {
        new bool Remover(Categoria categoria);
    }
}