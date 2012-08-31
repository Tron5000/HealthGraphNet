using System;
using Newtonsoft.Json;

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
        [JsonProperty(PropertyName = "facebook_connected")]
        public bool FacebookConnected { get; internal set; }
        
        /// <summary>
        /// true if the user has connected to his/her Twitter account, false otherwise. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "twitter_connected")]        
        public bool TwitterConnected { get; internal set; }
        
        /// <summary>
        /// true if the user has connected to his/her Foursquare account, false otherwise. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "foursquare_connected")]        
        public bool FoursquareConnected { get; internal set; }
        
        /// <summary>
        /// The visibility of the user’s fitness activities to others, as one of the following values: "Just Me", "Street Team", "Everyone".
        /// </summary>
        [JsonProperty(PropertyName = "share_fitness_activities")]       
        public string ShareFitnessActivities { get; set; }
        
        /// <summary>
        /// The visibility of the user’s activity routes to others, as one of the following values: "Just Me", "Street Team", "Everyone".
        /// </summary>
        [JsonProperty(PropertyName = "share_map")]        
        public string ShareMap { get; set; }
        
        /// <summary>
        /// true if fitness activities are automatically posted to Facebook, false otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "post_fitness_activity_facebook")]        
        public bool PostFitnessActivityFacebook { get; set; }
        
        /// <summary>
        /// true if fitness activities are automatically posted to Twitter, false otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "post_fitness_activity_twitter")]        
        public bool PostFitnessActivityTwitter { get; set; }
        
        /// <summary>
        /// true if live activities are automatically posted to Facebook, false otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "post_live_fitness_activity_facebook")]        
        public bool PostLiveFitnessActivityFacebook { get; set; }
        
        /// <summary>
        /// true if live activities are automatically posted to Twitter, false otherwise
        /// </summary>
        [JsonProperty(PropertyName = "post_live_fitness_activity_twitter")]        
        public bool PostLiveFitnessActivityTwitter { get; set; }
        
        /// <summary>
        /// The visibility of the user’s background activities to others, as one of the following values: "Just Me", "Street Team", "Everyone".
        /// </summary>
        [JsonProperty(PropertyName = "share_background_activities")]        
        public string ShareBackgroundActivities { get; set; }
        
        /// <summary>
        /// true if background activities are automatically posted to Facebook, false otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "post_background_activity_facebook")]        
        public bool PostBackgroundActivityFacebook { get; set; }
        
        /// <summary>
        /// true if fitness activities are automatically posted to Twitter, false otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "post_background_activity_twitter")]        
        public bool PostBackgroundActivityTwitter { get; set; }
        
        /// <summary>
        /// The visibility of the user’s sleep measurements to others, as one of the following values: "Just Me", "Street Team", "Everyone".
        /// </summary>
        [JsonProperty(PropertyName = "share_sleep")]        
        public string ShareSleep { get; set; }
        
        /// <summary>
        /// true if sleep measurements are automatically posted to Facebook, false otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "post_sleep_facebook")]        
        public bool PostSleepFacebook { get; set; }
        
        /// <summary>
        /// true if sleep measurements are automatically posted to Twitter, false otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "post_sleep_twitter")]        
        public bool PostSleepTwitter { get; set; }
        
        /// <summary>
        /// The visibility of the user’s nutrition measurements to others, as one of the following values: "Just Me", "Street Team", "Everyone".
        /// </summary>
        [JsonProperty(PropertyName = "share_nutrition")]        
        public string ShareNutrition { get; set; }
        
        /// <summary>
        /// true if nutrition measurements are automatically posted to Facebook, false otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "post_nutrition_facebook")]        
        public bool PostNutritionFacebook { get; set; }
        
        /// <summary>
        /// true if nutrition measurements are automatically posted to Twitter, false otherwise
        /// </summary>
        [JsonProperty(PropertyName = "post_nutrition_twitter")]        
        public bool PostNutritionTwitter { get; set; }
        
        /// <summary>
        /// The visibility of the user’s weight measurements to others, as one of the following values: "Just Me", "Street Team", "Everyone".
        /// </summary>
        [JsonProperty(PropertyName = "share_weight")]        
        public string ShareWeight { get; set; }
        
        /// <summary>
        /// true if weight measurements are automatically posted to Facebook, false otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "post_weight_facebook")]        
        public bool PostWeightFacebook { get; set; }
        
        /// <summary>
        /// true if weight measurements are automatically posted to Twitter, false otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "post_weight_twitter")]        
        public bool PostWeightTwitter { get; set; }
        
        /// <summary>
        /// The visibility of the user’s general measurements to others, as one of the following values: "Just Me", "Street Team", "Everyone".
        /// </summary>
        [JsonProperty(PropertyName = "share_general_measurements")]        
        public string ShareGeneralMeasurements { get; set; }
        
        /// <summary>
        /// true if general measurements are automatically posted to Facebook, false otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "post_general_measurements_facebook")]        
        public bool PostGeneralMeasurementsFacebook { get; set; }
        
        /// <summary>
        /// true if general measurements are automatically posted to Twitter, false otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "post_general_measurements_twitter")]        
        public bool PostGeneralMeasurementsTwitter { get; set; }
        
        /// <summary>
        /// The visibility of the user’s diabetes measurements to others, as one of the following values: "Just Me", "Street Team", "Everyone".
        /// </summary>
        [JsonProperty(PropertyName = "share_diabetes")]        
        public string ShareDiabetes { get; set; }
        
        /// <summary>
        /// true if diabetes measurements are automatically posted to Facebook, false otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "post_diabetes_facebook")]        
        public bool PostDiabetesFacebook { get; set; }
        
        /// <summary>
        /// true if diabetes measurements are automatically posted to Twitter, false otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "post_diabetes_twitter")]        
        public bool PostDiabetesTwitter { get; set; }
        
        /// <summary>
        /// The units of distance used on the RunKeeper website, as one of the following values: "mi", "km".
        /// </summary>
        [JsonProperty(PropertyName = "distance_units")]        
        public string DistanceUnits { get; set; }
        
        /// <summary>
        /// The units of weight used on the RunKeeper website, as one of the following values: "lbs", "kg".
        /// </summary>
        [JsonProperty(PropertyName = "weight_units")]
        public string WeightUnits { get; set; }
        
        /// <summary>
        /// The first day of the calendar week used on the RunKeeper website, as one of the following values: "Sunday", "Monday".
        /// </summary>
        [JsonProperty(PropertyName = "first_day_of_week")]        
        public string FirstDayOfWeek { get; set; }    
    }
}