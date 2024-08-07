using WeatherForecast.BusinessLogic.Interface;
using WeatherForecast.Data;
using WeatherForecast.Repository.Interface;

namespace WeatherForecast.BusinessLogic
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task<IEnumerable<WeatherResponse>> GetWeatherForecastAsync(string location)
        {
            try
            {
                var forecast = new List<WeatherResponse>();
                var tasks = new List<Task<WeatherResponse>>();

                for (int i = 0; i < 365; i++)
                {
                    var date = DateTime.UtcNow.AddDays(i);
                    tasks.Add(_weatherRepository.GetWeatherDataAsync(location, date));
                }

                var results = await Task.WhenAll(tasks);
                forecast.AddRange(results);

                return forecast;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
