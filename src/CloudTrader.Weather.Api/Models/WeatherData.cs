using Newtonsoft.Json;

namespace CloudTrader.Weather.Api.Models
{
    public class WeatherData
    {
        public WeatherDatum[] data { get; set; }
    }

    public class WeatherDatum
    {
        [JsonProperty("precip")]
        public float Precipitation { get; set; }

        [JsonProperty("temp")]
        public float Temperature { get; set; }

        [JsonProperty("clouds")]
        public float Clouds { get; set; }

        [JsonProperty("wind_spd")]
        public float WindSpeed { get; set; }
    }

    public class AllWeatherData
    {
        public WeatherDatum[] processedWeatherData { get; set; }
    }
}