using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The fitness activities feed item model used in conjunction with activity data.
    /// </summary>
    public class FitnessActivitiesFeedItemModel : FitnessActivitiesItemModel, IFeedModelItem
    {
       
        /// <summary>
        /// The URI of the detailed information for the past activity.  Read only.
        /// </summary>
        [JsonProperty(PropertyName = "uri")]       
        public string Uri { get; internal set; }
    }
}