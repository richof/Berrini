// richoRichof fIAppServiceBase.cs1623:01

using System;
using System.Collections.Generic;
namespace Berrini.Application.AppInterfaces
{

    public interface IAppServiceBase<TViewModel,TEntity> where TViewModel:class where TEntity:class
    {
        TViewModel Adicionar(TViewModel viewModel);

        IEnumerable<TViewModel> ObterTodos();

        TViewModel ObterPorId(Guid id);

        //IEnumerable<TViewModel> Buscar(Expression<Func<TViewModel, bool>> expressao);

        TViewModel Atualizar(TViewModel viewModel);

        void Salvar();

        void Remover(Guid id);


    }

}