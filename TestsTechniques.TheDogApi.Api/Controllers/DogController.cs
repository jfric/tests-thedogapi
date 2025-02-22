using Microsoft.AspNetCore.Mvc;
using TestsTechniques.TheDogApi.Api.Services;

namespace TestsTechniques.TheDogApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogController : ControllerBase
    {
        private readonly ILogger<DogController> _logger;
        private readonly DogService _dogService;

        public DogController(ILogger<DogController> logger, DogService dogService)
        {
            _logger = logger;
            _dogService = dogService;
        }

        // GET /dog/breeds
        [HttpGet]
        [Route("/dog/breeds")]
        public async Task<IActionResult> GetBreeds()
        {
            var breeds = await _dogService.GetBreeds();

            if (breeds.IsFailure)
            {
                return NotFound(breeds.Error);
            }

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
                _logger.LogError($"{nameof(DogController)}.{nameof(GetBreedById)} => Erreur lors la récupération du Breed {id}");

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
                _logger.LogError($"{nameof(DogController)}.{nameof(GetRandomDogImages)} => Erreur lors la récupération de la liste random de Breeds");

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
                return NotFound();
            }

            return Ok(image.Value);
        }
    }
}
