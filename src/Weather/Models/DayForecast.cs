using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Helpers;

namespace Weather.Models
{
    public class DayForecast
    {
        public DayForecast(DataSet darkSkyData)
        {
            Date = darkSkyData.time.UnixTimeStampToDateTime();
            Day = Date.ToString("ddd");
            Climacon = darkSkyData.icon.ConvertToClimaconClasses(); // Run through helper
            Low = Convert.ToInt32(darkSkyData.temperatureMin);
            High = Convert.ToInt32(darkSkyData.temperatureMax);
        }

        public DateTime Date { get; set; }

        public string Day { get; set; }

        public string Climacon { get; set; }

        public double Low { get; set; }

        public double High { get; set; }
    }
}
