using Livraria.Dominio.Interfaces.Repositorios;
using Livraria.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace Livraria.Dominio.Servicos
{
    public class ServicoBase<TEntidade> : IDisposable, IServicoBase<TEntidade> where TEntidade : class
    {
        private readonly IRepositorioBase<TEntidade> repositorio;

        public ServicoBase(IRepositorioBase<TEntidade> repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Adicionar(TEntidade entidade)
        {
            repositorio.Adicionar(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            repositorio.Atualizar(entidade);
        }

        public void Dispose()
        {
            repositorio.Dispose();
        }

        public TEntidade ObterPorId(int id)
        {
            return repositorio.ObterPorId(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return repositorio.ObterTodos();
        }

        public void Remover(TEntidade entidade)
        {
            repositorio.Remover(entidade);
        }
    }
}