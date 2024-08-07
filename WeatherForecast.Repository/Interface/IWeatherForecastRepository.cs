using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Data;

namespace WeatherForecast.Repository.Interface
{
    public interface IWeatherForecastRepository
    {
        Task<WeatherResponse> GetWeatherDataAsync(string location, DateTime date);
    }
}
