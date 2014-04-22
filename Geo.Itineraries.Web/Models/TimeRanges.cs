using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geo.Itineraries.Web.Models
{
    public enum TimeRanges
    {
        NextHour = 1,
        Next3Hours = 3,
        Next6Hours = 6,
        Next12Hours = 12,
        NextDay = 24,
        Next3Days = 72,
        NextWeek = 168,
        All = 999999
    }
}