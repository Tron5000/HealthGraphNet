using System;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The set model used in conjunction with strength training activities data.
    /// </summary>
    public class SetsModel
    {
        /// <summary>
        /// The weight for the set, in kg.
        /// </summary>
        [JsonProperty(PropertyName = "weight")]
        public double Weight { get; set; }

        /// <summary>
        /// The number of repetitions in this set.
        /// </summary>
        [JsonProperty(PropertyName = "repetitions")]
        public int Repetitions { get; set; }

        /// <summary>
        /// Any notes for this set (max. 1024 characters; optional).
        /// </summary>
        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }
    }
}