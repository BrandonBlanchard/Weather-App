using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Models
{
    public class ForecastModel
    {
        public ForecastModel(DarkSkyWeeklyForecast model)
        {
            List<DayForecast> daily = new List<DayForecast>();

            foreach (DataSet darkSkyDay in model.daily.data)
            {
                DayForecast day = new DayForecast(darkSkyDay);
                daily.Add(day);
            }

            Forecast = daily.OrderBy(day => day.Date);
        }

        public IEnumerable<DayForecast> Forecast { get; set; }
    }
}
