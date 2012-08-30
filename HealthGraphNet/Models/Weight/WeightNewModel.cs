using System;
using System.Collections.Generic;

namespace HealthGraphNet.Models
{
    public class WeightNewModel : WeightModelBase
    {
        internal const string ContentType = "application/vnd.com.runkeeper.NewWeight+json";

        /// <summary>
        /// The time at which the measurement was taken (e.g., "Sat, 1 Jan 2011 00:00:00").
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Whether to post this measurement to Twitter (optional; if omitted, the user's default setting will be used).
        /// </summary>
        public bool? PostToTwitter { get; set; }

        /// <summary>
        /// Whether to post this measurement to Facebook (optional; if omitted, the user's default setting will be used).
        /// </summary>
        public bool? PostToFacebook { get; set; }
    }
}