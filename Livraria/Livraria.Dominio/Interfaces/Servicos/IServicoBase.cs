using System.Collections.Generic;

namespace Livraria.Dominio.Interfaces.Servicos
{
    public interface IServicoBase<TEntidade> where TEntidade : class
    {
        void Adicionar(TEntidade entidade);

        TEntidade ObterPorId(int id);

        IEnumerable<TEntidade> ObterTodos();

        void Atualizar(TEntidade entidade);

        void Remover(TEntidade entidade);
    }
}