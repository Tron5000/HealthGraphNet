using System;
using System.Collections.Generic;

namespace HealthGraphNet.Models
{
    public class FitnessActivitiesNewModel : IFitnessActivitiesModel
    {
        internal const string ContentType = "application/vnd.com.runkeeper.NewFitnessActivity+json";

        /// <summary>
        /// The type of activity, as one of the following values: Running, Cycling, Mountain Biking, Walking, Hiking, Downhill Skiing, Cross-Country Skiing, Snowboarding, Skating, Swimming, Wheelchair, Rowing, Elliptical, Other.
        /// </summary>
        public string Type { get; set; }
    
        /// <summary>
        /// The secondary type of the activity, as a free-form string (max. 64 characters). This field is used only if the type field is "Other."
        /// </summary>
        public string SecondaryType { get; set; }

        /// <summary>
        /// The equipment used to complete this activity, as one of the following values: None, Treadmill, Stationary Bike, Elliptical, Row Machine. (Optional; if not specified, None is assumed.)
        /// </summary>
        public string Equipment { get; set; }

        /// <summary>
        /// The starting time for the activity (e.g., Sat, 1 Jan 2011 00:00:00).
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The total distance traveled, in meters (optional).
        /// </summary>
        public double TotalDistance { get; set; }

        /// <summary>
        /// The duration of the activity, in seconds
        /// </summary>
        public double Duration { get; set; }

        /// <summary>
        /// The user’s average heart rate, in beats per minute (optional).
        /// </summary>
        public int? AverageHeartRate { get; set; }

        /// <summary>
        /// The sequence of time-stamped heart rate measurements (optional).
        /// </summary>
        public List<HeartRateModel> HeartRate { get; set; }

        /// <summary>
        /// The total calories burned (optional).
        /// </summary>
        public double? TotalCalories { get; set; }

        /// <summary>
        /// Any notes that the user has associated with the activity.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// The sequence of geographical points along the route (optional).
        /// </summary>
        public List<PathModel> Path { get; set; }

        /// <summary>
        /// True to post this activity to Facebook, false to prevent posting (optional; if not specified, the user’s default preference is used).
        /// </summary>
        public bool? PostToFacebook { get; set; }

        /// <summary>
        /// True to post this activity to Twitter, false to prevent posting (optional; if not specified, the user’s default preference is used).
        /// </summary>
        public bool? PostToTwitter { get; set; }

        /// <summary>
        /// True to automatically detect and insert pause points into the supplied path, false otherwise (optional; if not specified, no pause detection is performed).
        /// </summary>
        public bool? DetectPauses { get; set; }
    }
}