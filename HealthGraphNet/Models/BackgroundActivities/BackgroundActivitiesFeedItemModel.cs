using System;
using Newtonsoft.Json;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet.Models
{
    public class BackgroundActivitiesFeedItemModel : BackgroundActivitiesModelBase, IFeedModelItem
    {
        /// <summary>
        /// The time at which the measurement was taken (e.g., "Sat, 1 Jan 2011 00:00:00"). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        [JsonConverter(typeof(AdjustToUniversalIsoDateTimeConverter))]
        public DateTime Timestamp { get; internal set; }

        /// <summary>
        /// The value of the measured quantity. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "calories_burned")]
        public new double? CaloriesBurned
        {
            get
            {
                return base.CaloriesBurned;
            }
            internal set
            {
                base.CaloriesBurned = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "steps")]
        public new double? Steps
        {
            get
            {
                return base.Steps;
            }
            internal set
            {
                base.Steps = value;
            }
        }

        /// <summary>
        /// The URI of detailed information for the background activities measurement. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; internal set; }
    }
}