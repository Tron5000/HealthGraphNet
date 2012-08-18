using System;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The settings model.  Members that cannot be edited are marked as internal.
    /// </summary>    
    public class SettingsModel
    {
        public bool FacebookConnected { get; internal set; }
        public bool TwitterConnected { get; internal set; }
        public bool FoursquareConnected { get; internal set; }
        public bool ShareFitnessActivities { get; set; }
        public string ShareMap { get; set; }
        public bool PostFitnessActivityFacebook { get; set; }
        public bool PostFitnessActivityTwitter { get; set; }
        public bool PostLiveFitnessActivityFacebook { get; set; }
        public bool PostLiveFitnessActivityTwitter { get; set; }
        public string ShareBackgroundActivities { get; set; }
        public bool PostBackgroundActivityFacebook { get; set; }
        public bool PostBackgroundActivityTwitter { get; set; }
        public string ShareSleep { get; set; }
        public bool PostSleepFacebook { get; set; }
        public bool PostSleepTwitter { get; set; }
        public string ShareNutrition { get; set; }
        public bool PostNutritionFacebook { get; set; }
        public bool PostNutritionTwitter { get; set; }
        public string ShareWeight { get; set; }
        public bool PostWeightFacebook { get; set; }
        public bool PostWeightTwitter { get; set; }
        public string ShareGeneralMeasurements { get; set; }
        public bool PostGeneralMeasurementsFacebook { get; set; }
        public bool PostGeneralMeasurementsTwitter { get; set; }
        public string ShareDiabetes { get; set; }
        public bool PostDiabetesFacebook { get; set; }
        public bool PostDiabetesTwitter { get; set; }
        public string DistanceUnits { get; set; }
        public string WeightUnits { get; set; }
        public string FirstDayOfWeek { get; set; }    
    }
}