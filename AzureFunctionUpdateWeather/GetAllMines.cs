using AzureFunctionUpdateWeather.Extensions;
using AzureFunctionUpdateWeather.Models;
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
        private static string minesUrl = Environment.GetEnvironmentVariable("MINE_API_URL");

        public async Task<IReadOnlyDictionary<string, string>> GetAllMinesDict()
        {
            using var client = new HttpClient();

            var response = await client.GetAsync($"{minesUrl}/api/mine/");

            var mines = await response.ReadAsJson<MineListResponse>();

            return mines.Mines.ToDictionary(x => x.Id.ToString(), x => x.Name);
        }
    }
}

