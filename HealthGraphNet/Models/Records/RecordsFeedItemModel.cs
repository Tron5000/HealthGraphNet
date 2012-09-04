using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    public class RecordsFeedItemModel
    {
        /// <summary>
        /// The type of activity, as one of the following values: Running, Cycling, Mountain Biking, Walking, Hiking, Downhill Skiing, Cross-Country Skiing, Snowboarding, Skating, Swimming, Wheelchair, Rowing, Elliptical, Other. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "activity_type")]
        public string ActivityType { get; internal set; }

        /// <summary>
        /// The statistics for the activity type (empty if no records are available). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "stats")]
        public List<StatModel> Stats { get; internal set; }
    }
}