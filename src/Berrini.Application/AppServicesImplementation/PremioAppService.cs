// richoRichof fPremioAppService.cs1810:39

using Berrini.Application.AppInterfaces;
using Berrini.Application.ViewModels;
using Berrini.Domain.Entities;
using Berrini.Domain.Interfaces.Services;
namespace Berrini.Application.AppServicesImplementation
{

    public class PremioAppService:AppServiceBase<PremioViewModel,Premio>,IPremioAppService
    {

        public PremioAppService(IPremioService service) : base(service)
        {
        }

    }

}