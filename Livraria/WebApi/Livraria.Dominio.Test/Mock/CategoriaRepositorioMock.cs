using Livraria.Dominio.Entidades;
using Livraria.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Dominio.Test.Mock
{
    public class CategoriaRepositorioMock : ICategoriaRepositorio
    {
        private readonly List<Categoria> registros = new List<Categoria>();

        public void Adicionar(Categoria entidade)
        {
            entidade.CategoriaId = registros.Count + 1;
            registros.Add(entidade);
        }

        public Task AdicionarAsync(Categoria entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Categoria entidade)
        {
            Remover(entidade);
            registros.Add(entidade);
        }

        public Task AtualizarAsync(Categoria entidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Existe(long id)
        {
            return registros.Exists(r => r.CategoriaId == id);
        }

        public Categoria ObterPorId(long id)
        {
            return registros.FirstOrDefault(r => r.CategoriaId == id);
        }

        public Task<Categoria> ObterPorIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> ObterTodos()
        {
            return registros;
        }

        public void Remover(Categoria entidade)
        {
            var index = registros.FindIndex(r => r.CategoriaId == entidade.CategoriaId);

            if (index != -1)
                registros.RemoveAt(index);
        }
    }
}