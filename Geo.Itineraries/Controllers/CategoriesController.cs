namespace Geo.Itineraries.Controllers
{
    using Geo.Itineraries.Models;
    using Geo.Itineraries.Storage;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class CategoriesController : ApiController
    {
        private readonly IItineraryStorage itineraryStorage;

        public CategoriesController()
        {
            itineraryStorage = new ItineraryStorage();
        }

        // GET api/categories
        public IEnumerable<CategoryModel> Get()
        {
            return this.itineraryStorage.GetCategories();
        }

        // GET api/categories/5
        public CategoryModel Get(int id)
        {
            return this.itineraryStorage.GetCategory(id);
        }

        //// POST api/categories
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/categories/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/categories/5
        //public void Delete(int id)
        //{
        //}
    }
}
