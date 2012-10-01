using System;
using Newtonsoft.Json;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The feed item model used in conjunction with general measurements.
    /// </summary>
    public class GeneralMeasurementsFeedItemModel : GeneralMeasurementsModelBase, IFeedModelItem
    {
        /// <summary>
        /// The time at which the measurement was taken (e.g., "Sat, 1 Jan 2011 00:00:00"). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        [JsonConverter(typeof(AdjustToUniversalIsoDateTimeConverter))]
        public DateTime Timestamp { get; internal set; }

        /// <summary>
        /// The value of the measured quantity (mg/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "blood_calcium")]
        public new double? BloodCalcium
        {
            get
            {
                return base.BloodCalcium;
            }
            internal set
            {
                base.BloodCalcium = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mug/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "blood_chromium")]
        public new double? BloodChromium
        {
            get
            {
                return base.BloodChromium;
            }
            internal set
            {
                base.BloodChromium = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (ng/mL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "blood_folic_acid")]
        public new double? BloodFolicAcid
        {
            get
            {
                return base.BloodFolicAcid;
            }
            internal set
            {
                base.BloodFolicAcid = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mg/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "blood_magnesium")]
        public new double? BloodMagnesium
        {
            get
            {
                return base.BloodMagnesium;
            }
            internal set
            {
                base.BloodMagnesium = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mg/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "blood_potassium")]
        public new double? BloodPotassium
        {
            get
            {
                return base.BloodPotassium;
            }
            internal set
            {
                base.BloodPotassium = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mg/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "blood_sodium")]
        public new double? BloodSodium
        {
            get
            {
                return base.BloodSodium;
            }
            internal set
            {
                base.BloodSodium = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (pg/mL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "blood_vitamin_b12")]
        public new double? BloodVitaminB12
        {
            get
            {
                return base.BloodVitaminB12;
            }
            internal set
            {
                base.BloodVitaminB12 = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mug/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "blood_zinc")]
        public new double? BloodZinc
        {
            get
            {
                return base.BloodZinc;
            }
            internal set
            {
                base.BloodZinc = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (U/L). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "creatine_kinase")]
        public new double? CreatineKinase
        {
            get
            {
                return base.CreatineKinase;
            }
            internal set
            {
                base.CreatineKinase = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mg/L). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "crp")]
        public new double? Crp
        {
            get
            {
                return base.Crp;
            }
            internal set
            {
                base.Crp = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mmHg). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "diastolic")]
        public new double? Diastolic
        {
            get
            {
                return base.Diastolic;
            }
            internal set
            {
                base.Diastolic = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (ng/mL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "ferritin")]
        public new double? Ferritin
        {
            get
            {
                return base.Ferritin;
            }
            internal set
            {
                base.Ferritin = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mg/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "hdl")]
        public new double? Hdl
        {
            get
            {
                return base.Hdl;
            }
            internal set
            {
                base.Hdl = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mg/L). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "hscrp")]
        public new double? Hscrp
        {
            get
            {
                return base.Hscrp;
            }
            internal set
            {
                base.Hscrp = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mg/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "il6")]
        public new double? Il6
        {
            get
            {
                return base.Il6;
            }
            internal set
            {
                base.Il6 = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mg/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "ldl")]
        public new double? Ldl
        {
            get
            {
                return base.Ldl;
            }
            internal set
            {
                base.Ldl = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (bpm). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "resting_heartrate")]
        public new double? RestingHeartrate
        {
            get
            {
                return base.RestingHeartrate;
            }
            internal set
            {
                base.RestingHeartrate = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mmHg). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "systolic")]
        public new double? Systolic
        {
            get
            {
                return base.Systolic;
            }
            internal set
            {
                base.Systolic = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mg/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "testosterone")]
        public new double? Testosterone
        {
            get
            {
                return base.Testosterone;
            }
            internal set
            {
                base.Testosterone = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mg/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "total_cholesterol")]
        public new double? TotalCholesterol
        {
            get
            {
                return base.TotalCholesterol;
            }
            internal set
            {
                base.TotalCholesterol = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mIU/L). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "tsh")]
        public new double? Tsh
        {
            get
            {
                return base.Tsh;
            }
            internal set
            {
                base.Tsh = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (mg/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "uric_acid")]
        public new double? UricAcid
        {
            get
            {
                return base.UricAcid;
            }
            internal set
            {
                base.UricAcid = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (ng/dL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "vitamin_d")]
        public new double? VitaminD
        {
            get
            {
                return base.VitaminD;
            }
            internal set
            {
                base.VitaminD = value;
            }
        }

        /// <summary>
        /// The value of the measured quantity (ng/muL). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "white_cell_count")]
        public new double? WhiteCellCount
        {
            get
            {
                return base.WhiteCellCount;
            }
            internal set
            {
                base.WhiteCellCount = value;
            }
        }

        /// <summary>
        /// The URI of detailed information for the weight measurement. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; internal set; }
    }
}