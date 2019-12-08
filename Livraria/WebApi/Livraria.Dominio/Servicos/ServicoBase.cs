using Livraria.Dominio.Interfaces.Repositorios;
using Livraria.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Dominio.Servicos
{
    public class ServicoBase<TEntidade> : IServicoBase<TEntidade> where TEntidade : class
    {
        private readonly IRepositorioBase<TEntidade> _repositorio;

        public ServicoBase(IRepositorioBase<TEntidade> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adicionar(TEntidade entidade)
        {
            _repositorio.Adicionar(entidade);
        }

        public async Task AdicionarAsync(TEntidade entidade)
        {
            await _repositorio.AdicionarAsync(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            _repositorio.Atualizar(entidade);
        }

        public async Task AtualizarAsync(TEntidade entidade)
        {
            await _repositorio.AtualizarAsync(entidade);
        }

        public bool Existe(long id)
        {
            return _repositorio.Existe(id);
        }

        public TEntidade ObterPorId(long id)
        {
            return _repositorio.ObterPorId(id);
        }

        public async Task<TEntidade> ObterPorIdAsync(long id)
        {
            return await _repositorio.ObterPorIdAsync(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public void Remover(TEntidade entidade)
        {
            _repositorio.Remover(entidade);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _repositorio.Dispose();
        }
    }
}