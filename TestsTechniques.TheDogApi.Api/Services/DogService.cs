using CSharpFunctionalExtensions;
using TestsTechniques.TheDogApi.Models.TheDogApi;
using DogApiHttpClient = TestsTechniques.TheDogApi.DogApiClient.DogApiClient;

namespace TestsTechniques.TheDogApi.Api.Services;

public class DogService
{
    private readonly DogApiHttpClient _dogApiHttpClient;
    private readonly ILogger<DogService> _logger;

    public DogService(DogApiHttpClient dogApiHttpClient, 
        ILogger<DogService> logger)
    {
        _dogApiHttpClient = dogApiHttpClient;
        _logger = logger;
    }

    public async Task<Result<List<Breed>>> GetBreeds()
    {
        return await _dogApiHttpClient.GetBreeds();
    }

    public async Task<Maybe<Breed>> GetBreedById(int id)
    {
        return await _dogApiHttpClient.GetBreedById(id);
    }

    public async Task<Result<List<DogImage>>> GetImageRandom()
    {
        return await _dogApiHttpClient.GetBreedImages();
    }

    public async Task<Maybe<DogImage>> GetImageById(string id)
    {
        return await _dogApiHttpClient.GetBreedImageById(id);
    }
}

