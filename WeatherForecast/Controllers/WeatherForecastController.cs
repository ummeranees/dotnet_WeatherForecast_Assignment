using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherForecast.BusinessLogic.Interface;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherForecastAsync([FromQuery] string location)
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                if (string.IsNullOrEmpty(location))
                {
                    return BadRequest("Location must be provided.");
                }
                stopwatch.Start();
                var weatherForecast = await _weatherForecastService.GetWeatherForecastAsync(location);



                stopwatch.Stop();

                if (weatherForecast == null)
                    return NotFound();

                return Ok(new { Payload = weatherForecast ,TimeElapsed = stopwatch.Elapsed});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An internal server error occurred. Please try again later.",
                    StackTrace = ex.StackTrace
                });
            }
        }
    }
}
