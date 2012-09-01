using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HealthGraphNet.Models
{
    public class FitnessActivitiesNewModel : IFitnessActivitiesModel
    {
        internal const string ContentType = "application/vnd.com.runkeeper.NewFitnessActivity+json";

        /// <summary>
        /// The type of activity, as one of the following values: Running, Cycling, Mountain Biking, Walking, Hiking, Downhill Skiing, Cross-Country Skiing, Snowboarding, Skating, Swimming, Wheelchair, Rowing, Elliptical, Other.
        /// </summary>
        [JsonProperty(PropertyName = "type")]        
        public string Type { get; set; }
    
        /// <summary>
        /// The secondary type of the activity, as a free-form string (max. 64 characters). This field is used only if the type field is "Other."
        /// </summary>
        [JsonProperty(PropertyName = "secondary_type")]               
        public string SecondaryType { get; set; }

        /// <summary>
        /// The equipment used to complete this activity, as one of the following values: None, Treadmill, Stationary Bike, Elliptical, Row Machine. (Optional; if not specified, None is assumed.)
        /// </summary>
        [JsonProperty(PropertyName = "equipment")]                
        public string Equipment { get; set; }

        /// <summary>
        /// The starting time for the activity (e.g., Sat, 1 Jan 2011 00:00:00).
        /// </summary>
        [JsonProperty(PropertyName = "start_time")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The total distance traveled, in meters (optional).
        /// </summary>
        [JsonProperty(PropertyName = "total_distance")]                
        public double TotalDistance { get; set; }

        /// <summary>
        /// The duration of the activity, in seconds
        /// </summary>
        [JsonProperty(PropertyName = "duration")]                
        public double Duration { get; set; }

        /// <summary>
        /// The user’s average heart rate, in beats per minute (optional).
        /// </summary>
        [JsonProperty(PropertyName = "average_heart_rate")]                
        public int? AverageHeartRate { get; set; }

        /// <summary>
        /// The sequence of time-stamped heart rate measurements (optional).
        /// </summary>
        [JsonProperty(PropertyName = "heart_rate")]                
        public List<HeartRateModel> HeartRate { get; set; }

        /// <summary>
        /// The total calories burned (optional).
        /// </summary>
        [JsonProperty(PropertyName = "total_calories")]                
        public double? TotalCalories { get; set; }

        /// <summary>
        /// Any notes that the user has associated with the activity.
        /// </summary>
        [JsonProperty(PropertyName = "notes")]                
        public string Notes { get; set; }

        /// <summary>
        /// The sequence of geographical points along the route (optional).
        /// </summary>
        [JsonProperty(PropertyName = "path")]                
        public List<PathModel> Path { get; set; }

        /// <summary>
        /// True to post this activity to Facebook, false to prevent posting (optional; if not specified, the user’s default preference is used).
        /// </summary>
        [JsonProperty(PropertyName = "post_to_facebook")]                
        public bool? PostToFacebook { get; set; }

        /// <summary>
        /// True to post this activity to Twitter, false to prevent posting (optional; if not specified, the user’s default preference is used).
        /// </summary>
        [JsonProperty(PropertyName = "post_to_twitter")]                
        public bool? PostToTwitter { get; set; }

        /// <summary>
        /// True to automatically detect and insert pause points into the supplied path, false otherwise (optional; if not specified, no pause detection is performed).
        /// </summary>
        [JsonProperty(PropertyName = "detect_pauses")]                
        public bool? DetectPauses { get; set; }
    }
}