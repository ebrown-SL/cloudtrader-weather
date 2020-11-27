using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using CloudTrader.Weather.Api.Models;

namespace AzureFunctionUpdateWeather
{
    public class GetAllWeather
    {
        public async Task<Dictionary<string, WeatherDatum>> GetAllWeatherData()
        {
            using var client = new HttpClient();

            // var uri = "https://cloudtrader.ukwest.cloudapp.azure.com/externalweather/all/current"
            var uri = "http://localhost:5888/externalweather/all/current";

            var response = await client.GetAsync(uri);

            return await response.ReadAsJson<Dictionary<string, WeatherDatum>>();
        }
    }
}
