// richoRichof fAppServiceBase.cs1623:08

using System;
using System.Collections.Generic;
using AutoMapper;
using Berrini.Domain.Interfaces.Services;
using System.Linq;
using Berrini.Application.AppInterfaces;
namespace Berrini.Application.AppServicesImplementation
{

    public class AppServiceBase<TViewModel,TEntity>:IAppServiceBase<TViewModel,TEntity> where TViewModel:class where TEntity:class
    {
        private readonly IServiceBase<TEntity> _service;

        public AppServiceBase(IServiceBase<TEntity> service)
        {
            _service=service;
        }

        public virtual TViewModel Adicionar(TViewModel viewModel)
        {
            var entity=ToEntity(viewModel);
            var result=_service.Adicionar(entity);
            return viewModel;
        }

        public virtual IEnumerable<TViewModel> ObterTodos()
        {
            var resultado=_service.ObterTodos().Select(ToViewModel);
            return resultado;

        }

        public virtual TViewModel ObterPorId(Guid id)
        {
            var resultado=ToViewModel(_service.ObterPorId(id));
            return resultado;
        }
     

        public virtual TViewModel Atualizar(TViewModel viewModel)
        {
            var resultado=ToViewModel(_service.Atualizar(ToEntity(viewModel)));
            return resultado;
        }

        public virtual void Salvar()
        {
            _service.Salvar();
        }

        public virtual void Remover(Guid id)
        {
            _service.Remover(id);
        }

        #region Mapping helpers



        protected virtual TViewModel ToViewModel(TEntity entity)
        {
            var resultado=Mapper.Map<TEntity, TViewModel>(entity);
            return resultado;
        }

        protected virtual TEntity ToEntity(TViewModel viewModel)
        {
            var resultado=Mapper.Map<TViewModel, TEntity>(viewModel);
            return resultado;
        }
        #endregion
    }

}