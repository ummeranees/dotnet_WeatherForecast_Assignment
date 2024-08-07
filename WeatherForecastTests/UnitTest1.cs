using System.Text.Json;
using WeatherForecast.Data;

namespace WeatherForecastTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //var js = "{\"main\":{\"temp\":284.21,\"pressure\":1012,\"humidity\":35,\"tempMin\":287.29,\"tempMax\":284.43,\"visibility\":5853,\"sunrise\":1722891090,\"sunset\":1722934290,\"description\":\"clear sky\"},\"wind\":{\"speed\":4.2,\"deg\":315},\"location\":\"bbn\",\"date\":\"2024-08-05\",\"dataValidUntil\":\"2024-08-05T22:51:30.3946527Z\"}";
            var fil = File.ReadAllText(@"..\..\..\..\WeatherForecastTests\Data\json1.json");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var r = JsonSerializer.Deserialize<WeatherResponse>(fil, options);

            var json = @"{
            ""wind"": {
                ""speed"": 4.20,
                ""deg"": 315
            }
        }";
            //var options = new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true
            //};
            var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(json, options);
            // Deserialize JSON
            //var windData = JsonSerializer.Deserialize<WindData>(json);




        }
    }

    //public class WeatherResponse
    //{
    //    public WindData Wind { get; set; }
    //}

    //public class WindData
    //{
    //    public double Speed { get; set; }
    //    public int Deg { get; set; }
    //}
}