using System;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The heart rate model used in conjunction with activity data.
    /// </summary>      
    public class HeartRateModel
    {
        /// <summary>
        /// The number of seconds since the start of the activity.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public double Timestamp { get; set; }
        
        /// <summary>
        /// The instantaneous heart rate, in beats per minute.
        /// </summary>
        [JsonProperty(PropertyName = "heart_rate")]
        public int HeartRate { get; set; }
    }
}