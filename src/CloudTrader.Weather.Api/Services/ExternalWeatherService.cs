using CloudTrader.Weather.Api.Helpers;
using CloudTrader.Weather.Api.Interfaces;
using CloudTrader.Weather.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudTrader.Weather.Api.Services
{
    public class ExternalWeatherService : IExternalWeatherService
    {
        string weatherbitURL = "https://api.weatherbit.io/v2.0";
        string apiKey = "f3854cc3edf94e5c8d829d78c8298f3f";

        public async Task<WeatherDatum> GetExternalWeather(string city)
        {
            using var client = new HttpClient();

            var uri = $"{weatherbitURL}/current?city={city},GB&key={apiKey}";

            var response = await client.GetAsync(uri);

            Console.WriteLine(uri);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return (await response.ReadAsJson<WeatherData>()).data[0];
;        }

    }
}
