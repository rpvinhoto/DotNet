using Livraria.Dominio.Entidades;
using Livraria.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Dominio.Test.Mock
{
    public class EditoraRepositorioMock : IEditoraRepositorio
    {
        private readonly List<Editora> registros = new List<Editora>();

        public void Adicionar(Editora entidade)
        {
            entidade.EditoraId = registros.Count + 1;

            registros.Add(entidade);
        }

        public Task AdicionarAsync(Editora entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Editora entidade)
        {
            Remover(entidade);
            registros.Add(entidade);
        }

        public Task AtualizarAsync(Editora entidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Existe(long id)
        {
            return registros.Exists(r => r.EditoraId == id);
        }

        public Editora ObterPorId(long id)
        {
            return registros.FirstOrDefault(r => r.EditoraId == id);
        }

        public Task<Editora> ObterPorIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Editora> ObterTodos()
        {
            return registros;
        }

        public void Remover(Editora entidade)
        {
            var index = registros.FindIndex(r => r.EditoraId == entidade.EditoraId);

            if (index != -1)
                registros.RemoveAt(index);
        }
    }
}