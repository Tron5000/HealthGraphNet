using System;

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
        public DateTime Timestamp { get; internal set; }
       
        /// <summary>
        /// The value of the measured quantity. Read only. 
        /// </summary>
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
        /// The value of the measured quantity. Read only. 
        /// </summary>
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
        /// The value of the measured quantity. Read only. 
        /// </summary>
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
        /// The value of the measured quantity. Read only. 
        /// </summary>
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
        public string Uri { get; internal set; }
    }
}