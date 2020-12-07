using CloudTrader.Weather;
using CloudTrader.Weather.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureFunctionUpdateWeather
{
    public class GetAllWeather
    {
        public async Task<IReadOnlyDictionary<Guid, InternalWeatherDatum>> GetAllWeatherData(IReadOnlyDictionary<string, string> allMinesDictionary)
        {
            using var client = new HttpClient();

            // var uri = "https://cloudtrader.ukwest.cloudapp.azure.com/externalweather/all/current"
            var uri = "http://localhost:5888/externalweather/all/current";

            var response = await client.PostAsync(uri, allMinesDictionary.ToJsonStringContent());

            var body = await response.Content.ReadAsStringAsync();

            return await response.ReadAsJson<Dictionary<Guid, InternalWeatherDatum>>();
        }
    }
}