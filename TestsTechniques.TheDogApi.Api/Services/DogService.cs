using CSharpFunctionalExtensions;
using TestsTechniques.TheDogApi.DogApiClient;
using TestsTechniques.TheDogApi.Models.TheDogApi;

namespace TestsTechniques.TheDogApi.Api.Services;

public class DogService : IDogService
{
    private readonly IDogApiClient _dogApiHttpClient;
    private readonly ILogger<DogService> _logger;

    public DogService(IDogApiClient dogApiHttpClient,
        ILogger<DogService> logger)
    {
        _dogApiHttpClient = dogApiHttpClient;
        _logger = logger;
    }

    public async Task<Result<List<Breed>>> GetBreeds()
    {
        _logger.LogDebug($"{nameof(DogService)}.{nameof(GetBreeds)} => Début méthode du service");

        var breeds = await _dogApiHttpClient.GetBreeds();

        _logger.LogDebug($"{nameof(DogService)}.{nameof(GetBreeds)} => Fin méthode du service");

        return breeds;
    }

    public async Task<Maybe<Breed>> GetBreedById(int id)
    {
        _logger.LogDebug($"{nameof(DogService)}.{nameof(GetBreedById)} => Début méthode du service");

        var breed = await _dogApiHttpClient.GetBreedById(id);

        _logger.LogDebug($"{nameof(DogService)}.{nameof(GetBreedById)} => Fin méthode du service");

        return breed;
    }

    public async Task<Result<List<DogImage>>> GetImageRandom()
    {
        _logger.LogDebug($"{nameof(DogService)}.{nameof(GetImageRandom)} => Début méthode du service");

        var images = await _dogApiHttpClient.GetBreedImages();

        _logger.LogDebug($"{nameof(DogService)}.{nameof(GetImageRandom)} => Fin méthode du service");

        return images;
    }

    public async Task<Maybe<DogImage>> GetImageById(string id)
    {
        _logger.LogDebug($"{nameof(DogService)}.{nameof(GetImageById)} => Début méthode du service");

        var image = await _dogApiHttpClient.GetBreedImageById(id);

        _logger.LogDebug($"{nameof(DogService)}.{nameof(GetImageById)} => Fin méthode du service");

        return image;
    }
}

