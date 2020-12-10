using AzureFunctionUpdateWeather.Extensions;
using AzureFunctionUpdateWeather.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureFunctionUpdateWeather
{
    public class GetAllWeather
    {
        private static string weatherUrl = Environment.GetEnvironmentVariable("WEATHER_API_URL");

        public async Task<IReadOnlyDictionary<Guid, WeatherDatum>> GetAllWeatherData(IReadOnlyDictionary<string, string> allMinesDictionary)
        {
            using var client = new HttpClient();

            var response = await client.PostAsync($"{weatherUrl}/externalweather/all/current/", allMinesDictionary.ToJsonStringContent());

            return await response.ReadAsJson<Dictionary<Guid, WeatherDatum>>();
        }
    }
}