using Livraria.Dados.Contexto;
using Livraria.Dominio.Entidades;
using Livraria.Dominio.Interfaces.Repositorios;

namespace Livraria.Dados.Repositorios
{
    public class EditoraRepositorio : RepositorioBase<Editora>, IEditoraRepositorio
    {
        public EditoraRepositorio(LivrariaContext context) : base(context)
        {
        }
    }
}