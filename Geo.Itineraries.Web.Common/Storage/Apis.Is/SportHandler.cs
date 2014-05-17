// <copyright file="SportHandler.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Common.Storage.ApisIs
{
    using System;
    using Geo.Itineraries.Web.Common.Models;

    /// <summary>
    /// The sport event handler
    /// </summary>
    public class SportHandler : IEventHandler
    {
        /// <summary>
        /// Gets sports events and stores them in REDIS
        /// </summary>
        /// <param name="updateStorage">The method to call to update the storage</param>
        public override void GetEvents(Action<EventListModel> updateStorage)
        {  
        }
    }
}