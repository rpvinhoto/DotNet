using Livraria.Dominio.Entidades;
using Livraria.Dominio.Interfaces.Repositorios;
using Livraria.Dominio.Interfaces.Servicos;

namespace Livraria.Dominio.Servicos
{
    public class EditoraServico : ServicoBase<Editora>, IEditoraServico
    {
        private readonly IEditoraRepositorio _editoraRepositorio;

        public EditoraServico(IEditoraRepositorio editoraRepositorio) : base(editoraRepositorio)
        {
            _editoraRepositorio = editoraRepositorio;
        }

        public new bool Remover(Editora editora)
        {
            return _editoraRepositorio.Remover(editora);
        }
    }
}