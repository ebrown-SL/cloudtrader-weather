using Newtonsoft.Json;

namespace CloudTrader.Weather.Api.Models
{
    public class WeatherDatum
    {
        public float Precipitation { get; set; }

        public float Temperature { get; set; }

        public float Clouds { get; set; }

        public float WindSpeed { get; set; }
    }
}