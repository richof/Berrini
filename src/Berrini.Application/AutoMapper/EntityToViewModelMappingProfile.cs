// richoRichof fAutoMapperConfig.cs1623:12

using AutoMapper;
using Berrini.Application.ViewModels;
using Berrini.Domain.Entities;
namespace Berrini.Application.AutoMapper
{
    public class EntityToViewModelMappingProfile:Profile
    {

        public EntityToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Cupom, CupomViewModel>();
            CreateMap<Premio, PremioViewModel>();
            CreateMap<ClienteCupom, ClienteCupomViewModel>();
            CreateMap<Cupom, CadastroCupomViewModel>();
        }
    }
}