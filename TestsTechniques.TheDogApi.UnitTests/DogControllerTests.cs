using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using System.Net.Http.Json;
using TestsTechniques.TheDogApi.Api.Controllers;
using TestsTechniques.TheDogApi.Models.TheDogApi;

namespace TestsTechniques.TheDogApi.UnitTests
{
    public class DogControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public DogControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    Mock<ILogger<DogController>> loggerMock = new Mock<ILogger<DogController>>();
                    services.AddSingleton(loggerMock.Object);
                });
            });
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetBreeds_ReturnsOk()
        {
            HttpResponseMessage response = await _client.GetAsync("/dog/breeds");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            List<Breed>? breeds = await response.Content.ReadFromJsonAsync<List<Breed>>();
            Assert.NotNull(breeds);
            Assert.NotEmpty(breeds);
        }

        [Fact]
        public async Task GetBreedById_ReturnsOk()
        {
            HttpResponseMessage response = await _client.GetAsync("/dog/breeds/1");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Breed? breed = await response.Content.ReadFromJsonAsync<Breed>();
            Assert.NotNull(breed);
            Assert.Equal(1, breed.Id);
        }

        [Fact]
        public async Task GetRandomDogImage_ReturnsOk()
        {
            HttpResponseMessage response = await _client.GetAsync("/dog/images/random");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            List<DogImage>? images = await response.Content.ReadFromJsonAsync<List<DogImage>>();
            Assert.NotNull(images);
            Assert.NotEmpty(images);
        }

        [Fact]
        public async Task GetDogImageById_ReturnsOk()
        {
            HttpResponseMessage response = await _client.GetAsync("/dog/images/random");
            response.EnsureSuccessStatusCode();
            List<DogImage>? images = await response.Content.ReadFromJsonAsync<List<DogImage>>();
            string imageId = images.First().Id;

            HttpResponseMessage imageResponse = await _client.GetAsync($"/dog/images/{imageId}");
            imageResponse.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, imageResponse.StatusCode);

            DogImage? image = await imageResponse.Content.ReadFromJsonAsync<DogImage>();
            Assert.NotNull(image);
            Assert.Equal(imageId, image.Id);
        }
    }
}
