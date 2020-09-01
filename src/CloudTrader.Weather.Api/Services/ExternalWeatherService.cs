using CloudTrader.Weather.Api.Helpers;
using CloudTrader.Weather.Api.Interfaces;
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
        public async Task<string> GetExternalWeather()
        {
            using var client = new HttpClient();

            var uri = $"https://api.weatherbit.io/v2.0/current?city=Raleigh,NC&key=f3854cc3edf94e5c8d829d78c8298f3f";

            var response = await client.GetAsync(uri);

            return await response.Content.ReadAsStringAsync();
;        }

    }
}
