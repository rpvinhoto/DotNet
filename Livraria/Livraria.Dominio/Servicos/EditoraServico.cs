using Livraria.Dominio.Entidades;
using Livraria.Dominio.Interfaces.Repositorios;
using Livraria.Dominio.Interfaces.Servicos;

namespace Livraria.Dominio.Servicos
{
    public class EditoraServico : ServicoBase<Editora>, IEditoraServico
    {
        private readonly IEditoraRepositorio editoraRepositorio;

        public EditoraServico(IEditoraRepositorio editoraRepositorio) : base(editoraRepositorio)
        {
            this.editoraRepositorio = editoraRepositorio;
        }

        public new bool Remover(Editora editora)
        {
            return editoraRepositorio.Remover(editora);
        }
    }
}