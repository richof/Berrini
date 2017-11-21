// richoRichof fIServiceBase.cs1621:12

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Berrini.Domain.Interfaces.Services
{

    public interface IServiceBase<TEntity>:IDisposable where TEntity:class
    {
        TEntity Adicionar(TEntity entity);

        IEnumerable<TEntity> ObterTodos();

        TEntity ObterPorId(Guid id);

        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> expressao);

        TEntity Atualizar(TEntity entity);

        void Salvar();

        void Remover(Guid id);


    }

}