// richoRichof fICupomAppService.cs1623:43

using System;
using System.Collections.Generic;
using Berrini.Application.ViewModels;
using Berrini.Domain.Entities;
namespace Berrini.Application.AppInterfaces
{

    public interface ICupomAppService:IAppServiceBase<CupomViewModel,Cupom>
    {

        IEnumerable<CupomViewModel> ObterPorCliente(Guid id);
        CadastroCupomViewModel Cadastrar(CadastroCupomViewModel cupom, Guid clienteId);
        bool JaCadastrado(CupomViewModel cupom);
        bool JaCadastrado(CadastroCupomViewModel cupom);
        bool PodeCadastrar(Guid clienteId);

        IEnumerable<ClienteCupomViewModel> CuponsCadastrados();
        bool ExisteCupom(string numeroCupom);
        

    }

}