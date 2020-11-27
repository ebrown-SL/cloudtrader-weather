using CloudTrader.Weather.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace CloudTrader.Weather.Api.Interfaces
{
    public interface IExternalWeatherService
    {
        Task<WeatherDatum> GetExternalWeather(string city);

        Task<Dictionary<string, WeatherDatum>> GetExternalWeatherForAll(Dictionary<Guid, string> allMinesDictionary);
    }
}
