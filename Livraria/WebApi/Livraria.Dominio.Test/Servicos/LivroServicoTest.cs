using Livraria.Dominio.Entidades;
using Livraria.Dominio.Exceptions;
using Livraria.Dominio.Interfaces.Repositorios;
using Livraria.Dominio.Interfaces.Servicos;
using Livraria.Dominio.Servicos;
using Livraria.Dominio.Test.Mock;
using NUnit.Framework;
using System;
using System.Linq;

namespace Livraria.Dominio.Test.Servicos
{
    public class LivroServicoTest
    {
        private ILivroServico _livroServico;
        private ILivroRepositorio _livroRepositorio;

        [SetUp]
        public void Setup()
        {
            _livroRepositorio = new LivroRepositorioMock();
            _livroServico = new LivroServico(_livroRepositorio);
        }

        [Test]
        public void Deve_adicionar_um_livro()
        {
            var livro = new Livro
            {
                Titulo = "Livro 1"
            };

            _livroServico.Adicionar(livro);

            var livros = _livroServico.ObterTodos().ToList();

            Assert.AreEqual(1, livros.Count);
            Assert.AreEqual("Livro 1", livros.First().Titulo);
        }

        [Test]
        public void Deve_adicionar_alguns_livros_e_buscar_ordenados_pelo_titulo()
        {
            var livroB = new Livro
            {
                Titulo = "Livro B"
            };

            _livroServico.Adicionar(livroB);

            var livroC = new Livro
            {
                Titulo = "Livro C"
            };

            _livroServico.Adicionar(livroC);

            var livroA = new Livro
            {
                Titulo = "Livro A"
            };

            _livroServico.Adicionar(livroA);

            var livroD = new Livro
            {
                Titulo = "Livro D"
            };

            _livroServico.Adicionar(livroD);

            var livros = _livroServico.ObterTodosOrdenadosPorTitulo().ToList();

            Assert.AreEqual(4, livros.Count);
            Assert.AreEqual("Livro A", livros[0].Titulo);
            Assert.AreEqual("Livro B", livros[1].Titulo);
            Assert.AreEqual("Livro C", livros[2].Titulo);
            Assert.AreEqual("Livro D", livros[3].Titulo);
        }

        [Test]
        public void Deve_adicionar_atualizar_um_livro_validado()
        {
            var livro = new Livro
            {
                Titulo = "Livro 1",
                CategoriaId = 1,
                EditoraId = 1
            };

            _livroServico.Validar(livro);
            _livroServico.Adicionar(livro);

            var livros = _livroServico.ObterTodos().ToList();

            livro.DataPublicacao = DateTime.Today.AddYears(-1);

            _livroServico.Validar(livro);
            _livroServico.Atualizar(livro);

            Assert.AreEqual(1, livros.Count);
            Assert.IsNotNull(livro.DataPublicacao);
        }

        [Test]
        public void Deve_adicionar_e_atualizar_um_livro()
        {
            var livro = new Livro
            {
                Titulo = "Livro 1"
            };

            _livroServico.Adicionar(livro);

            var livros = _livroServico.ObterTodos().ToList();

            livro.Titulo = "Livro 2";

            _livroServico.Atualizar(livro);

            Assert.AreEqual(1, livros.Count);
            Assert.AreEqual("Livro 2", livros.First().Titulo);
        }

        [Test]
        public void Deve_adicionar_um_livro_e_buscar_por_id()
        {
            var livro = new Livro
            {
                Titulo = "Livro 1"
            };

            _livroServico.Adicionar(livro);

            var registro = _livroServico.ObterPorId(livro.LivroId);

            Assert.AreEqual(livro.LivroId, registro.LivroId);
            Assert.AreEqual(livro.Titulo, registro.Titulo);
        }

        [Test]
        public void Deve_adicionar_e_remover_um_livro()
        {
            var livro = new Livro
            {
                Titulo = "Livro 1"
            };

            _livroServico.Adicionar(livro);
            _livroServico.Remover(livro);

            var livros = _livroServico.ObterTodos().ToList();

            Assert.AreEqual(0, livros.Count);
        }

        [Test]
        public void Deve_validar_titulo_nao_informado()
        {
            var livro = new Livro();

            _livroServico.Adicionar(livro);

            Assert.Throws<DomainException>(() => _livroServico.Validar(livro), "Campo título é obrigatório.");
        }

        [Test]
        public void Deve_validar_titulo_que_excede_limite_caracteres()
        {
            var livro = new Livro
            {
                Titulo = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"
            };

            _livroServico.Adicionar(livro);

            Assert.Throws<DomainException>(() => _livroServico.Validar(livro), "Campo título não pode ter mais que 100 caracteres.");
        }

        [Test]
        public void Deve_validar_editora_nao_informada()
        {
            var livro = new Livro
            {
                Titulo = "Livro 1"
            };

            _livroServico.Adicionar(livro);

            Assert.Throws<DomainException>(() => _livroServico.Validar(livro), "Campo editora inválido.");
        }

        [Test]
        public void Deve_validar_categoria_nao_informada()
        {
            var livro = new Livro
            {
                Titulo = "Livro 1",
                EditoraId = 1
            };

            _livroServico.Adicionar(livro);

            Assert.Throws<DomainException>(() => _livroServico.Validar(livro), "Campo categoria inválido.");
        }

        [Test]
        public void Deve_validar_data_de_publicacao_futura()
        {
            var livro = new Livro
            {
                Titulo = "Livro 1",
                EditoraId = 1,
                CategoriaId = 1,
                DataPublicacao = DateTime.Today.AddDays(1)
            };

            _livroServico.Adicionar(livro);

            Assert.Throws<DomainException>(() => _livroServico.Validar(livro), "Data da publicação não pode ser uma data futura.");
        }
    }
}