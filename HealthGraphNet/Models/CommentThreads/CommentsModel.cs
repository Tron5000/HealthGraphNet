using System;
using Newtonsoft.Json;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet.Models
{
    public class CommentsModel
    {
        /// <summary>
        /// The time at which the comment was posted (e.g., Sat, 1 Jan 2011 00:00:00). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        [JsonConverter(typeof(AdjustToUniversalIsoDateTimeConverter))]
        public DateTime Timestamp { get; internal set; }

        /// <summary>
        /// The unique ID for the user that left the comment. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "userID")]
        public int UserID { get; internal set; }

        /// <summary>
        /// The display name of the user that left the comment. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; internal set; }

        /// <summary>
        /// The comment. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; internal set; }
    }
}