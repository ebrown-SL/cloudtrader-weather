using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionUpdateWeather.Models
{
    public class MineListResponse
    {
        public IEnumerable<Mine> Mines { get; set; }
    }
}
