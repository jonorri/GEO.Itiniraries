namespace Geo.Itineraries.Helpers
{
    using System.Device.Location;

    public static class GeoHelpers
    {
        public static double DistanceBetween(GeoCoordinate home, GeoCoordinate dest)
        {
            return home.GetDistanceTo(dest);
        }
    }
}