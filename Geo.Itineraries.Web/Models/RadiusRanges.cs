// <copyright file="RadiusRanges.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Models
{
    /// <summary>
    /// The radius range
    /// </summary>
    public enum RadiusRanges
    {
        /// <summary>
        /// 100 meters
        /// </summary>
        Radius100M = 100,

        /// <summary>
        /// 250 meters
        /// </summary>
        Radius250M = 250,

        /// <summary>
        /// 500 meters
        /// </summary>
        Radius500M = 500,

        /// <summary>
        /// 1 kilometer
        /// </summary>
        Radius1KM = 1000,

        /// <summary>
        /// 5 kilometers
        /// </summary>
        Radius5KM = 5000,

        /// <summary>
        /// 10 kilometers
        /// </summary>
        Radius10KM = 10000,

        /// <summary>
        /// 15 kilometers
        /// </summary>
        Radius15KM = 15000,

        /// <summary>
        /// All events
        /// </summary>
        ALL = 999999
    }
}