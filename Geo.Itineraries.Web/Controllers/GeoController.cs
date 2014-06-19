// <copyright file="GeoController.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The geo controller
    /// </summary>
    public class GeoController : Controller
    {
        /// <summary>
        /// The index method returns the geo index view
        /// </summary>
        /// <returns>The index view</returns>
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
