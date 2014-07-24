// <copyright file="IEventHandler.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WhatToDoInIceland.Web.Common.Models;

    /// <summary>
    /// The event handler interface
    /// </summary>
    public abstract class IEventHandler
    {
        /// <summary>
        /// Gets the movie events 
        /// </summary>
        /// <returns>All movie events in a collection</returns>
        public abstract EventListModel GetEvents();
    }
}
