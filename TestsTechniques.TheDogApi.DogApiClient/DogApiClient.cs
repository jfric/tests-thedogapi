using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TestsTechniques.TheDogApi.Models.TheDogApi;

namespace TestsTechniques.TheDogApi.DogApiClient
{
    public class DogApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DogApiClient> _logger;

        public DogApiClient(HttpClient httpClient, ILogger<DogApiClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<Breed>> GetBreeds()
        {
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.RequestUri = new Uri("breeds", UriKind.RelativeOrAbsolute);
                    request.Method = new HttpMethod("GET");

                    var response = await _httpClient.SendAsync(request);

                    var statusCode = (int)response.StatusCode;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseText = await response.Content.ReadAsStringAsync();

                        var breeds = JsonConvert.DeserializeObject<List<Breed>>(responseText);

                        if (breeds is not null)
                        {
                            return breeds;
                        }

                        _logger.LogCritical($"{nameof(DogApiClient)}.{nameof(GetBreeds)} => Impossible de désérialiser la réponse");

                        return new List<Breed>();
                    }

                    _logger.LogCritical($"{nameof(DogApiClient)}.{nameof(GetBreeds)} => Problème, réponse avec le status code : {statusCode}");

                    return new List<Breed>();
                }
            } 
            catch (Exception exception)
            {
                _logger.LogCritical(exception, $"{nameof(DogApiClient)}.{nameof(GetBreeds)} => Problème lors de la récupération de la liste de Breeds");
                throw;
            }
        }
    }
}
