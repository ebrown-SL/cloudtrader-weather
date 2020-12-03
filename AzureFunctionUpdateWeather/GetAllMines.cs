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

public class MineListResponse
{
    public IEnumerable<Mine> Mines { get; set; }
}

public class Mine
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public GeographicCoordinates Coordinates { get; set; }

    [Required]
    public double Temperature { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    [Required]
    public string Name { get; set; }
}

public class GeographicCoordinates
{
    [Required]
    public double? Latitude { get; set; }

    [Required]
    public double? Longitude { get; set; }

    public GeographicCoordinates()
    {
    }

    public GeographicCoordinates(double? latitude, double? longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}