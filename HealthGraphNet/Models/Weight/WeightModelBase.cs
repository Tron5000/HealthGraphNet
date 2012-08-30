using System;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    public abstract class WeightModelBase
    {
        /// <summary>
        /// The value of the measured quantity.  
        /// </summary>
        private double? _bmi;
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

        /// <summary>
        /// The value of the measured quantity.  
        /// </summary>
        private double? _fatPercent;
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

        /// <summary>
        /// The value of the measured quantity.  
        /// </summary>
        private double? _freeMass;
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
                AssignMeasurement(_massWeight, WeightType.FreeMass);
            }
        }

        /// <summary>
        /// The value of the measured quantity.  
        /// </summary>
        private double? _massWeight;
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

        /// <summary>
        /// The value of the measured quantity.  
        /// </summary>
        private double? _weight;
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

        /// <summary>
        /// The measurement value - as defined by the MeasureType.
        /// </summary>
        private double? _measurement;
        public double? Measurement 
        {
            get
            {
                return _measurement;
            }
        }

        /// <summary>
        /// The measurement type.
        /// </summary>
        private WeightType? _measurementType;
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