// <copyright file="BundleConfig.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web
{
    using System.Web;
    using System.Web.Optimization;

    /// <summary>
    /// The bundle config for the website
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Registers all bundles needed for the website.
        /// </summary>
        /// <param name="bundles">Bundles to register</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/geo").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-checkbox.js",
                      "~/Scripts/bootstrap-slider.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/geo.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-checkbox.css",
                      "~/Content/bootstrap-slider.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/site.css"));
        }
    }
}
