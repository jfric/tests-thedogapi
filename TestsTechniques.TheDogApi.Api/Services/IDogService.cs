using CSharpFunctionalExtensions;
using TestsTechniques.TheDogApi.Models.TheDogApi;

namespace TestsTechniques.TheDogApi.Api.Services
{
    public interface IDogService
    {
        Task<Maybe<Breed>> GetBreedById(int id);
        Task<Result<List<Breed>>> GetBreeds();
        Task<Maybe<DogImage>> GetImageById(string id);
        Task<Result<List<DogImage>>> GetImageRandom();
    }
}