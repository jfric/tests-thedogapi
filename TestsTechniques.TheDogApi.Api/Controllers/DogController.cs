using Microsoft.AspNetCore.Mvc;
using TestsTechniques.TheDogApi.Api.Services;

namespace TestsTechniques.TheDogApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogController : ControllerBase
    {
        private readonly ILogger<DogController> _logger;
        private readonly IDogService _dogService;

        public DogController(ILogger<DogController> logger, 
            IDogService dogService)
        {
            _logger = logger;
            _dogService = dogService;
        }

        // GET /dog/breeds
        [HttpGet]
        [Route("/dog/breeds")]
        public async Task<IActionResult> GetBreeds()
        {
            _logger.LogDebug($"{nameof(DogController)}.{nameof(GetBreeds)} => Début méthode controller");

            var breeds = await _dogService.GetBreeds();

            if (breeds.IsFailure)
            {
                _logger.LogCritical($"{nameof(DogController)}.{nameof(GetBreeds)} => Fin méthode controller : Failure");

                return NotFound(breeds.Error);
            }

            _logger.LogDebug($"{nameof(DogController)}.{nameof(GetBreeds)} => Fin méthode controller : Success");

            return Ok(breeds.Value);
        }

        // GET /dog/breeds/{id}
        [HttpGet]
        [Route("/dog/breeds/{id}")]
        public async Task<IActionResult> GetBreedById(int id)
        {
            var breed = await _dogService.GetBreedById(id);

            if (breed.HasNoValue)
            {
                _logger.LogCritical($"{nameof(DogController)}.{nameof(GetBreedById)} => Erreur lors la récupération du Breed {id}");

                return NotFound();
            }

            return Ok(breed.Value);
        }

        // GET /dog/images/random
        [HttpGet]
        [Route("/dog/images/random")]
        public async Task<IActionResult> GetRandomDogImages()
        {
            var randomDogImage = await _dogService.GetImageRandom();

            if (randomDogImage.IsFailure)
            {
                _logger.LogCritical($"{nameof(DogController)}.{nameof(GetRandomDogImages)} => Erreur lors la récupération de la liste random de Breeds");

                return NotFound();
            }

            return Ok(randomDogImage.Value);
        }

        // GET /dog/images/{id}
        [HttpGet]
        [Route("/dog/images/{id}")]
        public async Task<IActionResult> GetDogImage(string id)
        {
            var image = await _dogService.GetImageById(id);

            if (image.HasNoValue)
            {
                _logger.LogCritical($"{nameof(DogController)}.{nameof(GetDogImage)} => Erreur lors la récupération de l'image {id}");

                return NotFound();
            }

            return Ok(image.Value);
        }
    }
}
