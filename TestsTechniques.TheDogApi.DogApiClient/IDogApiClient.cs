using CSharpFunctionalExtensions;
using TestsTechniques.TheDogApi.Models.TheDogApi;

namespace TestsTechniques.TheDogApi.DogApiClient
{
    public interface IDogApiClient
    {
        Task<Maybe<Breed>> GetBreedById(int id);
        Task<Maybe<DogImage>> GetBreedImageById(string id);
        Task<Result<List<DogImage>>> GetBreedImages(int limit = 10, int page = 0);
        Task<Result<List<Breed>>> GetBreeds(int limit = 10, int page = 0);
    }
}