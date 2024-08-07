using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Data
{
    public class WeatherMain
    {
        public double Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Visibility { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
        public string Description { get; set; }
    }
}
