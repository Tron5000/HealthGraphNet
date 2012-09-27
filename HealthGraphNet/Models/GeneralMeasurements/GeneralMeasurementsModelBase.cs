using System;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    public abstract class GeneralMeasurementsModelBase
    {
        private double? _bloodCalcium;

        /// <summary>
        /// The value of the measured quantity (mg/dL).
        /// </summary>
        [JsonProperty(PropertyName = "blood_calcium")]
        public double? BloodCalcium
        {
            get
            {
                return _bloodCalcium;
            }
            set
            {
                NullAllMeasurements();
                _bloodCalcium = value;
                AssignMeasurement(_bloodCalcium, GeneralMeasurementsType.BloodCalcium);
            }
        }

        private double? _bloodChromium;

        /// <summary>
        /// The value of the measured quantity (mug/dL).
        /// </summary>
        [JsonProperty(PropertyName = "blood_chromium")]
        public double? BloodChromium
        {
            get
            {
                return _bloodChromium;
            }
            set
            {
                NullAllMeasurements();
                _bloodChromium = value;
                AssignMeasurement(_bloodChromium, GeneralMeasurementsType.BloodChromium);
            }
        }

        private double? _bloodFolicAcid;

        /// <summary>
        /// The value of the measured quantity (ng/mL).
        /// </summary>
        [JsonProperty(PropertyName = "blood_folic_acid")]
        public double? BloodFolicAcid
        {
            get
            {
                return _bloodFolicAcid;
            }
            set
            {
                NullAllMeasurements();
                _bloodFolicAcid = value;
                AssignMeasurement(_bloodFolicAcid, GeneralMeasurementsType.BloodFolicAcid);
            }
        }

        private double? _bloodMagnesium;

        /// <summary>
        /// The value of the measured quantity (mg/dL).
        /// </summary>
        [JsonProperty(PropertyName = "blood_magnesium")]
        public double? BloodMagnesium
        {
            get
            {
                return _bloodMagnesium;
            }
            set
            {
                NullAllMeasurements();
                _bloodMagnesium = value;
                AssignMeasurement(_bloodMagnesium, GeneralMeasurementsType.BloodMagnesium);
            }
        }

        private double? _bloodPotassium;

        /// <summary>
        /// The value of the measured quantity (mg/dL).
        /// </summary>
        [JsonProperty(PropertyName = "blood_potassium")]
        public double? BloodPotassium
        {
            get
            {
                return _bloodPotassium;
            }
            set
            {
                NullAllMeasurements();
                _bloodPotassium = value;
                AssignMeasurement(_bloodPotassium, GeneralMeasurementsType.BloodPotassium);
            }
        }

        private double? _bloodSodium;

        /// <summary>
        /// The value of the measured quantity (mg/dL).
        /// </summary>
        [JsonProperty(PropertyName = "blood_sodium")]
        public double? BloodSodium
        {
            get
            {
                return _bloodSodium;
            }
            set
            {
                NullAllMeasurements();
                _bloodSodium = value;
                AssignMeasurement(_bloodSodium, GeneralMeasurementsType.BloodSodium);
            }
        }

        private double? _bloodVitaminB12;

        /// <summary>
        /// The value of the measured quantity (pg/mL).
        /// </summary>
        [JsonProperty(PropertyName = "blood_vitamin_b12")]
        public double? BloodVitaminB12
        {
            get
            {
                return _bloodVitaminB12;
            }
            set
            {
                NullAllMeasurements();
                _bloodVitaminB12 = value;
                AssignMeasurement(_bloodVitaminB12, GeneralMeasurementsType.BloodVitaminB12);
            }
        }

        private double? _bloodZinc;

        /// <summary>
        /// The value of the measured quantity (mug/dL).
        /// </summary>
        [JsonProperty(PropertyName = "blood_zinc")]
        public double? BloodZinc
        {
            get
            {
                return _bloodZinc;
            }
            set
            {
                NullAllMeasurements();
                _bloodZinc = value;
                AssignMeasurement(_bloodZinc, GeneralMeasurementsType.BloodZinc);
            }
        }

        private double? _creatineKinase;

        /// <summary>
        /// The value of the measured quantity (U/L).
        /// </summary>
        [JsonProperty(PropertyName = "creatine_kinase")]
        public double? CreatineKinase
        {
            get
            {
                return _creatineKinase;
            }
            set
            {
                NullAllMeasurements();
                _creatineKinase = value;
                AssignMeasurement(_creatineKinase, GeneralMeasurementsType.CreatineKinase);
            }
        }

        private double? _crp;

        /// <summary>
        /// The value of the measured quantity (mg/L).
        /// </summary>
        [JsonProperty(PropertyName = "crp")]
        public double? Crp
        {
            get
            {
                return _crp;
            }
            set
            {
                NullAllMeasurements();
                _crp = value;
                AssignMeasurement(_crp, GeneralMeasurementsType.Crp);
            }
        }

        private double? _diastolic;

        /// <summary>
        /// The value of the measured quantity (mmHg).
        /// </summary>
        [JsonProperty(PropertyName = "diastolic")]
        public double? Diastolic
        {
            get
            {
                return _diastolic;
            }
            set
            {
                NullAllMeasurements();
                _diastolic = value;
                AssignMeasurement(_diastolic, GeneralMeasurementsType.Diastolic);
            }
        }

        private double? _ferritin;

        /// <summary>
        /// The value of the measured quantity (ng/mL).
        /// </summary>
        [JsonProperty(PropertyName = "ferritin")]
        public double? Ferritin
        {
            get
            {
                return _ferritin;
            }
            set
            {
                NullAllMeasurements();
                _ferritin = value;
                AssignMeasurement(_ferritin, GeneralMeasurementsType.Ferritin);
            }
        }

        private double? _hdl;

        /// <summary>
        /// The value of the measured quantity (mg/dL).
        /// </summary>
        [JsonProperty(PropertyName = "hdl")]
        public double? Hdl
        {
            get
            {
                return _hdl;
            }
            set
            {
                NullAllMeasurements();
                _hdl = value;
                AssignMeasurement(_hdl, GeneralMeasurementsType.Hdl);
            }
        }

        private double? _hscrp;

        /// <summary>
        /// The value of the measured quantity (mg/L).
        /// </summary>
        [JsonProperty(PropertyName = "hscrp")]
        public double? Hscrp
        {
            get
            {
                return _hscrp;
            }
            set
            {
                NullAllMeasurements();
                _hscrp = value;
                AssignMeasurement(_hscrp, GeneralMeasurementsType.Hscrp);
            }
        }

        private double? _il6;

        /// <summary>
        /// The value of the measured quantity (mg/dL).
        /// </summary>
        [JsonProperty(PropertyName = "il6")]
        public double? Il6
        {
            get
            {
                return _il6;
            }
            set
            {
                NullAllMeasurements();
                _il6 = value;
                AssignMeasurement(_il6, GeneralMeasurementsType.Il6);
            }
        }

        private double? _ldl;

        /// <summary>
        /// The value of the measured quantity (mg/dL).
        /// </summary>
        [JsonProperty(PropertyName = "ldl")]
        public double? Ldl
        {
            get
            {
                return _ldl;
            }
            set
            {
                NullAllMeasurements();
                _ldl = value;
                AssignMeasurement(_ldl, GeneralMeasurementsType.Ldl);
            }
        }

        private double? _restingHeartrate;

        /// <summary>
        /// The value of the measured quantity (bpm).
        /// </summary>
        [JsonProperty(PropertyName = "resting_heartrate")]
        public double? RestingHeartrate
        {
            get
            {
                return _restingHeartrate;
            }
            set
            {
                NullAllMeasurements();
                _restingHeartrate = value;
                AssignMeasurement(_restingHeartrate, GeneralMeasurementsType.RestingHeartrate);
            }
        }

        private double? _systolic;

        /// <summary>
        /// The value of the measured quantity (mmHg).
        /// </summary>
        [JsonProperty(PropertyName = "systolic")]
        public double? Systolic
        {
            get
            {
                return _systolic;
            }
            set
            {
                NullAllMeasurements();
                _systolic = value;
                AssignMeasurement(_systolic, GeneralMeasurementsType.Systolic);
            }
        }

        private double? _testosterone;

        /// <summary>
        /// The value of the measured quantity (mg/dL).
        /// </summary>
        [JsonProperty(PropertyName = "testosterone")]
        public double? Testosterone
        {
            get
            {
                return _testosterone;
            }
            set
            {
                NullAllMeasurements();
                _testosterone = value;
                AssignMeasurement(_testosterone, GeneralMeasurementsType.Testosterone);
            }
        }

        private double? _totalCholesterol;

        /// <summary>
        /// The value of the measured quantity (mg/dL).
        /// </summary>
        [JsonProperty(PropertyName = "total_cholesterol")]
        public double? TotalCholesterol
        {
            get
            {
                return _totalCholesterol;
            }
            set
            {
                NullAllMeasurements();
                _totalCholesterol = value;
                AssignMeasurement(_totalCholesterol, GeneralMeasurementsType.TotalCholesterol);
            }
        }

        private double? _tsh;

        /// <summary>
        /// The value of the measured quantity (mIU/L).
        /// </summary>
        [JsonProperty(PropertyName = "tsh")]
        public double? Tsh
        {
            get
            {
                return _tsh;
            }
            set
            {
                NullAllMeasurements();
                _tsh = value;
                AssignMeasurement(_tsh, GeneralMeasurementsType.Tsh);
            }
        }

        private double? _uricAcid;

        /// <summary>
        /// The value of the measured quantity (mg/dL).
        /// </summary>
        [JsonProperty(PropertyName = "uric_acid")]
        public double? UricAcid
        {
            get
            {
                return _uricAcid;
            }
            set
            {
                NullAllMeasurements();
                _uricAcid = value;
                AssignMeasurement(_uricAcid, GeneralMeasurementsType.UricAcid);
            }
        }

        private double? _vitaminD;

        /// <summary>
        /// The value of the measured quantity (ng/dL).
        /// </summary>
        [JsonProperty(PropertyName = "vitamin_d")]
        public double? VitaminD
        {
            get
            {
                return _vitaminD;
            }
            set
            {
                NullAllMeasurements();
                _vitaminD = value;
                AssignMeasurement(_vitaminD, GeneralMeasurementsType.VitaminD);
            }
        }

        private double? _whiteCellCount;

        /// <summary>
        /// The value of the measured quantity (ng/muL).
        /// </summary>
        [JsonProperty(PropertyName = "white_cell_count")]
        public double? WhiteCellCount
        {
            get
            {
                return _whiteCellCount;
            }
            set
            {
                NullAllMeasurements();
                _whiteCellCount = value;
                AssignMeasurement(_whiteCellCount, GeneralMeasurementsType.WhiteCellCount);
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

        private GeneralMeasurementsType? _measurementType;

        /// <summary>
        /// The measurement type.
        /// </summary>
        [JsonIgnore()]
        public GeneralMeasurementsType? MeasurementType
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
        internal void AssignMeasurement(double? measurement, GeneralMeasurementsType measurementType)
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
        /// Clears all nullable general measurements.
        /// </summary>
        internal void NullAllMeasurements()
        {
            _bloodCalcium = null;
            _bloodChromium = null;        
            _bloodFolicAcid = null;        
            _bloodMagnesium = null;        
            _bloodPotassium = null;        
            _bloodSodium = null;        
            _bloodVitaminB12 = null;        
            _bloodZinc = null;        
            _creatineKinase = null;        
            _crp = null;        
            _diastolic = null;        
            _ferritin = null;        
            _hdl = null;        
            _hscrp = null;        
            _il6 = null;        
            _ldl = null;        
            _restingHeartrate = null;        
            _systolic = null;        
            _testosterone = null;        
            _totalCholesterol = null;        
            _tsh = null;        
            _uricAcid = null;        
            _vitaminD = null;        
            _whiteCellCount = null;
        }
    }
}