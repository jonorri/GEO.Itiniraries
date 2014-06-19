using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhatToDoInIceland.Web.Common.Helpers;

namespace WhatToDoInIceland.Tests.Unit.Disposable
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
