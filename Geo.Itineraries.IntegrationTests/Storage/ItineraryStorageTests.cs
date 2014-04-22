namespace Geo.Itineraries.IntegrationTests.Storage
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Geo.Itineraries.Web.Storage;
    using ServiceStack.Redis;
    using Geo.Itineraries.Web.Models;

    [TestClass]
    public class ItineraryStorageTests
    {
        [TestClass]
        public class ThePrimeCacheMethod
        {
            [TestMethod]
            public void WhenCalledItShouldFetchInformationFromAllSources()
            {
                RedisStorage storage = new RedisStorage();
                storage.PrimeCache();

                var redisClient = new RedisClient("localhost");
                var eventClient = redisClient.As<EventListModel>();

                var all = eventClient.GetAll();
                Assert.IsTrue(all.Where(x => x.Id == (int)EventTypes.Movies).Any());
                Assert.IsTrue(all.Where(x => x.Id == (int)EventTypes.Sports).Any());
                Assert.IsTrue(all.Where(x => x.Id == (int)EventTypes.Concert).Any());
                Assert.IsTrue(all.Where(x => x.Id == (int)EventTypes.Theater).Any());
            }   
        }
    }
}
