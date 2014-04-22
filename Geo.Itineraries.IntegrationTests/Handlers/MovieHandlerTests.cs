namespace Geo.Itineraries.IntegrationTests.Handlers
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Geo.Itineraries.Web.Storage.ApisIs;
    using ServiceStack.Redis;
    using Geo.Itineraries.Web.Models;

    [TestClass]
    public class MovieHandlerTests
    {
        [TestMethod]
        public void UpdatesRedisWithData()
        {
            MovieHandler handler = new MovieHandler();
            // TODO: KRAPP IN ALL TESTS THIS SHOULDN'T BE NULL BUT A VERIFIABLE METHOD
            handler.GetEvents(null);

            var redisClient = new RedisClient("localhost");
            var eventClient = redisClient.As<EventListModel>();

            var all = eventClient.GetAll();
            Assert.IsTrue(all.Where(x => x.Id == (int)EventTypes.Movies).Any());
        }
    }
}
