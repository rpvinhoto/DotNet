using Livraria.Dominio.Entidades;
using Livraria.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Dominio.Test.Mock
{
    public class LivroRepositorioMock : ILivroRepositorio
    {
        private readonly List<Livro> registros = new List<Livro>();

        public void Adicionar(Livro entidade)
        {
            entidade.LivroId = registros.Count + 1;

            registros.Add(entidade);
        }

        public Task AdicionarAsync(Livro entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Livro entidade)
        {
            Remover(entidade);
            registros.Add(entidade);
        }

        public Task AtualizarAsync(Livro entidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Existe(long id)
        {
            return registros.Exists(r => r.LivroId == id);
        }

        public bool ExisteComCategoria(long categoriaId)
        {
            return registros.Exists(l => l.CategoriaId == categoriaId);
        }

        public bool ExisteComEditora(long editoraId)
        {
            return registros.Exists(l => l.EditoraId == editoraId);
        }

        public Livro ObterPorId(long id)
        {
            return registros.FirstOrDefault(r => r.LivroId == id);
        }

        public Task<Livro> ObterPorIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Livro> ObterPorTitulo(string titulo)
        {
            return registros.Where(r => r.Titulo == titulo);
        }

        public IEnumerable<Livro> ObterTodos()
        {
            return registros;
        }

        public IEnumerable<Livro> ObterTodosOrdenadosPorTitulo()
        {
            return registros.OrderBy(r => r.Titulo);
        }

        public void Remover(Livro entidade)
        {
            var index = registros.FindIndex(r => r.LivroId == entidade.LivroId);

            if (index != -1)
                registros.RemoveAt(index);
        }
    }
}