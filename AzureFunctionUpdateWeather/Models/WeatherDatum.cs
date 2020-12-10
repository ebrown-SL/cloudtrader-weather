using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionUpdateWeather.Models
{
    public class WeatherDatum
    {
        public float Precipitation { get; set; }

        public float Temperature { get; set; }

        public float Clouds { get; set; }

        public float WindSpeed { get; set; }
    }
}
