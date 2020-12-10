using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTrader.Weather.Api.Models
{
    public class MineListResponse
    {
        public IEnumerable<Mine> Mines { get; set; }
    }
}
