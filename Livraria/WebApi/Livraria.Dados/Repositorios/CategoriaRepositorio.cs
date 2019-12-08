using Livraria.Dados.Contexto;
using Livraria.Dominio.Entidades;
using Livraria.Dominio.Interfaces.Repositorios;

namespace Livraria.Dados.Repositorios
{
    public class CategoriaRepositorio : RepositorioBase<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(LivrariaContext context) : base(context)
        {
        }
    }
}