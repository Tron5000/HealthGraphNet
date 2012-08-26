using System;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The settings model.
    /// </summary>    
    public class SettingsModel
    {
        internal const string ContentType = "application/vnd.com.runkeeper.Settings+json";        
                
        /// <summary>
        /// true if the user has connected to his/her Facebook account, false otherwise. Read only.
        /// </summary>
        public bool FacebookConnected { get; internal set; }
        
        /// <summary>
        /// true if the user has connected to his/her Twitter account, false otherwise. Read only.
        /// </summary>
        public bool TwitterConnected { get; internal set; }
        
        /// <summary>
        /// true if the user has connected to his/her Foursquare account, false otherwise. Read only.
        /// </summary>
        public bool FoursquareConnected { get; internal set; }
        
        /// <summary>
        /// The visibility of the user’s fitness activities to others, as one of the following values: "Just Me", "Street Team", "Everyone".
        /// </summary>
        public string ShareFitnessActivities { get; set; }
        
        /// <summary>
        /// The visibility of the user’s activity routes to others, as one of the following values: "Just Me", "Street Team", "Everyone".
        /// </summary>
        public string ShareMap { get; set; }
        
        /// <summary>
        /// true if fitness activities are automatically posted to Facebook, false otherwise.
        /// </summary>
        public bool PostFitnessActivityFacebook { get; set; }
        
        /// <summary>
        /// true if fitness activities are automatically posted to Twitter, false otherwise.
        /// </summary>
        public bool PostFitnessActivityTwitter { get; set; }
        
        /// <summary>
        /// true if live activities are automatically posted to Facebook, false otherwise.
        /// </summary>
        public bool PostLiveFitnessActivityFacebook { get; set; }
        
        /// <summary>
        /// true if live activities are automatically posted to Twitter, false otherwise
        /// </summary>
        public bool PostLiveFitnessActivityTwitter { get; set; }
        
        /// <summary>
        /// The visibility of the user’s background activities to others, as one of the following values: "Just Me", "Street Team", "Everyone".
        /// </summary>
        public string ShareBackgroundActivities { get; set; }
        
        /// <summary>
        /// true if background activities are automatically posted to Facebook, false otherwise.
        /// </summary>
        public bool PostBackgroundActivityFacebook { get; set; }
        
        /// <summary>
        /// true if fitness activities are automatically posted to Twitter, false otherwise.
        /// </summary>
        public bool PostBackgroundActivityTwitter { get; set; }
        
        /// <summary>
        /// The visibility of the user’s sleep measurements to others, as one of the following values: "Just Me", "Street Team", "Everyone".
        /// </summary>
        public string ShareSleep { get; set; }
        
        /// <summary>
        /// true if sleep measurements are automatically posted to Facebook, false otherwise.
        /// </summary>
        public bool PostSleepFacebook { get; set; }
        
        /// <summary>
        /// true if sleep measurements are automatically posted to Twitter, false otherwise.
        /// </summary>
        public bool PostSleepTwitter { get; set; }
        
        /// <summary>
        /// The visibility of the user’s nutrition measurements to others, as one of the following values: "Just Me", "Street Team", "Everyone".
        /// </summary>
        public string ShareNutrition { get; set; }
        
        /// <summary>
        /// true if nutrition measurements are automatically posted to Facebook, false otherwise.
        /// </summary>
        public bool PostNutritionFacebook { get; set; }
        
        /// <summary>
        /// true if nutrition measurements are automatically posted to Twitter, false otherwise
        /// </summary>
        public bool PostNutritionTwitter { get; set; }
        
        /// <summary>
        /// The visibility of the user’s weight measurements to others, as one of the following values: "Just Me", "Street Team", "Everyone".
        /// </summary>
        public string ShareWeight { get; set; }
        
        /// <summary>
        /// true if weight measurements are automatically posted to Facebook, false otherwise.
        /// </summary>
        public bool PostWeightFacebook { get; set; }
        
        /// <summary>
        /// true if weight measurements are automatically posted to Twitter, false otherwise.
        /// </summary>
        public bool PostWeightTwitter { get; set; }
        
        /// <summary>
        /// The visibility of the user’s general measurements to others, as one of the following values: "Just Me", "Street Team", "Everyone".
        /// </summary>
        public string ShareGeneralMeasurements { get; set; }
        
        /// <summary>
        /// true if general measurements are automatically posted to Facebook, false otherwise.
        /// </summary>
        public bool PostGeneralMeasurementsFacebook { get; set; }
        
        /// <summary>
        /// true if general measurements are automatically posted to Twitter, false otherwise.
        /// </summary>
        public bool PostGeneralMeasurementsTwitter { get; set; }
        
        /// <summary>
        /// The visibility of the user’s diabetes measurements to others, as one of the following values: "Just Me", "Street Team", "Everyone".
        /// </summary>
        public string ShareDiabetes { get; set; }
        
        /// <summary>
        /// true if diabetes measurements are automatically posted to Facebook, false otherwise.
        /// </summary>
        public bool PostDiabetesFacebook { get; set; }
        
        /// <summary>
        /// true if diabetes measurements are automatically posted to Twitter, false otherwise.
        /// </summary>
        public bool PostDiabetesTwitter { get; set; }
        
        /// <summary>
        /// The units of distance used on the RunKeeper website, as one of the following values: "mi", "km".
        /// </summary>
        public string DistanceUnits { get; set; }
        
        /// <summary>
        /// The units of weight used on the RunKeeper website, as one of the following values: "lbs", "kg".
        /// </summary>
        public string WeightUnits { get; set; }
        
        /// <summary>
        /// The first day of the calendar week used on the RunKeeper website, as one of the following values: "Sunday", "Monday".
        /// </summary>
        public string FirstDayOfWeek { get; set; }    
    }
}