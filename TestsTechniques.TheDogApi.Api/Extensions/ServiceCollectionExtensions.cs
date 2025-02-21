using TestsTechniques.TheDogApi.Models.Configuration;

namespace TestsTechniques.TheDogApi.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TheDogApiConfiguration>(configuration.GetSection(TheDogApiConfiguration.DogApiConfiguration));

            return services;
        }
    }
}
