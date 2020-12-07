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

    public class InternalWeatherDatum
    {
        [JsonProperty("Precipitation")]
        public float Precipitation { get; set; }

        [JsonProperty("Temperature")]
        public float Temperature { get; set; }

        [JsonProperty("Clouds")]
        public float Clouds { get; set; }

        [JsonProperty("WindSpeed")]
        public float WindSpeed { get; set; }
    }
}