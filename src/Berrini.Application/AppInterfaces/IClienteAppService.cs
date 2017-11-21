// richoRichof fIClienteAppService.cs1623:39

using System;
using System.Collections.Generic;
using Berrini.Application.ViewModels;
using Berrini.Domain.Entities;
namespace Berrini.Application.AppInterfaces
{

    public interface IClienteAppService:IAppServiceBase<ClienteViewModel,Cliente>
    {

        bool CadastrarCliente(Guid id, string nome, string cpf);

        IEnumerable<ClientePremiadoViewModel> Premiados();

    }

}