namespace Geo.Itineraries.IntegrationTests.Handlers
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ServiceStack.Redis;
    using Geo.Itineraries.Web.Models;
    using Geo.Itineraries.Web.Storage.ApisIs;

    [TestClass]
    public class TheaterHandlerTests
    {
        [TestMethod]
        public void UpdatesRedisWithData()
        {
            SportHandler handler = new SportHandler();
            handler.GetEvents(null);

            var redisClient = new RedisClient("localhost");
            var eventClient = redisClient.As<EventListModel>();

            var all = eventClient.GetAll();
            Assert.IsTrue(all.Where(x => x.Id == (int)EventTypes.Theater).Any());
        }
    }
}
