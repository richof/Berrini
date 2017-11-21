// richoRichof fIClienteService.cs1621:13

using System.Collections.Generic;
using Berrini.Domain.Entities;
namespace Berrini.Domain.Interfaces.Services
{

    public interface IClienteService:IServiceBase<Cliente>
    {

        IEnumerable<Cliente> Premiados();

    }

}