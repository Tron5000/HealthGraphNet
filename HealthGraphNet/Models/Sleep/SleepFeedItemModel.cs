using System;
using Newtonsoft.Json;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The sleep feed item model used in conjunction with sleep data.
    /// </summary>
    public class SleepFeedItemModel : SleepModelBase, IFeedModelItem
    {
        /// <summary>
        /// The time at which the measurement was taken (e.g., "Sat, 1 Jan 2011 00:00:00"). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        [JsonConverter(typeof(AdjustToUniversalIsoDateTimeConverter))]
        public DateTime Timestamp { get; internal set; }

        /// <summary>
        /// The value of the measured quantity (in minutes). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "awake")]
        public new double? Awake
        {
            get
            {
                return base.Awake;
            }
            internal set
            {
                base.Awake = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (in minutes). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "deep")]
        public new double? Deep
        {
            get
            {
                return base.Deep;
            }
            internal set
            {
                base.Deep = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (in minutes). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "light")]
        public new double? Light
        {
            get
            {
                return base.Light;
            }
            internal set
            {
                base.Light = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (in minutes). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "rem")]
        public new double? Rem
        {
            get
            {
                return base.Rem;
            }
            internal set
            {
                base.Rem = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "times_woken")]
        public new double? TimesWoken
        {
            get
            {
                return base.TimesWoken;
            }
            set
            {
                base.TimesWoken = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (in minutes). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "total_sleep")]
        public new double? TotalSleep
        {
            get
            {
                return base.TotalSleep;
            }
            set
            {
                base.TotalSleep = value;
            }
        }

        /// <summary>
        /// The URI of detailed information for the weight measurement. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; internal set; }
    }
}