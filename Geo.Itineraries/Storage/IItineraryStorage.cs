using Geo.Itineraries.Models;
using System.Collections.Generic;
namespace Geo.Itineraries.Storage
{
    public interface IItineraryStorage
    {
        IList<CategoryModel> GetCategories();

        IList<EventModel> GetEventsByCategory(int categoryId);

        IList<EventModel> GetEvents(int categoryId, string location);

        CategoryModel GetCategory(int id);
    }
}
