using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace eGaragem.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity>
    {
        bool Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        bool Atualizar(TEntity obj);
        bool Remover(Guid id);
    }
}
