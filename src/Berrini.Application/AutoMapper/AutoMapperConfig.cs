// richoRichof fAutoMapperConfig.cs1623:12

using AutoMapper;
namespace Berrini.Application.AutoMapper
{

    public class AutoMapperConfig
    {

        public static void ResgiterMapping()
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile<EntityToViewModelMappingProfile>();
                m.AddProfile<ViewModelToEntityMappingProfile>();
            });
        }

    }

}