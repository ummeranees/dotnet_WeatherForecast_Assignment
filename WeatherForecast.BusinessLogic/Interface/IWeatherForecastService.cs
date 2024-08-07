using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Data;

namespace WeatherForecast.BusinessLogic.Interface
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherResponse>> GetWeatherForecastAsync(string location);
    }
}
