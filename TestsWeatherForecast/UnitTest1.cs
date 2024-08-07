using Castle.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using System.Net;
using System.Text.Json;
using WeatherForecast.BusinessLogic;
using WeatherForecast.BusinessLogic.Interface;
using WeatherForecast.Controllers;
using WeatherForecast.Data;
using WeatherForecast.Repository;
using WeatherForecast.Repository.Interface;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace TestsWeatherForecast
{
    public class UnitTest1
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly IWeatherForecastService _weatherForecastService;
 

        public UnitTest1()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();

            var httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://localhost:44367/")
            };
            var inMemorySettings = new Dictionary<string, string> {
            {"ConnectionString", "https://localhost:44367/Weather?"},
        };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            _weatherForecastRepository = new WeatherForecastRepository(httpClient, configuration);
            _weatherForecastService = new WeatherForecastService(_weatherForecastRepository);
        }

        [Fact]
        public async void Test1()
        {
            WeatherForecastController weatherForecastController = new WeatherForecastController(_weatherForecastService);

            var file = File.ReadAllText(@"..\..\..\..\WeatherForecastTests\Data\json1.json");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var responseContent = JsonSerializer.Deserialize<WeatherResponse>(file, options);

            _httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(file)
                });


            var result = await  weatherForecastController.GetWeatherForecastAsync("Bangalore");

            Assert.NotNull(result);
        }


        [Fact]

        public async void TestBadRequest()
        {
            WeatherForecastController weatherForecastController = new WeatherForecastController(_weatherForecastService);
            var result = await weatherForecastController.GetWeatherForecastAsync("");

            var response = result as BadRequestObjectResult;

            Assert.Equal(400,response.StatusCode);
        }
    }
}