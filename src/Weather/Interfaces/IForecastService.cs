using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Interfaces
{
    public interface IForecastService
    {
        ForecastModel GetForecast(string location);
    }
}
