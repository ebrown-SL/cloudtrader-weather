using CloudTrader.Weather.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudTrader.Weather.Api.Interfaces
{
    public interface IExternalWeatherService
    {
        Task<WeatherDatum> GetExternalWeather(string city);

        Task<Dictionary<string, WeatherDatum>> GetExternalWeatherForAll();
    }
}