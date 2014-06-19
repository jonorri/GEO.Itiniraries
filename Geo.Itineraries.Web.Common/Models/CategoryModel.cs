// <copyright file="CategoryModel.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

namespace WhatToDoInIceland.Web.Common.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Category model
    /// </summary>
    public class CategoryModel
    {
        /// <summary>
        /// Gets or sets the category id
        /// </summary>
        [JsonProperty(PropertyName = "categoryId")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category name
        /// </summary>
        [JsonProperty(PropertyName = "categoryName")]
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the category description
        /// </summary>
        [JsonProperty(PropertyName = "categoryDescription")]
        public string CategoryDescription { get; set; }
    }
}