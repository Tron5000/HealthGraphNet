using System;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    public abstract class SleepModelBase
    {
        private double? _awake;

        /// <summary>
        /// The value of the measured quantity (in minutes).
        /// </summary>
        [JsonProperty(PropertyName = "awake")]
        public double? Awake
        {
            get
            {
                return _awake;
            }
            set
            {
                NullAllMeasurements();
                _awake = value;
                AssignMeasurement(_awake, SleepType.Awake);
            }
        }

        private double? _deep;

        /// <summary>
        /// The value of the measured quantity (in minutes).
        /// </summary>
        [JsonProperty(PropertyName = "deep")]
        public double? Deep
        {
            get
            {
                return _deep;
            }
            set
            {
                NullAllMeasurements();
                _deep = value;
                AssignMeasurement(_deep, SleepType.Deep);
            }
        }

        private double? _light;

        /// <summary>
        /// The value of the measured quantity (in minutes).
        /// </summary>
        [JsonProperty(PropertyName = "light")]
        public double? Light
        {
            get
            {
                return _light;
            }
            set
            {
                NullAllMeasurements();
                _light = value;
                AssignMeasurement(_light, SleepType.Light);
            }
        }

        private double? _rem;

        /// <summary>
        /// The value of the measured quantity (in minutes).
        /// </summary>
        [JsonProperty(PropertyName = "rem")]
        public double? Rem
        {
            get
            {
                return _rem;
            }
            set
            {
                NullAllMeasurements();
                _rem = value;
                AssignMeasurement(_rem, SleepType.REM);
            }
        }

        private double? _timesWoken;

        /// <summary>
        /// The value of the measured quantity.
        /// </summary>
        [JsonProperty(PropertyName = "times_woken")]
        public double? TimesWoken
        {
            get
            {
                return _timesWoken;
            }
            set
            {
                NullAllMeasurements();
                _timesWoken = value;
                AssignMeasurement(_timesWoken, SleepType.TimesWoken);
            }            
        }

        private double? _totalSleep;

        /// <summary>
        /// The value of the measured quantity (in minutes).
        /// </summary>
        [JsonProperty(PropertyName = "total_sleep")]
        public double? TotalSleep
        {
            get
            {
                return _totalSleep;
            }
            set
            {
                NullAllMeasurements();
                _totalSleep = value;
                AssignMeasurement(_totalSleep, SleepType.TotalSleep);
            }
        }

        private double? _measurement;

        /// <summary>
        /// The measurement value (in minutes for everything but TimesWoken).
        /// </summary>
        [JsonIgnore()]
        public double? Measurement
        {
            get
            {
                return _measurement;
            }
        }

        private SleepType? _measurementType;

        /// <summary>
        /// The measurement type.
        /// </summary>
        [JsonIgnore()]
        public SleepType? MeasurementType
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
        internal void AssignMeasurement(double? measurement, SleepType measurementType)
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
        /// Clears all nullable sleep type measurements.
        /// </summary>
        internal void NullAllMeasurements()
        {
            _awake = null;
            _deep = null;
            _light = null;
            _rem = null;
            _timesWoken = null;
            _totalSleep = null;
        }
    }
}