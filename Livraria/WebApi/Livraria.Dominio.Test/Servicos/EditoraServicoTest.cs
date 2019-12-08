using Livraria.Dominio.Entidades;
using Livraria.Dominio.Exceptions;
using Livraria.Dominio.Interfaces.Repositorios;
using Livraria.Dominio.Interfaces.Servicos;
using Livraria.Dominio.Servicos;
using Livraria.Dominio.Test.Mock;
using NUnit.Framework;
using System.Linq;

namespace Livraria.Dominio.Test.Servicos
{
    public class EditoraServicoTest
    {
        private IEditoraServico _editoraServico;
        private IEditoraRepositorio _editoraRepositorio;
        private ILivroRepositorio _livroRepositorio;

        [SetUp]
        public void Setup()
        {
            _editoraRepositorio = new EditoraRepositorioMock();
            _livroRepositorio = new LivroRepositorioMock();
            _editoraServico = new EditoraServico(_editoraRepositorio, _livroRepositorio);
        }

        [Test]
        public void Deve_adicionar_uma_editora()
        {
            var editora = new Editora
            {
                Nome = "Editora 1"
            };

            _editoraServico.Adicionar(editora);

            var editoras = _editoraServico.ObterTodos().ToList();

            Assert.AreEqual(1, editoras.Count);
            Assert.AreEqual("Editora 1", editoras.First().Nome);
        }

        [Test]
        public void Deve_adicionar_e_atualizar_uma_editora()
        {
            var editora = new Editora
            {
                Nome = "Editora 1"
            };

            _editoraServico.Adicionar(editora);

            var editoras = _editoraServico.ObterTodos().ToList();

            editora.Nome = "Editora 2";

            _editoraServico.Atualizar(editora);

            Assert.AreEqual(1, editoras.Count);
            Assert.AreEqual("Editora 2", editoras.First().Nome);
        }

        [Test]
        public void Deve_adicionar_e_atualizar_uma_editora_validada()
        {
            var editora = new Editora
            {
                Nome = "Editora 1"
            };

            _editoraServico.Validar(editora);
            _editoraServico.Adicionar(editora);

            var editoras = _editoraServico.ObterTodos().ToList();

            editora.Nome = "Editora 2";

            _editoraServico.Validar(editora);
            _editoraServico.Atualizar(editora);

            Assert.AreEqual(1, editoras.Count);
            Assert.AreEqual("Editora 2", editoras.First().Nome);
        }

        [Test]
        public void Deve_adicionar_uma_editora_e_buscar_por_id()
        {
            var editora = new Editora
            {
                Nome = "Editora 1"
            };

            _editoraServico.Adicionar(editora);

            var registro = _editoraServico.ObterPorId(editora.EditoraId);

            Assert.AreEqual(editora.EditoraId, registro.EditoraId);
            Assert.AreEqual(editora.Nome, registro.Nome);
        }

        [Test]
        public void Deve_adicionar_e_remover_uma_editora()
        {
            var editora = new Editora
            {
                Nome = "Editora 1"
            };

            _editoraServico.Adicionar(editora);
            _editoraServico.Remover(editora);

            var editoras = _editoraServico.ObterTodos().ToList();

            Assert.AreEqual(0, editoras.Count);
        }

        [Test]
        public void Deve_adicionar_e_remover_uma_editora_vinculada_ao_livro()
        {
            var editora = new Editora
            {
                Nome = "Editora 1"
            };

            _editoraServico.Adicionar(editora);

            var livro = new Livro
            {
                EditoraId = editora.EditoraId
            };

            _livroRepositorio.Adicionar(livro);

            var removeu = _editoraServico.Remover(editora);

            Assert.False(removeu);
        }

        [Test]
        public void Deve_validar_nome_nao_informado()
        {
            var editora = new Editora();

            _editoraServico.Adicionar(editora);

            Assert.Throws<DomainException>(() => _editoraServico.Validar(editora), "Campo nome é obrigatório.");
        }

        [Test]
        public void Deve_validar_nome_que_excede_limite_caracteres()
        {
            var editora = new Editora
            {
                Nome = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"
            };

            _editoraServico.Adicionar(editora);

            Assert.Throws<DomainException>(() => _editoraServico.Validar(editora), "Campo nome não pode ter mais que 100 caracteres.");
        }
    }
}