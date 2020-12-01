using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using CloudTrader.Weather.Api.Models;

namespace AzureFunctionUpdateWeather
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task RunAsync([TimerTrigger("0 56 * * * * ")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            // Get the dictionary of all mines
            var gAM = new GetAllMines();
            log.LogInformation($"Get all the mines");
            var minesDict = await gAM.GetAllMinesDict();

            var gAW = new GetAllWeather();
            log.LogInformation($"Get all the weather");

            log.LogInformation($"{await gAW.GetAllWeatherData(minesDict)}");
        }
    }

    static class HttpResponseMessageExtensions
    {
        public static async Task<T> ReadAsJson<T>(this HttpResponseMessage message)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(
                await message.Content.ReadAsStringAsync()
            );
        }
    }
}
