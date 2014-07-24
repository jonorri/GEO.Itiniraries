// <copyright file="TheaterHandler.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Storage.ApisIs
{
    using System;
    using log4net;
    using WhatToDoInIceland.Web.Common.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The theater event handler
    /// </summary>
    public class TheaterHandler : IEventHandler
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(MovieHandler));

        public override EventListModel GetEvents()
        {
            return new EventListModel();
        }
    }
}