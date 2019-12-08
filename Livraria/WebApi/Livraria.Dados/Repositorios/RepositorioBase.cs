using Livraria.Dados.Contexto;
using Livraria.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Dados.Repositorios
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : class
    {
        protected readonly LivrariaContext _db;

        public RepositorioBase(LivrariaContext context)
        {
            _db = context;
        }

        public void Adicionar(TEntidade entidade)
        {
            _db.Set<TEntidade>().Add(entidade);
            _db.SaveChanges();
        }

        public async Task AdicionarAsync(TEntidade entidade)
        {
            await _db.Set<TEntidade>().AddAsync(entidade);
            await _db.SaveChangesAsync();
        }

        public void Atualizar(TEntidade entidade)
        {
            _db.Entry(entidade).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public async Task AtualizarAsync(TEntidade entidade)
        {
            _db.Entry(entidade).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public bool Existe(long id)
        {
            return _db.Set<TEntidade>().Find(id) != null;
        }

        public TEntidade ObterPorId(long id)
        {
            return _db.Set<TEntidade>().Find(id);
        }

        public async Task<TEntidade> ObterPorIdAsync(long id)
        {
            return await _db.Set<TEntidade>().FindAsync(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return _db.Set<TEntidade>();
        }

        public void Remover(TEntidade entidade)
        {
            _db.Set<TEntidade>().Remove(entidade);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _db.Dispose();
        }
    }
}