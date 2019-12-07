using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.WebApi.Interfaces.AppServicos
{
    public interface IAppServicoBase<TEntidade> : IDisposable where TEntidade : class
    {
        void Adicionar(TEntidade entidade);
        Task AdicionarAsync(TEntidade entidade);
        void Atualizar(TEntidade entidade);
        Task AtualizarAsync(TEntidade entidade);
        bool Existe(long id);
        TEntidade ObterPorId(long id);
        Task<TEntidade> ObterPorIdAsync(long id);
        IEnumerable<TEntidade> ObterTodos();
        void Remover(TEntidade entidade);
    }
}