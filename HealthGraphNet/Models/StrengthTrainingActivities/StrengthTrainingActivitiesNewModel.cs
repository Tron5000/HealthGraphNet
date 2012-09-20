using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HealthGraphNet.Models
{
    public class StrengthTrainingActivitiesNewModel : IStrengthTrainingActivitiesModel
    {
        internal const string ContentType = "application/vnd.com.runkeeper.NewStrengthTrainingActivity+json";
        
        /// <summary>
        /// The starting time for the activity (e.g., Sat, 1 Jan 2011 00:00:00).
        /// </summary>
        [JsonProperty(PropertyName = "start_time")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The total calories burned (omitted if not available).
        /// </summary>
        [JsonProperty(PropertyName = "total_calories")]
        public double TotalCalories { get; set; }

        /// <summary>
        /// Any notes that the user has associated with the activity (max. 1024 characters; optional).
        /// </summary>
        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }

        /// <summary>
        /// The exercises performed during this strength training activity.
        /// </summary>
        [JsonProperty(PropertyName = "exercises")]
        public List<ExercisesModel> Exercises { get; set; }

        /// <summary>
        /// True to post this activity to Facebook, false to prevent posting (optional; if not specified, the user's default preference is used).
        /// </summary>
        [JsonProperty(PropertyName = "post_to_facebook")]
        public bool? PostToFacebook { get; set; }

        /// <summary>
        /// True to post this activity to Twitter, false to prevent posting (optional; if not specified, the user's default preference is used).
        /// </summary>
        [JsonProperty(PropertyName = "post_to_twitter")]
        public bool? PostToTwitter { get; set; } 
    }
}