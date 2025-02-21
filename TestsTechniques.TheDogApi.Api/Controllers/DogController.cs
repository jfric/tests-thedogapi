using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DogApiHttpClient = TestsTechniques.TheDogApi.DogApiClient.DogApiClient;

namespace TestsTechniques.TheDogApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogController : ControllerBase
    {
        private readonly ILogger<DogController> _logger;
        private readonly DogApiHttpClient _dogApiClient;

        public DogController(ILogger<DogController> logger, DogApiHttpClient dogApiClient)
        {
            _logger = logger;
            _dogApiClient = dogApiClient;
        }

        // GET /dog/breeds
        [Route("/dog/breeds")]
        [SwaggerOperation(Description = "Récupère la liste des breeds")]
        public async Task<IActionResult> GetBreeds()
        {
            var breeds = await _dogApiClient.GetBreeds();

            return Ok(breeds);
        }

        // GET /dog/breeds/{id}
        [Route("/dog/breeds/{id}")]
        [SwaggerOperation(
            Description = "Récupère un breed par son id",
            OperationId = "GetBreedById",
            Tags = new[] { "Breed" }
        )]
        public async Task<IActionResult> GetBreedById(int id)
        {
            return Ok();
        }

        // GET /dog/images/random
        [Route("/dog/images/random")]
        [SwaggerOperation(
            Description = "Récupère une image d'un breed au hasard",
            OperationId = "GetRandomDogImage",
            Tags = new[] { "Images" }
        )]
        public async Task<IActionResult> GetRandomDogImage()
        {
            return Ok();
        }

        // GET /dog/images/{id}
        [Route("/dog/images/{id}")]
        [SwaggerOperation(
            Description = "Récupère l'image d'un breed par son imageId",
            OperationId = "GetDogImage", 
            Tags = new[] { "Images" }
        )]
        public async Task<IActionResult> GetDogImage(int id)
        {
            return Ok();
        }
    }
}
