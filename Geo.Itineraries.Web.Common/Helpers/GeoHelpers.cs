// <copyright file="GeoHelpers.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Common.Helpers
{
    using System.Device.Location;

    /// <summary>
    /// The geo helpers class contains helper methods for working with geo coordinates
    /// </summary>
    public static class GeoHelpers
    {
        /// <summary>
        /// Calculates the distance between 2 geo coordinates
        /// </summary>
        /// <param name="home">Home coordinate</param>
        /// <param name="dest">Destination coordinate</param>
        /// <returns>The distance in meters between</returns>
        public static double DistanceBetween(GeoCoordinate home, GeoCoordinate dest)
        {
            return home.GetDistanceTo(dest);
        }

        /// <summary>
        /// Calculates the distance between 2 geo coordinates
        /// </summary>
        /// <param name="homeLat">Home latitude</param>
        /// <param name="homeLong">Home longitude</param>
        /// <param name="destLat">Destination latitude</param>
        /// <param name="destLong">Destination longitude</param>
        /// <returns>The distance in meters between</returns>
        public static double DistanceBetween(double homeLat, double homeLong, double destLat, double destLong)
        {
            var home = new GeoCoordinate(homeLat, homeLong);
            var dest = new GeoCoordinate(destLat, destLong);

            return DistanceBetween(home, dest);
        }
    }
}