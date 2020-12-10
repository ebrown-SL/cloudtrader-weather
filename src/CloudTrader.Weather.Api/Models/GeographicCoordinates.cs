﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTrader.Weather.Api.Models
{
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
}
