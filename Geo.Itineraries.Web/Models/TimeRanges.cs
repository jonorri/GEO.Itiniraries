// <copyright file="TimeRanges.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Models
{
    /// <summary>
    /// Time ranges supported by the system
    /// </summary>
    public enum TimeRanges
    {
        /// <summary>
        /// Next hour
        /// </summary>
        NextHour = 1,

        /// <summary>
        /// Next 3 hours
        /// </summary>
        Next3Hours = 3,

        /// <summary>
        /// Next 6 hours
        /// </summary>
        Next6Hours = 6,

        /// <summary>
        /// Next 12 hours
        /// </summary>
        Next12Hours = 12,

        /// <summary>
        /// Next day
        /// </summary>
        NextDay = 24,

        /// <summary>
        /// Next 3 days
        /// </summary>
        Next3Days = 72,

        /// <summary>
        /// Next week
        /// </summary>
        NextWeek = 168,

        /// <summary>
        /// All events
        /// </summary>
        All = 999999
    }
}