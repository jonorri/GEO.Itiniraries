// <copyright file="ConfigurationHelper.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Helpers
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

        public static string RedisPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["RedisPrimaryKey"];
            }
        }

        public static int RedisPort
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["RedisPort"]);
            }
        }

        public static bool RedisSSL 
        {
            get 
            {
                return bool.Parse(ConfigurationManager.AppSettings["RedisSSL"]);
            }
        }

        public static string RedisSSLHost 
        {
            get 
            {
                return ConfigurationManager.AppSettings["RedisSSLHost"];
            }
        }
    }
}