using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ComputeFutureValue.Api.Mapper
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAutoMapperMappingConfiguration(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
