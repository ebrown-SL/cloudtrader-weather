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

        [HttpGet("current")]
        /*[SwaggerOperation(
            Summary = "Get all traders",
            Description = "Returns an object containing an array of all traders")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetAllTradersResponseModel))]*/

        public async Task<String> GetWeather()
        {
            var weather = await _externalWeatherService.GetExternalWeather();

            return weather;
        }
    }
}
