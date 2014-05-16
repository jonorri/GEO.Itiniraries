// <copyright file="MovieTheaterModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Web.Models.Apis.Is
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text;

    /// <summary>
    /// The movie theater model
    /// </summary>
    [Serializable]
    public class MovieTheaterModel
    {
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

                    // TODO: KRAPP FINISH THE CHECKING FOR BOUNDARIES HERE
                    TimeSpan ts = new TimeSpan(int.Parse(showTime.Substring(0, 2)), int.Parse(showTime.Substring(3, 2)), 0);
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