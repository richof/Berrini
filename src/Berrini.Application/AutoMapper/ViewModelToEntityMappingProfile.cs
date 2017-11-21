// richoRichof fAutoMapperConfig.cs1623:12

using AutoMapper;
using Berrini.Application.ViewModels;
using Berrini.Domain.Entities;
namespace Berrini.Application.AutoMapper
{
    public class ViewModelToEntityMappingProfile:Profile
    {

        public ViewModelToEntityMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<CupomViewModel, Cupom>();
            CreateMap<PremioViewModel, Premio>();
            CreateMap<ClienteCupomViewModel, ClienteCupom>();
            CreateMap<CadastroCupomViewModel, Cupom>();
        }
    }
}