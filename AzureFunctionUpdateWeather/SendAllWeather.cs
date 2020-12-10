using AzureFunctionUpdateWeather.Extensions;
using AzureFunctionUpdateWeather.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace AzureFunctionUpdateWeather
{
    internal class SendAllWeather
    {
        private static string minesUrl = Environment.GetEnvironmentVariable("MINE_API_URL");

        public async void SendAllMinesWeather(Dictionary<Guid, WeatherDatum> allWeather)
        {
            foreach (KeyValuePair<Guid, WeatherDatum> entry in allWeather)
            {
                var weatherUpdateForMine = new MineUpdateModel();
                weatherUpdateForMine.Temperature = Convert.ToInt32(Math.Round(entry.Value.Temperature));
                weatherUpdateForMine.Stock = Convert.ToInt32(Math.Round(entry.Value.Clouds));
                weatherUpdateForMine.UpdateType = UpdateType.weather;
                weatherUpdateForMine.Time = DateTime.Now;

                using var client = new HttpClient();

                var response = await client.PatchAsync($"{minesUrl}/api/mine/{entry.Key}", weatherUpdateForMine.ToJsonStringContent());
            }
        }
    }
}