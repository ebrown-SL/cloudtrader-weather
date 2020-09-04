using CloudTrader.Weather.Api.Interfaces;
using CloudTrader.Weather.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudTrader.Weather.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExternalWeatherController : ControllerBase
    {
        private readonly IExternalWeatherService _externalWeatherService;

        public ExternalWeatherController(IExternalWeatherService externalWeatherService)
        {
            _externalWeatherService = externalWeatherService;
        }

        [HttpGet("{city}/current")]
        [SwaggerOperation(
            Summary = "Get weather for city",
            Description = "Returns an object containing the relevant weather data for a specific city")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(WeatherDatum))]
        public async Task<IActionResult> GetWeatherForCity(string city)
        {
            var weather = await _externalWeatherService.GetExternalWeather(city);

            return Ok(weather);
        }

        [HttpGet("all/current")]
        [SwaggerOperation(
            Summary = "Get weather for all cities",
            Description = "Returns an object with a key-value pair for each city: key = city name; value = weather data object for city")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(Dictionary<string, WeatherDatum>))]
        public async Task<IActionResult> GetWeatherForAll()
        {
            var weather = await _externalWeatherService.GetExternalWeatherForAll();

            return Ok(weather);
        }
    }
}
