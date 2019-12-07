using Livraria.Dominio.Entidades;
using Livraria.Dominio.Interfaces.Servicos;
using Livraria.WebApi.Interfaces.AppServicos;

namespace Livraria.WebApi.AppServicos
{
    public class EditoraAppServico : AppServicoBase<Editora>, IEditoraAppServico
    {
        private readonly IEditoraServico _editoraServico;

        public EditoraAppServico(IEditoraServico editoraServico) : base(editoraServico)
        {
            _editoraServico = editoraServico;
        }

        public new bool Remover(Editora editora)
        {
            return _editoraServico.Remover(editora);
        }
    }
}