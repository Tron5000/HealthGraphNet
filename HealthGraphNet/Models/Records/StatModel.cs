using System;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The feed model item describing stats associated with records.
    /// </summary>
    public class StatModel
    {
        /// <summary>
        /// The type of statistic, as one of the following values: BEST_ACTIVITY, BEST_WEEK, LAST_WEEK, THIS_WEEK, BEST_MONTH, LAST_MONTH, THIS_MONTH, OVERALL. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "stat_type")]
        public string StatType { get; internal set; }

        /// <summary>
        /// The record distance value. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public double Value { get; internal set; }

        /// <summary>
        /// The date of the record (e.g., Sat, 1 Jan 2011 00:00:00). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "date")]        
        public DateTime Date { get; internal set; }
    }
}