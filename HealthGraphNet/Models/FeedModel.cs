using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// A generic feed model common to many endpoints throughout the HealthGraph
    /// </summary>
    public class FeedModel<T> where T : IFeedModelItem
    {
        /// <summary>
        /// The total number of all pages.  Read only.
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public int Size { get; internal set; }

        /// <summary>
        /// The items in the feed from newest to oldest.  Read only.
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public List<T> Items { get; internal set; }

        /// <summary>
        /// The URI of the previous page in the feed (omitted for the oldest page). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "previous")]
        public string Previous { get; internal set; }

        /// <summary>
        /// The URI of the next page in the feed (omitted for the newest page). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "next")]
        public string Next { get; internal set; }
    }
}