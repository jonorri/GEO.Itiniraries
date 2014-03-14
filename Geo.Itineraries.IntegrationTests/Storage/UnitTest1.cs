using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geo.Itineraries.Storage;
using System.Threading.Tasks;

namespace Geo.Itineraries.IntegrationTests.Storage
{
    [TestClass]
    public class TheMovieEventHandler
    {
        [TestMethod]
        public async Task GetEvents()
        {
            IEventHandler handler = new MovieHandler();
            var result = await handler.GetEvents();
        }
    }
}
