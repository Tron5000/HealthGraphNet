using System;
using Newtonsoft.Json;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The weight feed item model used in conjunction with weight data.
    /// </summary>
    public class WeightFeedItemModel : WeightModelBase, IFeedModelItem
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
        [JsonProperty(PropertyName = "bmi")]        
        public new double? Bmi
        {
            get
            {
                return base.Bmi;
            }
            internal set
            {
                base.Bmi = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity. Read only. 
        /// </summary>
        [JsonProperty(PropertyName = "fat_percent")]                
        public new double? FatPercent
        {
            get
            {
                return base.FatPercent;
            }
            internal set
            {
                base.FatPercent = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (in kg). Read only. 
        /// </summary>
        [JsonProperty(PropertyName = "free_mass")]                
        public new double? FreeMass
        {
            get
            {
                return base.FreeMass;
            }
            internal set
            {
                base.FreeMass = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (in kg). Read only. 
        /// </summary>
        [JsonProperty(PropertyName = "mass_weight")]                
        public new double? MassWeight
        {
            get
            {
                return base.MassWeight;
            }
            internal set
            {
                base.MassWeight = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (in kg). Read only. 
        /// </summary>
        [JsonProperty(PropertyName = "weight")]                
        public new double? Weight
        {
            get
            {
                return base.Weight;
            }
            internal set
            {
                base.Weight = value;
            }
        }
        
        /// <summary>
        /// The URI of detailed information for the weight measurement. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "uri")]                
        public string Uri { get; internal set; }
    }
}