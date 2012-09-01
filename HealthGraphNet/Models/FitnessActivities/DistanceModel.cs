using System;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The distance model used in conjunction with activity data.
    /// </summary>     
    public class DistanceModel
    {
        /// <summary>
        /// The number of seconds since the start of the activity.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public double Timestamp { get; set; }
        
        /// <summary>
        /// The total distance traveled since the start of the activity, in meters.
        /// </summary>
        [JsonProperty(PropertyName = "distance")]
        public double Distance { get; set; }
    }
}