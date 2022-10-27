using RentACar.Application.AutoMapper;

namespace RentACar.Services.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(MappingProfile));

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            Application.AutoMapper.AutoMapperConfig.RegisterMappings();
        }
    }
}