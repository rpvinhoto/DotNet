using Livraria.Dominio.Interfaces.Servicos;
using Livraria.WebApi.Interfaces.AppServicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.WebApi.AppServicos
{
    public class AppServicoBase<TEntidade> : IAppServicoBase<TEntidade> where TEntidade : class
    {
        private readonly IServicoBase<TEntidade> _servicoBase;

        public AppServicoBase(IServicoBase<TEntidade> servicoBase)
        {
            _servicoBase = servicoBase;
        }

        public void Adicionar(TEntidade entidade)
        {
            _servicoBase.Adicionar(entidade);
        }

        public async Task AdicionarAsync(TEntidade entidade)
        {
            await _servicoBase.AdicionarAsync(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            _servicoBase.Atualizar(entidade);
        }

        public async Task AtualizarAsync(TEntidade entidade)
        {
            await _servicoBase.AtualizarAsync(entidade);
        }

        public bool Existe(long id)
        {
            return _servicoBase.Existe(id);
        }

        public TEntidade ObterPorId(long id)
        {
            return _servicoBase.ObterPorId(id);
        }

        public async Task<TEntidade> ObterPorIdAsync(long id)
        {
            return await _servicoBase.ObterPorIdAsync(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return _servicoBase.ObterTodos();
        }

        public void Remover(TEntidade entidade)
        {
            _servicoBase.Remover(entidade);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _servicoBase.Dispose();
        }
    }
}