﻿// <copyright file="TheaterHandler.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Common.Storage.ApisIs
{
    using System;
    using Geo.Itineraries.Web.Common.Models;

    /// <summary>
    /// The theater event handler
    /// </summary>
    public class TheaterHandler : IEventHandler
    {
        /// <summary>
        /// Gets theater events and stores them in REDIS
        /// </summary>
        /// <param name="updateStorage">The method to call to update the storage</param>
        public override void GetEvents(Action<EventListModel> updateStorage)
        {
            try
            {
            }
            catch (Exception)
            {
                // TODO: KRAPP LOG AND SWALLOW
            }
        }
    }
}