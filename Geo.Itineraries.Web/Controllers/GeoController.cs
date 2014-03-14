using Geo.Itineraries.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Geo.Itineraries.Web.Controllers
{
    public class GeoController : Controller
    {
        //
        // GET: /Geo/
        public ActionResult Index()
        {
            return View();
        }

        public string getter(GetterModel getterModel)
        {
            if (!ModelState.IsValid)
            {
                return string.Empty;
            }

            using (HttpClient client = new HttpClient())
            {
                // TODO: KRAPP REMEMBER TO GEO SEARCH THE CATEGORIES AS WELL
                var response = client.GetAsync(string.Format("http://localhost:51844/api/categories/")).Result;

                var contentString = response.Content.ReadAsStringAsync().Result;
                return contentString;
            }
        }

        public string GetEvents(GetterModel getterModel)
        {
            if (!ModelState.IsValid)
            {
                return string.Empty;
            }

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(string.Format("http://localhost:51844/api/events/?location={0}", getterModel.Position)).Result;

                var contentString = response.Content.ReadAsStringAsync().Result;
                return contentString;
            }
        }

        public class GetterModel
        {
            public string Position { get; set; }
        }
	}
}