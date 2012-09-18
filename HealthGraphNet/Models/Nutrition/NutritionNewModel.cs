using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet.Models
{
    public class NutritionNewModel : NutritionModelBase
    {
        internal const string ContentType = "application/vnd.com.runkeeper.NewNutrition+json";

        /// <summary>
        /// The time at which the measurement was taken (e.g., "Sat, 1 Jan 2011 00:00:00").
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        [JsonConverter(typeof(AdjustToUniversalIsoDateTimeConverter))]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Whether to post this measurement to Twitter (optional; if omitted, the user's default setting will be used).
        /// </summary>
        [JsonProperty(PropertyName = "post_to_twitter")]
        public bool? PostToTwitter { get; set; }

        /// <summary>
        /// Whether to post this measurement to Facebook (optional; if omitted, the user's default setting will be used).
        /// </summary>
        [JsonProperty(PropertyName = "post_to_facebook")]
        public bool? PostToFacebook { get; set; }
    }
}