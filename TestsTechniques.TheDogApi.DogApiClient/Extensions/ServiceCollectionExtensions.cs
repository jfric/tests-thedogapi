using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TestsTechniques.TheDogApi.DogApiClient.Handlers;
using TestsTechniques.TheDogApi.Models.Configuration;

namespace TestsTechniques.TheDogApi.DogApiClient.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDogApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            if (!services.Any(x => x.ServiceType == typeof(DogApiClient)))
            {
                if (string.IsNullOrWhiteSpace(configuration["DogApi:BaseUrl"]))
                {
                    throw new NullReferenceException("L'URL de l'API Dog n'est pas renseignée");
                }

                services.Configure<TheDogApiConfiguration>(configuration.GetSection(TheDogApiConfiguration.DogApiConfiguration));

                services.TryAddTransient<DogApiTokenHandler>();

                services.AddHttpClient<DogApiClient>(x =>
                {
                    x.BaseAddress = new Uri(configuration["DogApi:BaseUrl"]!);
                    x.Timeout = new TimeSpan(0, 0, 0, 15);
                }).AddHttpMessageHandler<DogApiTokenHandler>();
            }

            return services;
        }
    }
}
