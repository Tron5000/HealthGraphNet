using System;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    public abstract class DiabetesMeasurementsModelBase
    {
        private double? _cPeptide;

        /// <summary>
        /// The value of the measured quantity (ng/mL).
        /// </summary>
        [JsonProperty(PropertyName = "c_peptide")]
        public double? CPeptide
        {
            get
            {
                return _cPeptide;
            }
            set
            {
                NullAllMeasurements();
                _cPeptide = value;
                AssignMeasurement(_cPeptide, DiabetesMeasurementsType.CPeptide);
            }
        }

        private double? _fastingPlasmaGlucoseTest;

        /// <summary>
        /// The value of the measured quantity (mg/dL).
        /// </summary>
        [JsonProperty(PropertyName = "fasting_plasma_glucose_test")]
        public double? FastingPlasmaGlucoseTest
        {
            get
            {
                return _fastingPlasmaGlucoseTest;
            }
            set
            {
                NullAllMeasurements();
                _fastingPlasmaGlucoseTest = value;
                AssignMeasurement(_fastingPlasmaGlucoseTest, DiabetesMeasurementsType.FastingPlasmaGlucoseTest);
            }
        }

        private double? _hemoglobinA1c;

        /// <summary>
        /// The value of the measured quantity (g/dL).
        /// </summary>
        [JsonProperty(PropertyName = "hemoglobin_a1c")]
        public double? HemoglobinA1c
        {
            get
            {
                return _hemoglobinA1c;
            }
            set
            {
                NullAllMeasurements();
                _hemoglobinA1c = value;
                AssignMeasurement(_hemoglobinA1c, DiabetesMeasurementsType.HemoglobinA1c);
            }
        }

        private double? _insulin;

        /// <summary>
        /// The value of the measured quantity (U).
        /// </summary>
        [JsonProperty(PropertyName = "insulin")]
        public double? Insulin
        {
            get
            {
                return _insulin;
            }
            set
            {
                NullAllMeasurements();
                _insulin = value;
                AssignMeasurement(_insulin, DiabetesMeasurementsType.Insulin);
            }
        }

        private double? _oralGlucoseToleranceTest;

        /// <summary>
        /// The value of the measured quantity (mg/dL).
        /// </summary>
        [JsonProperty(PropertyName = "oral_glucose_tolerance_test")]
        public double? OralGlucoseToleranceTest
        {
            get
            {
                return _oralGlucoseToleranceTest;
            }
            set
            {
                NullAllMeasurements();
                _oralGlucoseToleranceTest = value;
                AssignMeasurement(_oralGlucoseToleranceTest, DiabetesMeasurementsType.OralGlucoseToleranceTest);
            }
        }

        private double? _randomPlasmaGlucoseTest;

        /// <summary>
        /// The value of the measured quantity (mg/dL).
        /// </summary>
        [JsonProperty(PropertyName = "random_plasma_glucose_test")]
        public double? RandomPlasmaGlucoseTest
        {
            get
            {
                return _randomPlasmaGlucoseTest;
            }
            set
            {
                NullAllMeasurements();
                _randomPlasmaGlucoseTest = value;
                AssignMeasurement(_randomPlasmaGlucoseTest, DiabetesMeasurementsType.RandomPlasmaGlucoseTest);
            }
        }

        private double? _triglyceride;

        /// <summary>
        /// The value of the measured quantity (mg/dL).
        /// </summary>
        [JsonProperty(PropertyName = "triglyceride")]
        public double? Triglyceride
        {
            get
            {
                return _triglyceride;
            }
            set
            {
                NullAllMeasurements();
                _triglyceride = value;
                AssignMeasurement(_triglyceride, DiabetesMeasurementsType.Triglyceride);
            }
        }

        private double? _measurement;

        /// <summary>
        /// The measurement value.
        /// </summary>
        [JsonIgnore()]
        public double? Measurement
        {
            get
            {
                return _measurement;
            }
        }

        private DiabetesMeasurementsType? _measurementType;

        /// <summary>
        /// The measurement type.
        /// </summary>
        [JsonIgnore()]
        public DiabetesMeasurementsType? MeasurementType
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
        internal void AssignMeasurement(double? measurement, DiabetesMeasurementsType measurementType)
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
        /// Clears all nullable diabetes type measurements.
        /// </summary>
        internal void NullAllMeasurements()
        {
            _cPeptide = null;
            _fastingPlasmaGlucoseTest = null;
            _hemoglobinA1c = null;
            _insulin = null;
            _oralGlucoseToleranceTest = null;
            _randomPlasmaGlucoseTest = null;
            _triglyceride = null;
        }
    }
}