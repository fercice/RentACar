using AutoMapper;

namespace RentACar.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        protected AutoMapperConfig() { }

        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile());
            });
        }
    }
}
