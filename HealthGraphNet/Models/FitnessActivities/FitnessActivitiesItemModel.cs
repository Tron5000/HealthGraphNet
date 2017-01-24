using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthGraphNet.Models
{
    public class FitnessActivitiesItemModel
    {
        /// <summary>
        /// The type of activity.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public FitnessActivityType Type { get; internal set; }

        /// <summary>
        /// The starting time for the activity (e.g., Sat, 1 Jan 2011 00:00:00).  Read only.
        /// </summary>
        [JsonProperty(PropertyName = "start_time")]
        public DateTime StartTime { get; internal set; }

        /// <summary>
        /// The total distance for the activity, in meters.  Read only.
        /// </summary>
        [JsonProperty(PropertyName = "total_distance")]
        public double TotalDistance { get; internal set; }

        /// <summary>
        /// The duration of the activity, in seconds.  Read only.
        /// </summary>
        [JsonProperty(PropertyName = "duration")]
        public double Duration { get; internal set; }
    }
}
