// <copyright file="MovieTheaterModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Models.Apis.Is
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using log4net;
    using Newtonsoft.Json;

    /// <summary>
    /// The movie theater model
    /// </summary>
    [Serializable]
    public class MovieTheaterModel
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(MovieTheaterModel));

        /// <summary>
        /// Gets or sets the name of the movie theater
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location of the movie theater
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the movie theater image
        /// </summary>
        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the movies shown at the movie theater
        /// </summary>
        [JsonProperty(PropertyName = "movies")]
        public ICollection<MovieModel> Movies { get; set; }

        /// <summary>
        /// Returns the first show time of this movie theater at the current day
        /// </summary>
        /// <returns>The first show time</returns>
        public DateTime GetFirstShowTime()
        {
            DateTime firstShowTime = DateTime.MaxValue;
            foreach (var movie in this.Movies)
            {
                foreach (var showTime in movie.Schedule)
                {
                    DateTime tempDateTime = DateTime.UtcNow;
                    int hour, minute;
                    if (!int.TryParse(showTime.Substring(0, 2), out hour))
                    {
                        Log.Error(string.Format("An error occured parsing the hour part of {0} to a valid show time.", showTime));
                    }

                    if (!int.TryParse(showTime.Substring(3, 2), out minute))
                    {
                        Log.Error(string.Format("An error occured parsing the minute part of {0} to a valid show time.", showTime));
                    }

                    TimeSpan ts = new TimeSpan(hour, minute, 0);
                    tempDateTime = tempDateTime.Date + ts;

                    if (tempDateTime < firstShowTime)
                    {
                        firstShowTime = tempDateTime;
                    }
                }
            }

            return firstShowTime;
        }

        /// <summary>
        /// Returns the string representation of the movies show at this movie theater
        /// </summary>
        /// <returns>The string representation of the movie shown</returns>
        public string MoviesList()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var movie in this.Movies)
            {
                sb.Append(movie.Title + ":");
                foreach (var showTime in movie.Schedule)
                {
                    sb.Append("," + showTime);
                }

                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}