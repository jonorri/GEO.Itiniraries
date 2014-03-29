namespace Geo.Itineraries.Web.Helpers
{
    using System.Device.Location;

    public static class GeoHelpers
    {
        public static double DistanceBetween(GeoCoordinate home, GeoCoordinate dest)
        {
            return home.GetDistanceTo(dest);
        }

        public static double DistanceBetween(double homeLat, double homeLong, double destLat, double destLong)
        {
            var home = new GeoCoordinate(homeLat, homeLong);
            var dest = new GeoCoordinate(destLat, destLong);

            return DistanceBetween(home, dest);
        }
    }
}