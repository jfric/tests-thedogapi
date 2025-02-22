using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using TestsTechniques.TheDogApi.Api.Services;
using TestsTechniques.TheDogApi.Models.Configuration;

namespace TestsTechniques.TheDogApi.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var callingAssembly = Assembly.GetExecutingAssembly();

            var webProjectServices = callingAssembly.GetExportedTypes()
                .Where(x => x.Namespace is not null 
                    && x.Namespace.Contains("TestsTechniques.TheDogApi.Api.Services")
                    && x.Name.Contains("Service")
                    && !x.IsInterface
                    && !x.IsAbstract);

            foreach (var service in webProjectServices)
            {
                var serviceInterface = service.GetInterfaces().FirstOrDefault(x => x.Name.Contains("Service"));

                if (serviceInterface is not null)
                {
                    services.TryAddTransient(serviceInterface, service);
                }
                else
                {
                    services.TryAddTransient(service);
                }
            }

            return services;
        }
    }
}
