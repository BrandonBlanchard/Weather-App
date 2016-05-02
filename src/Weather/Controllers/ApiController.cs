using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Weather.Interfaces;
using Weather.Services;
using Weather.Models;

namespace Weather.Controllers
{
    public class ApiController : Controller
    {
        private IForecastService _forecastService;

        public ApiController()
        {
            _forecastService = new ForecastService();
        }

        public ForecastModel GetForecastForThisWeek(string coordinates)
        {
            string placeholderLocation = "47.734145,-122.2359031";

            ForecastModel model = _forecastService.GetForecast(placeholderLocation);

            return model;
        }
    }
}
