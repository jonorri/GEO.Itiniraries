// <copyright file="MovieModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace Geo.Itineraries.Models.ApisIs
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The movie model
    /// </summary>
    [Serializable]
    public class MovieModel
    {
        /// <summary>
        /// Gets or sets the title
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the release date of the movie
        /// </summary>
        [DataMember(Name = "released")]
        public string Released { get; set; }

        /// <summary>
        /// Gets or sets the restriction of the movie
        /// </summary>
        [DataMember(Name = "restricted")]
        public string Restricted { get; set; }

        /// <summary>
        /// Gets or sets the IMDB rating of the movie
        /// </summary>
        [DataMember(Name = "imdb")]
        public string Imdb { get; set; }

        /// <summary>
        /// Gets or sets the IMDB link to the movie
        /// </summary>
        [DataMember(Name = "imdbLink")]
        public string ImdbLink { get; set; }

        /// <summary>
        /// Gets or sets a link to the cover image of the movie
        /// </summary>
        [DataMember(Name = "image")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the show times of the movie
        /// </summary>
        [DataMember(Name = "showtimes")]
        public ICollection<ShowTimeModel> ShowTimes { get; set; }
    }
}