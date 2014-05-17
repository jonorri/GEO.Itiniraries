// <copyright file="IEventHandler.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Common.Storage
{
    using System;
    using Geo.Itineraries.Web.Common.Models;

    /// <summary>
    /// The event handler interface
    /// </summary>
    public abstract class IEventHandler
    {
        /// <summary>
        /// Gets events and stores them in REDIS
        /// </summary>
        /// <param name="updateStorage">The method to call to update the storage</param>
        public abstract void GetEvents(Action<EventListModel> updateStorage);
    }
}
