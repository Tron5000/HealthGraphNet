using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The strength training activities feed item model used in conjunction with strength training activities.
    /// </summary>
    public class StrengthTrainingActivitiesFeedItemModel : IFeedModelItem
    {
        /// <summary>
        /// The starting time for the activity (e.g., Sat, 1 Jan 2011 00:00:00). Read only
        /// </summary>
        [JsonProperty(PropertyName = "start_time")]
        public DateTime StartTime { get; internal set; }

        /// <summary>
        /// The URI of the detailed information for the activity. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; internal set; }
    }
}