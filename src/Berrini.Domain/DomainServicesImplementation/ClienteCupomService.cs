// richoRichof fClienteCupomService.cs1622:54

using Berrini.Domain.Entities;
using Berrini.Domain.Interfaces.Repository;
using Berrini.Domain.Interfaces.Services;
namespace Berrini.Domain.DomainServicesImplementation
{

    public class ClienteCupomService:ServiceBase<ClienteCupom>,IClienteCupomService
    {

        public ClienteCupomService(IClienteCupomRepository repository) : base(repository)
        {
        }

    }

}