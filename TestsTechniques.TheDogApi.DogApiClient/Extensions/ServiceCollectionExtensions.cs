using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsTechniques.TheDogApi.DogApiClient.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDogApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            if (string.IsNullOrWhiteSpace(configuration["DogApi:BaseUrl"]))
            {
                throw new NullReferenceException("L'URL de l'API Dog n'est pas renseignée");
            }

            services.AddHttpClient<DogApiClient>(x =>
            {
                x.BaseAddress = new Uri(configuration["DogApi:BaseUrl"]!);
            });

            return services;
        }
    }
}
