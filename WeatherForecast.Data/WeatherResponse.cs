namespace WeatherForecast.Data
{
    public class WeatherResponse
    {
        public WeatherMain Main { get; set; }
        public WeatherWind Wind { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string DataValidUntil { get; set; }
    }
}
