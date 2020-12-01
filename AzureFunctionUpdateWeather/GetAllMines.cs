using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace AzureFunctionUpdateWeather
{
    class GetAllMines
    {
        public async Task<IReadOnlyDictionary<string, string>> GetAllMinesDict()
        {
            using var client = new HttpClient();
            // var uri = "https://cloudtrader.ukwest.cloudapp.azure.com/api/mine/";
            var uri = "http://localhost:1189/api/mine/";

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("Accept", "application/vnd.scottlogic.cloudtrader.minelookup+json");

            var response = await client.SendAsync(request);

            Console.WriteLine(response);

            return await response.ReadAsJson<Dictionary<string, string>>();

        }
    }
}
