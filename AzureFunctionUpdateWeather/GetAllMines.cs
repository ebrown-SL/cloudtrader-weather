using CloudTrader.Weather.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureFunctionUpdateWeather
{
    internal class GetAllMines
    {
        public async Task<IReadOnlyDictionary<string, string>> GetAllMinesDict()
        {
            using var client = new HttpClient();
            // var uri = "https://cloudtrader.ukwest.cloudapp.azure.com/api/mine/";
            var uri = "http://localhost:1189/api/mine/";

            var response = await client.GetAsync(uri);

            var mines = await response.ReadAsJson<MineListResponse>();

            return mines.Mines.ToDictionary(x => x.Id.ToString(), x => x.Name);
        }
    }
}

