using System;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    public abstract class BackgroundActivitiesModelBase
    {
        private double? _caloriesBurned;

        /// <summary>
        /// The value of the measured quantity.
        /// </summary>
        [JsonProperty(PropertyName = "calories_burned")]
        public double? CaloriesBurned
        {
            get
            {
                return _caloriesBurned;
            }
            set
            {
                NullAllMeasurements();
                _caloriesBurned = value;
                AssignMeasurement(_caloriesBurned, BackgroundActivitiesType.CaloriesBurned);
            }
        }

        private double? _steps;

        /// <summary>
        /// The value of the measured quantity.
        /// </summary>
        [JsonProperty(PropertyName = "steps")]
        public double? Steps
        {
            get
            {
                return _steps;
            }
            set
            {
                NullAllMeasurements();
                _steps = value;
                AssignMeasurement(_steps, BackgroundActivitiesType.Steps);
            }
        }

        private double? _measurement;

        /// <summary>
        /// The value of the measured quantity.
        /// </summary>
        [JsonIgnore()]
        public double? Measurement
        {
            get
            {
                return _measurement;
            }
        }

        private BackgroundActivitiesType? _measurementType;

        /// <summary>
        /// The measurement type.
        /// </summary>
        [JsonIgnore()]
        public BackgroundActivitiesType? MeasurementType
        {
            get
            {
                return _measurementType;
            }
        }

        /// <summary>
        /// Assigns measurements and measurement type.
        /// </summary>
        /// <param name="measurement"></param>
        /// <param name="measurementType"></param>
        internal void AssignMeasurement(double? measurement, BackgroundActivitiesType measurementType)
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
        /// Clears all nullable background activitiy type measurements.
        /// </summary>
        internal void NullAllMeasurements()
        {
            _caloriesBurned = null;
            _steps = null;
        }
    }
}