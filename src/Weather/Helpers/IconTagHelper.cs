using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Helpers
{
    public static class IconTagHelper
    {
        public static Dictionary<string, string> mappings = new Dictionary<string, string>()
        {
            { "clear-day", "sun"},
            { "clear-night", "sun"},
            { "rain", "rain"},
            { "snow", "snow"},
            { "sleet", "sleet"},
            { "wind", "wind"},
            { "fog", "sun cloud"},
            { "cloudy", "cloud"},
            { "partly-cloudy-day", "sun cloud"},
            { "partly-cloudy-night", "sun cloud"},
        };
        
        private static string defaultValue = "sun cloud";

        public static string ConvertToClimaconClasses(this string tags)
        {
            if (!mappings.ContainsKey(tags))
            {
                return defaultValue;
            }

            KeyValuePair<string, string> match = mappings.Where(mapping => mapping.Key == tags).First();
            
            return match.Value;
        }
    }
}
