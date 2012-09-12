using System;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    public abstract class WeightModelBase
    {
        private double? _bmi;
        
        /// <summary>
        /// The value of the measured quantity.  
        /// </summary>
        [JsonProperty(PropertyName = "bmi")]
        public double? Bmi 
        {
            get
            {
                return _bmi;
            }
            set
            {
                NullAllMeasurements();
                _bmi = value;
                AssignMeasurement(_bmi, WeightType.BMI);
            }
        }

        private double? _fatPercent;

        /// <summary>
        /// The value of the measured quantity.  
        /// </summary>
        [JsonProperty(PropertyName = "fat_percent")]        
        public double? FatPercent 
        {
            get
            {
                return _fatPercent;
            }
            set
            {
                NullAllMeasurements();
                _fatPercent = value;
                AssignMeasurement(_fatPercent, WeightType.FatPercent);
            }
        }

        private double? _freeMass;

        /// <summary>
        /// The value of the measured quantity (in kg).  
        /// </summary>
        [JsonProperty(PropertyName = "free_mass")]        
        public double? FreeMass 
        {
            get
            {
                return _freeMass;
            }
            set
            {
                NullAllMeasurements();
                _freeMass = value;
                AssignMeasurement(_freeMass, WeightType.FreeMass);
            }
        }

        private double? _massWeight;

        /// <summary>
        /// The value of the measured quantity (in kg).  
        /// </summary>
        [JsonProperty(PropertyName = "mass_weight")]        
        public double? MassWeight 
        {
            get
            {
                return _massWeight;
            }
            set
            {
                NullAllMeasurements();
                _massWeight = value;
                AssignMeasurement(_massWeight, WeightType.MassWeight);
            }
        }

        private double? _weight;
        
        /// <summary>
        /// The value of the measured quantity (in kg).  
        /// </summary>
        [JsonProperty(PropertyName = "weight")]        
        public double? Weight 
        {
            get
            {
                return _weight;
            }
            set
            {
                NullAllMeasurements();
                _weight = value;
                AssignMeasurement(_weight, WeightType.Weight);
            }
        }

        private double? _measurement;

        /// <summary>
        /// The measurement value (in kg for FreeMass, MassWeight and Weight MeasurementTypes.
        /// </summary>
        [JsonIgnore()]
        public double? Measurement 
        {
            get
            {
                return _measurement;
            }
        }

        private WeightType? _measurementType;

        /// <summary>
        /// The measurement type.
        /// </summary>
        [JsonIgnore()]
        public WeightType? MeasurementType 
        {
            get
            {
                return _measurementType;
            }
        }

        /// <summary>
        /// Assigns measurement and measurement type.
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="measurementType"></param>
        internal void AssignMeasurement(double? measurement, WeightType measurementType)
        {
            if (measurement.HasValue)
            {
                //A non null value is being assigned for this type
                _measurement = measurement;
                _measurementType = measurementType;
            }
            else if ((measurement.HasValue == false) && (_measurementType == measurementType))
            {
                //The measurements are being cleared.
                _measurement = null;
                _measurementType = null;
            }
        }

        /// <summary>
        /// Clears all nullable weight type measurements.
        /// </summary>
        internal void NullAllMeasurements()
        {
            _bmi = null;
            _fatPercent = null;
            _freeMass = null;
            _massWeight = null;
            _weight = null;
        }
    }
}