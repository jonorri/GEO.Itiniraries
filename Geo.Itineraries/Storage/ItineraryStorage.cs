namespace Geo.Itineraries.Storage
{
    using Geo.Itineraries.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ItineraryStorage : IItineraryStorage
    {
        IList<CategoryModel> categoryList = new List<CategoryModel> {new CategoryModel {CategoryName = "MOVIES", CategoryDescription = "Movie description", CategoryId = 1 }, 
            new CategoryModel { CategoryName = "CONCERTS", CategoryDescription = "Concert description", CategoryId = 2 } };

        Dictionary<string, VenueModel> venues = new Dictionary<string,VenueModel>();

        public ItineraryStorage()
        {
            venues.Add("KEX", new VenueModel { VenueId = 1, VenueName = "KEX Hostel", Latitude = 64.145537, Longitude = -21.919487, Location = "Reykjavík" });
            venues.Add("GAMLI_GAUKUR", new VenueModel { VenueId = 2, VenueName = "Gamli Gaukurinn", Latitude = 64.149265, Longitude = -21.941615, Location = "Reykjavík" });
            venues.Add("HARLEM", new VenueModel { VenueId = 2, VenueName = "Harlem", Latitude = 64.149265, Longitude = -21.941615, Location = "Reykjavík" });
            venues.Add("LUCKY_RECORDS", new VenueModel { VenueId = 2, VenueName = "Lucky records", Latitude = 64.142729, Longitude = -21.914077, Location = "Reykjavík" });
            venues.Add("STÚDENTAKJALLARINN", new VenueModel { VenueId = 2, VenueName = "Stúdentakjallarinn", Latitude = 64.142729, Longitude = -21.914077, Location = "Reykjavík" });
            venues.Add("BÍÓ_PARADÍS", new VenueModel { VenueId = 2, VenueName = "Bíó Paradís", Latitude = 64.145574, Longitude = -21.925192, Location = "Reykjavík" });
            venues.Add("HÁSKÓLABÍÓ", new VenueModel { VenueId = 2, VenueName = "Háskólabíó", Latitude = 64.148181, Longitude = -21.867099, Location = "Reykjavík" });
            venues.Add("LAUGARÁSBÍÓ", new VenueModel { VenueId = 2, VenueName = "Laugarásbíó", Latitude = 64.145574,Longitude = -21.925192, Location = "Reykjavík" });
            venues.Add("SAMBÍÓ_EGILSHÖLL", new VenueModel { VenueId = 2, VenueName = "Sambíó Egilshöll", Latitude = 64.130189,Longitude = -21.893005, Location = "Reykjavík" });
            venues.Add("SAMBÍÓ_KRINGLAN", new VenueModel { VenueId = 2, VenueName = "Sambíó Kringlan", Latitude = 64.108031,Longitude = -21.844792, Location = "Reykjavík" });
            venues.Add("SAMBÍÓ_ÁLFABAKKA", new VenueModel { VenueId = 2, VenueName = "Sambíó Álfabakka", Latitude = 64.100997,Longitude = -21.883164, Location = "Reykjavík" });
            venues.Add("SMÁRABÍÓ", new VenueModel { VenueId = 2, VenueName = "Smárabíó", Latitude = 64.144535,Longitude = -21.938839, Location = "Reykjavík" });
            venues.Add("RÓSENBERG", new VenueModel { VenueId = 2, VenueName = "Rósenberg", Latitude = 64.144535,Longitude = -21.938839, Location = "Reykjavík" });
            venues.Add("DILLON", new VenueModel { VenueId = 2, VenueName = "Dillon", Latitude = 64.134951,Longitude = -21.872063, Location = "Reykjavík" });
            venues.Add("BORGARLEIKHÚSIÐ", new VenueModel { VenueId = 2, VenueName = "Borgarleikhúsið", Latitude = 64.134951,Longitude = -21.872063, Location = "Reykjavík" });
            venues.Add("ÞJÓÐLEIKHÚSIÐ", new VenueModel { VenueId = 2, VenueName = "Þjóðleikhúsið", Latitude = 64.1287,Longitude = -21.896595, Location = "Reykjavík" });
            venues.Add("HARPA", new VenueModel { VenueId = 2, VenueName = "Harpan", Latitude = 64.149265,Longitude = -21.941615, Location = "Reykjavík" });
        }

        public IList<CategoryModel> GetCategories()
        {
            return this.categoryList;
        }

        public async Task<IList<EventModel>> GetEvents(int categoryId, string location)
        {
            IEventHandler eventHandler = new ApisIs.MovieHandler();
            return await eventHandler.GetEvents();
        }

        public async Task<IList<EventModel>> GetEventsByCategory(int categoryId)
        {
            IEventHandler eventHandler = new ApisIs.MovieHandler();
            // TODO: KRAPP RENAME TO *ASYNC
            return await eventHandler.GetEvents();
        }

        public CategoryModel GetCategory(int id)
        {
            return this.categoryList.FirstOrDefault(x => x.CategoryId == id);
        }
    }
}