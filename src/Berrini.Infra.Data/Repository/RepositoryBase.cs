// richoRichof fRepositoryBase.cs1620:38

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using Berrini.Domain.Interfaces.Repository;
using Berrini.Infra.Data.Context;
namespace Berrini.Infra.Data.Repository
{

    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected CtxBerrini Db;
        protected DbSet<TEntity> DbSet;

        public RepositoryBase()
        {
            Db = new CtxBerrini();
            DbSet = Db.Set<TEntity>();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Db.Dispose();
        }

        public TEntity Adicionar(TEntity entity)
        {
            var resultado = DbSet.Add(entity);
            Salvar();
            return resultado;
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            var resultado = DbSet.ToList();
            return resultado;
        }

        public TEntity ObterPorId(Guid id)
        {
            var resultado = DbSet.Find(id);
            return resultado;
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity,bool>> expressao)
        {
            var resultado=DbSet.Where(expressao);
            return resultado;
        }

        public TEntity Atualizar(TEntity entity)
        {
            var entrada=Db.Entry(entity);
            entrada.State=EntityState.Modified;
            Salvar();
            return entity;
        }
        public void Remover(Guid id)
        {
            var entity=ObterPorId(id);
            Db.Entry(entity).State=EntityState.Deleted;
            Salvar();
        }
        public void Salvar()
        {
            try
            {
                Db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }


        }

        

    }

}