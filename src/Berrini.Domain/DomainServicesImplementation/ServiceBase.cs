// richoRichof fServiceBase.cs1621:22

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Berrini.Domain.Interfaces.Repository;
using Berrini.Domain.Interfaces.Services;
namespace Berrini.Domain.DomainServicesImplementation
{

    public class ServiceBase<TEntity>:IServiceBase<TEntity> where TEntity:class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository=repository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);

        }

        public virtual TEntity Adicionar(TEntity entity)
        {
            var resultado=_repository.Adicionar(entity);
            return resultado;
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            var resultado=_repository.ObterTodos();
            return resultado;
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            var resultado = _repository.ObterPorId(id);
            return resultado;
        }

        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> expressao)
        {
            var resultado=_repository.Buscar(expressao);
            return resultado;
        }

        public virtual TEntity Atualizar(TEntity entity)
        {
            var resultado=_repository.Atualizar(entity);
            return resultado;
        }

        public virtual void Salvar()
        {
            _repository.Salvar();
        }

        public virtual void Remover(Guid id)
        {
            _repository.Remover(id);
        }

    }

}