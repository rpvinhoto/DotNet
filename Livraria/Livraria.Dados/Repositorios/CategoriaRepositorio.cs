using Livraria.Dados.Contexto;
using Livraria.Dominio.Entidades;
using Livraria.Dominio.Interfaces.Repositorios;
using System.Linq;

namespace Livraria.Dados.Repositorios
{
    public class CategoriaRepositorio : RepositorioBase<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(LivrariaContext context) : base(context)
        {
        }

        public new bool Remover(Categoria categoria)
        {
            if (_db.Livros.ToList().Exists(l => l.CategoriaId == categoria.CategoriaId))
                return false;

            _db.Categorias.Remove(categoria);
            _db.SaveChanges();

            return true;
        }
    }
}