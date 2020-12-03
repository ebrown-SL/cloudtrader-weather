using CloudTrader.Weather;
using CloudTrader.Weather.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace AzureFunctionUpdateWeather
{
    internal class SendAllWeather
    {
        public async void SendAllMinesWeather(Dictionary<Guid, WeatherDatum> allWeather)
        {
            foreach (KeyValuePair<Guid, WeatherDatum> entry in allWeather)
            {
                var weatherUpdateForMine = new MineUpdateModel();
                weatherUpdateForMine.Temperature = Convert.ToInt32(Math.Round(entry.Value.Temperature));
                Console.WriteLine(Convert.ToInt32(Math.Round(entry.Value.Temperature)));
                weatherUpdateForMine.Stock = Convert.ToInt32(Math.Round(entry.Value.Clouds));
                weatherUpdateForMine.UpdateType = UpdateType.weather;
                weatherUpdateForMine.Time = DateTime.Now;

                using var client = new HttpClient();

                // var uri = "http://localhost:1189/api/mine/" + entry.Key.ToString();
                var uri = "http://localhost:1189/api/mine/" + entry.Key.ToString();

                var response = await client.PatchAsync(uri, weatherUpdateForMine.ToJsonStringContent()); ;
            }
        }
    }

#nullable enable

    public class MineUpdateModel
    {
        public double? Temperature { get; set; }

        [Range(0, int.MaxValue)]
        public int? Stock { get; set; }

        public string? Name { get; set; }

        public UpdateType UpdateType
        {
            get => updateType;
            set
            {
                if (!(value == UpdateType.trade || value == UpdateType.weather))
                {
                    throw new System.ArgumentException("UpdateType is invalid");
                }
                else
                {
                    updateType = value;
                }
            }
        }

        private UpdateType updateType;

        public DateTime Time { get; set; }
    }

#nullable restore

    public enum UpdateType { None, trade, weather }
}