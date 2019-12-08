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
    public class CategoriaServicoTest
    {
        private ICategoriaServico _categoriaServico;
        private ICategoriaRepositorio _categoriaRepositorio;
        private ILivroRepositorio _livroRepositorio;

        [SetUp]
        public void Setup()
        {
            _categoriaRepositorio = new CategoriaRepositorioMock();
            _livroRepositorio = new LivroRepositorioMock();
            _categoriaServico = new CategoriaServico(_categoriaRepositorio, _livroRepositorio);
        }

        [Test]
        public void Deve_adicionar_uma_categoria()
        {
            var categoria = new Categoria
            {
                Nome = "Categoria 1"
            };

            _categoriaServico.Adicionar(categoria);

            var categorias = _categoriaServico.ObterTodos().ToList();

            Assert.AreEqual(1, categorias.Count);
            Assert.AreEqual("Categoria 1", categorias.First().Nome);
        }

        [Test]
        public void Deve_adicionar_e_atualizar_uma_categoria()
        {
            var categoria = new Categoria
            {
                Nome = "Categoria 1"
            };

            _categoriaServico.Adicionar(categoria);

            var categorias = _categoriaServico.ObterTodos().ToList();

            categoria.Nome = "Categoria 2";

            _categoriaServico.Atualizar(categoria);

            Assert.AreEqual(1, categorias.Count);
            Assert.AreEqual("Categoria 2", categorias.First().Nome);
        }

        [Test]
        public void Deve_adicionar_e_atualizar_uma_categoria_validada()
        {
            var categoria = new Categoria
            {
                Nome = "Categoria 1"
            };

            _categoriaServico.Validar(categoria);
            _categoriaServico.Adicionar(categoria);

            var categorias = _categoriaServico.ObterTodos().ToList();

            categoria.Nome = "Categoria 2";

            _categoriaServico.Validar(categoria);
            _categoriaServico.Atualizar(categoria);

            Assert.AreEqual(1, categorias.Count);
            Assert.AreEqual("Categoria 2", categorias.First().Nome);
        }

        [Test]
        public void Deve_adicionar_uma_categoria_e_buscar_por_id()
        {
            var categoria = new Categoria
            {
                Nome = "Categoria 1"
            };

            _categoriaServico.Adicionar(categoria);

            var registro = _categoriaServico.ObterPorId(categoria.CategoriaId);

            Assert.AreEqual(categoria.CategoriaId, registro.CategoriaId);
            Assert.AreEqual(categoria.Nome, registro.Nome);
        }

        [Test]
        public void Deve_adicionar_e_remover_uma_categoria()
        {
            var categoria = new Categoria
            {
                Nome = "Categoria 1"
            };

            _categoriaServico.Adicionar(categoria);
            _categoriaServico.Remover(categoria);

            var categorias = _categoriaServico.ObterTodos().ToList();

            Assert.AreEqual(0, categorias.Count);
        }

        [Test]
        public void Deve_adicionar_e_remover_uma_categoria_vinculada_ao_livro()
        {
            var categoria = new Categoria
            {
                Nome = "Categoria 1"
            };

            _categoriaServico.Adicionar(categoria);

            var livro = new Livro
            {
                CategoriaId = categoria.CategoriaId
            };

            _livroRepositorio.Adicionar(livro);

            var removeu = _categoriaServico.Remover(categoria);

            Assert.False(removeu);
        }

        [Test]
        public void Deve_validar_nome_nao_informado()
        {
            var categoria = new Categoria();

            _categoriaServico.Adicionar(categoria);

            Assert.Throws<DomainException>(() => _categoriaServico.Validar(categoria), "Campo nome é obrigatório.");
        }

        [Test]
        public void Deve_validar_nome_que_excede_limite_caracteres()
        {
            var categoria = new Categoria
            {
                Nome = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"
            };

            _categoriaServico.Adicionar(categoria);

            Assert.Throws<DomainException>(() => _categoriaServico.Validar(categoria), "Campo nome não pode ter mais que 100 caracteres.");
        }
    }
}