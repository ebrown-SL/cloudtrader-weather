using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTrader.Weather.Api.Models
{
    public class WeatherData
    {
        public WeatherDatum[] data { get; set; }
    }

    public class WeatherDatum
    {
        [JsonProperty("precip")]
        public string Precipitation { get; set; }
        [JsonProperty("temp")]
        public string Temperature { get; set; }
        [JsonProperty("clouds")]
        public string Clouds { get; set; }
        [JsonProperty("wind_spd")]
        public string WindSpeed { get; set; }
        [JsonProperty("city_name")]
        public string CityName { get; set; }
    }

    public class AllWeatherData
    {
        public WeatherDatum[] processedWeatherData { get; set; }
    }
}

