using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTrader.Weather.Api.Models
{
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
}
