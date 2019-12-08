using Livraria.Dominio.Entidades;
using Livraria.Dominio.Exceptions;
using Livraria.Dominio.Interfaces.Repositorios;
using Livraria.Dominio.Interfaces.Servicos;

namespace Livraria.Dominio.Servicos
{
    public class EditoraServico : ServicoBase<Editora>, IEditoraServico
    {
        private readonly IEditoraRepositorio _editoraRepositorio;
        private readonly ILivroRepositorio _livroRepositorio;

        public EditoraServico(IEditoraRepositorio editoraRepositorio,
            ILivroRepositorio livroRepositorio) : base(editoraRepositorio)
        {
            _editoraRepositorio = editoraRepositorio;
            _livroRepositorio = livroRepositorio;
        }

        public new bool Remover(Editora editora)
        {
            if (_livroRepositorio.ExisteComEditora(editora.EditoraId))
                return false;

            _editoraRepositorio.Remover(editora);

            return true;
        }

        public void Validar(Editora editora)
        {
            if (string.IsNullOrEmpty(editora.Nome))
                throw new DomainException("Campo nome é obrigatório.");

            if (editora.Nome.Length > 100)
                throw new DomainException("Campo nome não pode ter mais que 100 caracteres.");
        }
    }
}