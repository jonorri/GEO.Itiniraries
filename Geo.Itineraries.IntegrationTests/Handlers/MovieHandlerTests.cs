// <copyright file="FilterConfig.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

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
            bool updateStorageWasInvoked = false;
            Action<EventListModel> action = x => updateStorageWasInvoked = true;

            MovieHandler handler = new MovieHandler();
            handler.GetEvents(action);

            var redisClient = new RedisClient("localhost");
            var eventClient = redisClient.As<EventListModel>();

            var all = eventClient.GetAll();
            Assert.IsTrue(all.Where(x => x.Id == (int)EventTypes.Movies).Any());
            Assert.IsTrue(updateStorageWasInvoked);
        }
    }
}
