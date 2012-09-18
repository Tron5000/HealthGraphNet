using System;
using Newtonsoft.Json;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The nutrition feed item model used in conjunction with nutrition data.
    /// </summary>
    public class NutritionFeedItemModel : NutritionModelBase, IFeedModelItem
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
        [JsonProperty(PropertyName = "calories")]
        public new double? Calories
        {
            get
            {
                return base.Calories;
            }
            internal set
            {
                base.Calories = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (in grams). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "carbohydrates")]
        public new double? Carbohydrates
        {
            get
            {
                return base.Carbohydrates;
            }
            internal set
            {
                base.Carbohydrates = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (in grams). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "fat")]
        public new double? Fat
        {
            get
            {
                return base.Fat;
            }
            internal set
            {
                base.Fat = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (in grams). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "fiber")]
        public new double? Fiber
        {
            get
            {
                return base.Fiber;
            }
            internal set
            {
                base.Fiber = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (in grams). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "protein")]
        public new double? Protein
        {
            get
            {
                return base.Protein;
            }
            internal set
            {
                base.Protein = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (in milligrams). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "sodium")]
        public new double? Sodium
        {
            get
            {
                return base.Sodium;
            }
            internal set
            {
                base.Sodium = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (in fluid ounces). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "water")]
        public new double? Water
        {
            get
            {
                return base.Water;
            }
            internal set
            {
                base.Water = value;
            }
        }

        /// <summary>
        /// The URI of detailed information for the weight measurement. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; internal set; }
    }
}