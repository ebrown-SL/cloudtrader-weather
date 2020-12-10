using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AzureFunctionUpdateWeather.Models
{
    public class MineUpdateModel
    {
        public double? Temperature { get; set; }

        [Range(0, int.MaxValue)]
        public int? Stock { get; set; }

        public string? Name { get; set; }

        public UpdateType UpdateType
        {
            get => updateType;
            set
            {
                if (!(value == UpdateType.trade || value == UpdateType.weather))
                {
                    throw new System.ArgumentException("UpdateType is invalid");
                }
                else
                {
                    updateType = value;
                }
            }
        }

        private UpdateType updateType;

        public DateTime Time { get; set; }
    }
}
