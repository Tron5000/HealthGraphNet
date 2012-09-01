using System;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The calories model used in conjunction with activity data.
    /// </summary>      
    public class CaloriesModel
    {
        /// <summary>
        /// The number of seconds since the start of the activity.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public double Timestamp { get; set; }
        
        /// <summary>
        /// The total calories burned since the start of the activity.
        /// </summary>
        [JsonProperty(PropertyName = "calories")]        
        public double Calories { get; set; }
    }
}