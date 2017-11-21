using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berrini.Application.AppInterfaces;
using Berrini.Application.AppServicesImplementation;
using Berrini.Domain.DomainServicesImplementation;
using Berrini.Domain.Interfaces.Repository;
using Berrini.Domain.Interfaces.Services;
using Berrini.Infra.Data.Repository;
using SimpleInjector;
namespace Berrini.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {

        public static void Register(Container container)
        {
            #region Repository
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<ICupomRepository, CupomRepository>(Lifestyle.Scoped);
            container.Register<IClienteCupomRepository, ClienteCupomRepository>(Lifestyle.Scoped);
            container.Register<IPremioRepository, PremioRepository>(Lifestyle.Scoped);
            #endregion

            #region Domain Services
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
            container.Register<ICupomService, CupomService>(Lifestyle.Scoped);
            container.Register<IClienteCupomService, ClienteCupomService>(Lifestyle.Scoped);
            container.Register<IPremioService, PremioService>(Lifestyle.Scoped);
            #endregion

            #region Application services

            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
            container.Register<ICupomAppService, CupomAppService>(Lifestyle.Scoped);
            container.Register<IPremioAppService, PremioAppService>(Lifestyle.Scoped);
            #endregion

        }
    }
}
