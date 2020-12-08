using CloudTrader.Weather.Api.Helpers;
using CloudTrader.Weather.Api.Interfaces;
using CloudTrader.Weather.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace CloudTrader.Weather.Api.Services
{
    public class ExternalWeatherService : IExternalWeatherService
    {
        private string weatherbitURL = "https://api.weatherbit.io/v2.0";
        private string apiKey = "f3854cc3edf94e5c8d829d78c8298f3f";

        public async Task<Models.WeatherDatum> GetExternalWeather(string city)
        {
            using var client = new HttpClient();

            var uri = $"{weatherbitURL}/current?city={city},GB&key={apiKey}";

            var response = await client.GetAsync(uri);

            return (await response.ReadAsJson<WeatherData>()).data[0]?.ToModel() ?? throw new Exception("No weather data found");
        }

        public async Task<Dictionary<string, Models.WeatherDatum>> GetExternalWeatherForAll(Dictionary<string, string> allMinesDictionary)
        {
            Dictionary<string, string> reversedMinesDictionary = allMinesDictionary.ToDictionary((i) => i.Value, (i) => i.Key);

            string[] mineCities = allMinesDictionary.Values.ToArray();
            return (await Task.WhenAll(
                mineCities.Select(async city =>
                    new {
                        cityName = city,
                        weather = await GetExternalWeather(city)
                    }
                )
            )).ToDictionary(
                x => reversedMinesDictionary[x.cityName],
                x => x.weather
            );
        }

        private class WeatherData
        {
            public WeatherDatum[] data { get; set; }
        }

        private class WeatherDatum
        {
            public float precip { get; set; }

            public float temp { get; set; }

            public float clouds { get; set; }

            public float wind_spd { get; set; }

            public Models.WeatherDatum ToModel() => new Models.WeatherDatum {
                    Clouds = clouds,
                    Precipitation = precip,
                    Temperature = temp,
                    WindSpeed = wind_spd
            };
        }
    }
}