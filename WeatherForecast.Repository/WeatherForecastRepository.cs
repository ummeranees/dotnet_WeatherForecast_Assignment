using Microsoft.Extensions.Configuration;
using System.Text.Json;
using WeatherForecast.Data;
using WeatherForecast.Repository.Interface;

namespace WeatherForecast.Repository
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherForecastRepository(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<WeatherResponse> GetWeatherDataAsync(string location, DateTime date)
        {
            try
            {
                string url = _configuration["ConnectionString"] + $"location={location}&date={date:yyyy-MM-dd}";
                var response = await _httpClient.GetAsync($"https://localhost:44367/Weather?location={location}&date={date:yyyy-MM-dd}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                return JsonSerializer.Deserialize<WeatherResponse>(content,options);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
