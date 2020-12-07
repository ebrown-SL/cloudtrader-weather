using CloudTrader.Weather.Api.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureFunctionUpdateWeather
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task RunAsync([TimerTrigger("0 0 8 * * * ")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var gAM = new GetAllMines();
            log.LogInformation($"Get all the mines");
            var minesDict = await gAM.GetAllMinesDict();

            var gAW = new GetAllWeather();
            log.LogInformation($"Get all the weather");
            var weatherData = await gAW.GetAllWeatherData(minesDict);

            var sAW = new SendAllWeather();
            log.LogInformation($"Send all the weather");
            sAW.SendAllMinesWeather((Dictionary<Guid, InternalWeatherDatum>)weatherData);
        }
    }

    internal static class HttpResponseMessageExtensions
    {
        public static async Task<T> ReadAsJson<T>(this HttpResponseMessage message)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(
                await message.Content.ReadAsStringAsync()
            );
        }
    }
}