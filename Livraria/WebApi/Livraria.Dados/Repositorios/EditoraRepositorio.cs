using Livraria.Dados.Contexto;
using Livraria.Dominio.Entidades;
using Livraria.Dominio.Interfaces.Repositorios;
using System.Linq;

namespace Livraria.Dados.Repositorios
{
    public class EditoraRepositorio : RepositorioBase<Editora>, IEditoraRepositorio
    {
        public EditoraRepositorio(LivrariaContext context) : base(context)
        {
        }

        public new bool Remover(Editora editora)
        {
            if (_db.Livros.ToList().Exists(l => l.EditoraId == editora.EditoraId))
                return false;

            _db.Editoras.Remove(editora);
            _db.SaveChanges();

            return true;
        }
    }
}