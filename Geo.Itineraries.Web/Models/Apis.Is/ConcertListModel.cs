// <copyright file="FilterConfig.cs" company="CCP hf.">
//     Copyright 2014, JOK All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Geo.Itineraries.Models.ApisIs
{
    [Serializable]
    public class ConcertListModel
    {
        [DataMember]
        public ICollection<ConcertDateModel> Results { get; set; }
    }
}