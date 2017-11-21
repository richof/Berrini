// richoRichof fPremioService.cs1810:33

using Berrini.Domain.Entities;
using Berrini.Domain.Interfaces.Repository;
using Berrini.Domain.Interfaces.Services;

namespace Berrini.Domain.DomainServicesImplementation
{

    public class PremioService:ServiceBase<Premio>,IPremioService
    {

        public PremioService(IPremioRepository repository) : base(repository)
        {
        }

    }

}