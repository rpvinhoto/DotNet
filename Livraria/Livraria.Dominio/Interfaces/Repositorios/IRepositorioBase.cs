using System;
using System.Collections.Generic;

namespace Livraria.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidade>: IDisposable where TEntidade : class
    {
        void Adicionar(TEntidade entidade);

        TEntidade ObterPorId(int id);

        IEnumerable<TEntidade> ObterTodos();

        void Atualizar(TEntidade entidade);

        void Remover(TEntidade entidade);
    }
}