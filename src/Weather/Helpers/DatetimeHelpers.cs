using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Helpers
{
    public static class DateTimeHelpers
    {
        public static DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

        public static DateTime UnixTimeStampToDateTime(this int unixTimeStamp)
        {
            return epoch.AddSeconds(unixTimeStamp).ToLocalTime();
        }
    }
}
