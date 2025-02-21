using Microsoft.AspNetCore.Mvc;

namespace TestsTechniques.TheDogApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogController : ControllerBase
    {
        private readonly ILogger<DogController> _logger;
        private readonly HttpClient _httpClient;

        public DogController(ILogger<DogController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
        }

        // GET /dog/breeds
        public async Task<IActionResult> GetBreeds()
        {
            return Ok();
        }

        // GET /dog/breeds/{id}
        public async Task<IActionResult> GetBreedById()
        {
            return Ok();
        }

        // GET /dog/images/random
        public async Task<IActionResult> GetRandomDogImage()
        {
            return Ok();
        }

        // GET /dog/images/{id}
        public async Task<IActionResult> GetDogImage()
        {
            return Ok();
        }
    }
}
