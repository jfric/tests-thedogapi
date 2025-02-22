using CSharpFunctionalExtensions;
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

        public async Task<Result<List<Breed>>> GetBreeds()
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
                            return Result.Success(breeds);
                        }

                        _logger.LogCritical($"{nameof(DogApiClient)}.{nameof(GetBreeds)} => Impossible de désérialiser la réponse");

                        return Result.Failure<List<Breed>>($"Impossible de désérialiser la réponse");
                    }

                    _logger.LogCritical($"{nameof(DogApiClient)}.{nameof(GetBreeds)} => Problème, réponse avec le status code : {statusCode}");

                    return Result.Failure<List<Breed>>($"Problème lors de la récupération des breeds => Status Code : {statusCode}");
                }
            } 
            catch (Exception exception)
            {
                _logger.LogCritical(exception, $"{nameof(DogApiClient)}.{nameof(GetBreeds)} => Problème lors de la récupération de la liste de Breeds");

                return Result.Failure<List<Breed>>($"Problème lors de la récupération des breeds : {exception.Message}");
            }
        }

        public async Task<Maybe<Breed>> GetBreedById(int id)
        {
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.RequestUri = new Uri($"breeds/{id}", UriKind.RelativeOrAbsolute);
                    request.Method = new HttpMethod("GET");

                    var response = await _httpClient.SendAsync(request);

                    var statusCode = (int)response.StatusCode;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseText = await response.Content.ReadAsStringAsync();

                        var breed = JsonConvert.DeserializeObject<Breed>(responseText);

                        if (breed is not null)
                        {
                            return breed;
                        }

                        _logger.LogCritical($"{nameof(DogApiClient)}.{nameof(GetBreedById)} => Impossible de désérialiser la réponse");

                        return Maybe<Breed>.None;
                    }

                    _logger.LogCritical($"{nameof(DogApiClient)}.{nameof(GetBreedById)} => Problème, réponse avec le status code : {statusCode}");

                    return Maybe<Breed>.None;
                }
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, $"{nameof(DogApiClient)}.{nameof(GetBreedById)} => Problème lors de la récupération du Breed avec l'id {id}");

                return Maybe<Breed>.None;
            }
        }

        public async Task<Result<List<DogImage>>> GetBreedImages(int limit = 20)
        {
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.RequestUri = new Uri($"images/search?limit={limit}", UriKind.RelativeOrAbsolute);
                    request.Method = new HttpMethod("GET");

                    var response = await _httpClient.SendAsync(request);

                    var statusCode = (int)response.StatusCode;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseText = await response.Content.ReadAsStringAsync();

                        var images = JsonConvert.DeserializeObject<List<DogImage>>(responseText);

                        if (images is not null)
                        {
                            return Result.Success(images);
                        }

                        _logger.LogCritical($"{nameof(DogApiClient)}.{nameof(GetBreedById)} => Impossible de désérialiser la réponse");

                        return Result.Failure<List<DogImage>>("Impossible de désérialiser la réponse");
                    }

                    _logger.LogCritical($"{nameof(DogApiClient)}.{nameof(GetBreedById)} => Problème, réponse avec le status code : {statusCode}");

                    return Result.Failure<List<DogImage>>($"Problème, réponse avec le status code : {statusCode}");
                }
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, $"{nameof(DogApiClient)}.{nameof(GetBreedById)} => Problème lors de la récupération des images");

                return Result.Failure<List<DogImage>>($"Problème lors de la récupération des images : {exception.Message}");
            }
        }

        public async Task<Maybe<DogImage>> GetBreedImageById(string id)
        {
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.RequestUri = new Uri($"images/{id}", UriKind.RelativeOrAbsolute);
                    request.Method = new HttpMethod("GET");

                    var response = await _httpClient.SendAsync(request);

                    var statusCode = (int)response.StatusCode;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseText = await response.Content.ReadAsStringAsync();

                        var image = JsonConvert.DeserializeObject<DogImage>(responseText);

                        if (image is not null)
                        {
                            return image;
                        }

                        _logger.LogCritical($"{nameof(DogApiClient)}.{nameof(GetBreedById)} => Impossible de désérialiser la réponse");

                        return Maybe<DogImage>.None;
                    }

                    _logger.LogCritical($"{nameof(DogApiClient)}.{nameof(GetBreedById)} => Problème, réponse avec le status code : {statusCode}");

                    return Maybe<DogImage>.None;
                }
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, $"{nameof(DogApiClient)}.{nameof(GetBreedById)} => Problème lors de la récupération des images");

                return Maybe<DogImage>.None;
            }
        }
    }
}
