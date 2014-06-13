using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geo.Itineraries.Web.Common.Helpers;

namespace Geo.Itineraries.Tests.Unit.Disposable
{
    [TestClass]
    public class PrimeCache
    {
        [TestMethod]
        public void PrimeCacheWithVenues()
        {
            VenueHelper.PrimeCacheWithVenues();
        }
    }
}
