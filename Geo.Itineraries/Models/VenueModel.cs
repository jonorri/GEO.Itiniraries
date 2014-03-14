namespace Geo.Itineraries.Models
{
    public class VenueModel
    {
        public int VenueId { get; set; }

        public string VenueName { get; set; }

        // TODO: KRAPP FIND THIS OUT BASED ON ADDRESS 
        // https://developers.google.com/maps/documentation/geocoding/#Limits
        // https://groups.google.com/forum/#!topic/tasker/E-3DnR-WbfA
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Location { get; set; }
    }
}