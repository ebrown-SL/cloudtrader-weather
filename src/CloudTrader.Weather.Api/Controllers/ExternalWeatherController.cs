using CloudTrader.Weather.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /*[SwaggerOperation(
            Summary = "Get all traders",
            Description = "Returns an object containing an array of all traders")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetAllTradersResponseModel))]*/

        public async Task<IActionResult> GetWeatherForCity(string city)
        {
            var weather = await _externalWeatherService.GetExternalWeather(city);

            return Ok(weather);
        }

        [HttpGet("all/current")]
        /*[SwaggerOperation(
            Summary = "Get all traders",
            Description = "Returns an object containing an array of all traders")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetAllTradersResponseModel))]*/

        public async Task<IActionResult> GetWeatherForAll()
        {
            var weather = await _externalWeatherService.GetExternalWeatherForAll();

            return Ok(weather);
        }
    }
}
