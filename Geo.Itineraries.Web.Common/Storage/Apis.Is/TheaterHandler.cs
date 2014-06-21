// <copyright file="TheaterHandler.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Storage.ApisIs
{
    using System;
    using log4net;
    using WhatToDoInIceland.Web.Common.Models;

    /// <summary>
    /// The theater event handler
    /// </summary>
    public class TheaterHandler : IEventHandler
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(MovieHandler));

        /// <summary>
        /// Gets theater events and stores them in REDIS
        /// </summary>
        /// <param name="updateStorage">The method to call to update the storage</param>
        public override void GetEvents(Action<EventListModel> updateStorage)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Log.Error("An error occured getting movie data from apis.is.", ex);
            }
        }
    }
}