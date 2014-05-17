// <copyright file="ConfigurationHelper.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Common.Helpers
{
    using System.Configuration;

    /// <summary>
    /// Provides helper methods for accessing the configuration files.
    /// </summary>
    public static class ConfigurationHelper
    {
        /// <summary>
        /// Gets the location of the REDIS database
        /// </summary>
        public static string RedisLocation 
        { 
            get 
            { 
                return ConfigurationManager.AppSettings["RedisLocation"]; 
            } 
        }

        /// <summary>
        /// Gets the REDIS password
        /// </summary>
        public static string RedisPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["RedisPrimaryKey"];
            }
        }

        /// <summary>
        /// Gets the REDIS port
        /// </summary>
        public static int RedisPort
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["RedisPort"]);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the REDIS is connected to by SSL or not
        /// </summary>
        public static bool RedisSSL 
        {
            get 
            {
                return bool.Parse(ConfigurationManager.AppSettings["RedisSSL"]);
            }
        }

        /// <summary>
        /// Gets the REDIS SSL host
        /// </summary>
        public static string RedisSSLHost 
        {
            get 
            {
                return ConfigurationManager.AppSettings["RedisSSLHost"];
            }
        }
    }
}