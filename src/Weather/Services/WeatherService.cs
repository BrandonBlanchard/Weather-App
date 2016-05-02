using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Weather.Interfaces;
using Weather.Models;

namespace Weather.Services
{
    public class ForecastService : IForecastService
    {
        private string apiKey = "6f31c64b94e447bfb1e2b7a40bd44751";
        private string endpoint = "https://api.forecast.io/";
        private string dataExcludes = "exclude=currently,hourly,minutely,flags,alerts";
        private string path = "forecast/{0}/{1}?{2}";

        public object HttpClient { get; private set; }

        public ForecastModel GetForecast(string location)
        {
            string apiRequest = string.Format(path, apiKey, location, dataExcludes);

            string data = RequestDataForWeek(apiRequest);
            
            if(string.IsNullOrEmpty(data))
            {
                return default(ForecastModel);
            }

            DarkSkyWeeklyForecast forecast = JsonConvert.DeserializeObject(data, typeof(DarkSkyWeeklyForecast)) as DarkSkyWeeklyForecast;

            ForecastModel model = new ForecastModel(forecast);
            
            return model;
        }

        public string RequestDataForWeek(string request)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(endpoint);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(request).Result;
            
            // The front end will deal with empty data sets
            string data = string.Empty;

            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
            }
      
            return data;
        }
    }
}
