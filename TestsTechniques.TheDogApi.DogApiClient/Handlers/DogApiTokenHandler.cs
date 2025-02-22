using Microsoft.Extensions.Options;
using TestsTechniques.TheDogApi.Models.Configuration;

namespace TestsTechniques.TheDogApi.DogApiClient.Handlers
{
    public class DogApiTokenHandler : DelegatingHandler
    {
        private readonly TheDogApiConfiguration _dogApiConfiguration;

        public DogApiTokenHandler(IOptions<TheDogApiConfiguration> dogApiConfiguration)
        {
            _dogApiConfiguration = dogApiConfiguration.Value;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("x-api-key", _dogApiConfiguration.ApiKey);

            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }
}
