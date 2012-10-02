using System;
using Newtonsoft.Json;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The diabetes feed item model used in conjunction with diabetes data.
    /// </summary>
    public class DiabetesMeasurementsFeedItemModel : DiabetesMeasurementsModelBase, IFeedModelItem
    {
        /// <summary>
        /// The time at which the measurement was taken (e.g., "Sat, 1 Jan 2011 00:00:00"). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        [JsonConverter(typeof(AdjustToUniversalIsoDateTimeConverter))]
        public DateTime Timestamp { get; internal set; }

        /// <summary>
        /// The value of the measured quantity (ng/mL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "c_peptide")]
        public new double? CPeptide
        {
            get
            {
                return base.CPeptide;
            }
            internal set
            {
                base.CPeptide = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mg/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "fasting_plasma_glucose_test")]
        public new double? FastingPlasmaGlucoseTest
        {
            get
            {
                return base.FastingPlasmaGlucoseTest;
            }
            internal set
            {
                base.FastingPlasmaGlucoseTest = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (g/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "hemoglobin_a1c")]
        public new double? HemoglobinA1c
        {
            get
            {
                return base.HemoglobinA1c;
            }
            internal set
            {
                base.HemoglobinA1c = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (U). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "insulin")]
        public new double? Insulin
        {
            get
            {
                return base.Insulin;
            }
            internal set
            {
                base.Insulin = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mg/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "oral_glucose_tolerance_test")]
        public new double? OralGlucoseToleranceTest
        {
            get
            {
                return base.OralGlucoseToleranceTest;
            }
            internal set
            {
                base.OralGlucoseToleranceTest = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mg/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "random_plasma_glucose_test")]
        public new double? RandomPlasmaGlucoseTest
        {
            get
            {
                return base.RandomPlasmaGlucoseTest;
            }
            internal set
            {
                base.RandomPlasmaGlucoseTest = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mg/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "triglyceride")]
        public new double? Triglyceride
        {
            get
            {
                return base.Triglyceride;
            }
            internal set
            {
                base.Triglyceride = value;
            }
        }

        /// <summary>
        /// The URI of detailed information for the diabetes measurement. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; internal set; }
    }
}