using Microsoft.Extensions.DependencyInjection.Extensions;
using TestsTechniques.TheDogApi.Api.Services;
using TestsTechniques.TheDogApi.Models.Configuration;

namespace TestsTechniques.TheDogApi.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.TryAddTransient<DogService>();

            return services;
        }
    }
}
