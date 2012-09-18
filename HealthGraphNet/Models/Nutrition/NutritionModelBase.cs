using System;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    public abstract class NutritionModelBase
    {
        private double? _calories;

        /// <summary>
        /// The value of the measured quantity.
        /// </summary>
        [JsonProperty(PropertyName = "calories")]
        public double? Calories
        {
            get
            {
                return _calories;
            }
            set
            {
                NullAllMeasurements();
                _calories = value;
                AssignMeasurement(_calories, NutritionType.Calories);
            }
        }

        private double? _carbohydrates;

        /// <summary>
        /// The value of the measured quantity (in grams).
        /// </summary>
        [JsonProperty(PropertyName = "carbohydrates")]
        public double? Carbohydrates
        {
            get
            {
                return _carbohydrates;
            }
            set
            {
                NullAllMeasurements();
                _carbohydrates = value;
                AssignMeasurement(_carbohydrates, NutritionType.Carbohydrates);
            }
        }

        private double? _fat;

        /// <summary>
        /// The value of the measured quantity (in grams).
        /// </summary>
        [JsonProperty(PropertyName = "fat")]
        public double? Fat
        {
            get
            {
                return _fat;
            }
            set
            {
                NullAllMeasurements();
                _fat = value;
                AssignMeasurement(_fat, NutritionType.Fat);
            }
        }

        private double? _fiber;

        /// <summary>
        /// The value of the measured quantity (in grams).
        /// </summary>
        [JsonProperty(PropertyName = "fiber")]
        public double? Fiber
        {
            get
            {
                return _fiber;
            }
            set
            {
                NullAllMeasurements();
                _fiber = value;
                AssignMeasurement(_fiber, NutritionType.Fiber);
            }
        }

        private double? _protein;

        /// <summary>
        /// The value of the measured quantity (in grams).
        /// </summary>
        [JsonProperty(PropertyName = "protein")]
        public double? Protein
        {
            get
            {
                return _protein;
            }
            set
            {
                NullAllMeasurements();
                _protein = value;
                AssignMeasurement(_protein, NutritionType.Protein);
            }
        }

        private double? _sodium;

        /// <summary>
        /// The value of the measured quantity (in milligrams).
        /// </summary>
        [JsonProperty(PropertyName = "sodium")]
        public double? Sodium
        {
            get
            {
                return _sodium;
            }
            set
            {
                NullAllMeasurements();
                _sodium = value;
                AssignMeasurement(_sodium, NutritionType.Sodium);
            }
        }

        private double? _water;

        /// <summary>
        /// The value of the measured quantity (in fluid ounces).
        /// </summary>
        [JsonProperty(PropertyName = "water")]
        public double? Water
        {
            get
            {
                return _water;
            }
            set
            {
                NullAllMeasurements();
                _water = value;
                AssignMeasurement(_water, NutritionType.Water);
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

        private NutritionType? _measurementType;

        /// <summary>
        /// The measurement type.
        /// </summary>
        [JsonIgnore()]
        public NutritionType? MeasurementType
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
        internal void AssignMeasurement(double? measurement, NutritionType measurementType)
        {
            if (measurement.HasValue)
            {
                //A non null value is being assigned for this type
                _measurement = measurement;
                _measurementType = measurementType;
            }
            else if ((measurement.HasValue == false) && (_measurementType == measurementType))
            {
                //The measurements are being cleared
                _measurement = null;
                _measurementType = null;
            }
        }

        /// <summary>
        /// Clears all nullable weight type measurements.
        /// </summary>
        internal void NullAllMeasurements()
        {
            _calories = null;
            _carbohydrates = null;
            _fat = null;
            _fiber = null;
            _protein = null;
            _sodium = null;
            _water = null;
        }
    }
}