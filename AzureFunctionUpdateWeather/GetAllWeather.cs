using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using CloudTrader.Weather.Api.Models;
using CloudTrader.Weather.Api.Helpers;
using CloudTrader.Weather;

namespace AzureFunctionUpdateWeather
{
    public class GetAllWeather
    {
        public async Task<IReadOnlyDictionary<Guid, WeatherDatum>> GetAllWeatherData(IReadOnlyDictionary<string, string> allMinesDictionary)
        {
            using var client = new HttpClient();

            // var uri = "https://cloudtrader.ukwest.cloudapp.azure.com/externalweather/all/current"
            var uri = "http://localhost:5888/externalweather/all/current";

            var response = await client.PostAsync(uri, allMinesDictionary.ToJsonStringContent());

            return await response.ReadAsJson<Dictionary<Guid, WeatherDatum>>();
        }
    }
}
