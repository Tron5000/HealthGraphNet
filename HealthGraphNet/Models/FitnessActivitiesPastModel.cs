using System;
using System.Collections.Generic;

namespace HealthGraphNet.Models
{
    public class FitnessActivitiesPastModel
    {
        internal const string ContentType = "application/vnd.com.runkeeper.FitnessActivity+json";
                
        /// <summary>
        /// The URI for this activity. Read only.
        /// </summary>
        public string Uri { get; internal set; }

        /// <summary>
        /// The unique ID of the user for the activity. Read only
        /// </summary>
        public int UserID { get; internal set; }

        /// <summary>
        /// The type of activity, as one of the following values: Running, Cycling, Mountain Biking, Walking, Hiking, Downhill Skiing, Cross-Country Skiing, Snowboarding, Skating, Swimming, Wheelchair, Rowing, Elliptical, Other.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The secondary type of the activity, as a free-form string (max. 64 characters). This field is used only if the type field is Other."
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
        /// The total distance traveled, in meters.
        /// </summary>
        public double TotalDistance { get; set; }

        /// <summary>
        /// The sequence of time-stamped distance measurements (empty if not available). Read only.
        /// </summary>
        public List<DistanceModel> Distance { get; internal set; }

        /// <summary>
        /// The duration of the activity, in seconds.
        /// </summary>
        public double Duration { get; set; }

        /// <summary>
        /// The user’s average heart rate, in beats per minute (omitted if not available).
        /// </summary>
        public int? AverageHeartRate { get; set; }

        /// <summary>
        /// The sequence of time-stamped heart rate measurements (empty if not available).
        /// </summary>
        public List<HeartRateModel> HeartRate { get; set; }

        /// <summary>
        /// The total calories burned.
        /// </summary>
        public double TotalCalories { get; set; }

        /// <summary>
        /// The sequence of time-stamped caloric burn measurements (empty if not available). Read only.
        /// </summary>
        public List<CaloriesModel> Calories { get; internal set; }

        /// <summary>
        /// The total elevation climbed over the course of the activity, in meters. Read only.
        /// </summary>
        public double Climb { get; internal set; }

        /// <summary>
        /// Any notes that the user has associated with the activity
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Whether this activity is currently being tracked via RunKeeper Live. Read only.
        /// </summary>
        public bool IsLive { get; internal set; }

        /// <summary>
        /// The sequence of geographical points along the route (empty for stationary activities).
        /// </summary>
        public List<PathModel> Path { get; set; }

        /// <summary>
        /// The sequence of images along the route (empty if not available). Read only.
        /// </summary>
        public List<ImageModel> Images { get; internal set; }

        /// <summary>
        /// The name of the application that last modified this activity. Read only.
        /// </summary>
        public string Source { get; internal set; }

        /// <summary>
        /// The URL of the user’s public, human-readable page for this activity. Read only.
        /// </summary>
        public string Activity { get; internal set; }

        /// <summary>
        /// The URI of the previous activity in the user’s fitness feed (omitted for the oldest activity). Read only.
        /// </summary>
        public string Previous { get; internal set; }

        /// <summary>
        /// The URI of the next activity in the user’s fitness feed (omitted for the most-recent activity). Read only.
        /// </summary>
        public string Next { get; internal set; }

        /// <summary>
        /// The URIs of the fitness activities closest in time to this activity for each street teammate (empty if no fitness activities have been recorded). Read only.
        /// </summary>
        public List<string> NearestTeammateFitnessActivities { get; internal set; }

        /// <summary>
        /// The URI of the strength training activity closest in time to this activity for the user (omitted if no strength training activities have been recorded). Read only.
        /// </summary>
        public string NearestStrengthTrainingActivity { get; internal set; }

        /// <summary>
        /// The URIs of the strength training activities closest in time to this activity for each street teammate (empty if no strength training activities have been recorded). Read only.
        /// </summary>
        public List<string> NearestTeammateStrengthTrainingActivities { get; internal set; }

        /// <summary>
        /// The URI of the background activity closest in time to this activity for the user (omitted if no background activities have been recorded). Read only.
        /// </summary>
        public string NearestBackgroundActivity { get; internal set; }

        /// <summary>
        /// The URIs of the background activities closest in time to this activity for each street teammate (empty if no background activities have been recorded). Read only.
        /// </summary>
        public List<string> NearestTeammateBackgroundActivities { get; internal set; }

        /// <summary>
        /// The URI of the sleep measurements closest in time to this activity for the user (omitted if no sleep measurements have been taken). Read only.
        /// </summary>
        public string NearestSleep { get; internal set; }

        /// <summary>
        /// The URIs of the sleep measurements closest in time to this activity for each street teammate (empty if no sleep measurements have been taken). Read only.
        /// </summary>
        public List<string> NearestTeammateSleep { get; internal set; }

        /// <summary>
        /// The URI of the nutrition measurement closest in time to this activity for the user (omitted if no nutrition measurements have been taken). Read only.
        /// </summary>
        public string NearestNutrition { get; internal set; }

        /// <summary>
        /// The URIs of the nutrition measurement closest in time to this activity for each street teammate (empty if no nutrition measurements have been taken). Read only.
        /// </summary>
        public List<string> NearestTeammateNutrition { get; internal set; }

        /// <summary>
        /// The URI of the weight measurement closest in time to this activity for the user (omitted if no weight measurements have been taken). Read only.
        /// </summary>
        public string NearestWeight { get; internal set; }

        /// <summary>
        /// The URIs of the weight measurements closest in time to this activity for each street teammate (empty if no weight measurements have been taken). Read only
        /// </summary>
        public List<string> NearestTeammateWeight { get; internal set; }

        /// <summary>
        /// The URI of the general measurement measurement closest in time to this activity for the user (omitted if no general measurements have been taken). Read only.
        /// </summary>
        public string NearestGeneralMeasurement { get; internal set; }

        /// <summary>
        /// The URIs of the general measurements closest in time to this activity for each street teammate (empty if no general measurements have been taken). Read only.
        /// </summary>
        public List<string> NearestTeammateGeneralMeasurements { get; internal set; }

        /// <summary>
        /// The URI of the diabetes measurement closest in time to this activity for the user (omitted if no diabetes measurements have been taken). Read only.
        /// </summary>
        public string NearestDiabetes { get; internal set; }

        /// <summary>
        /// The URIs of the diabetes measurements closest in time to this activity for each street teammate (empty if no diabetes measurements have been taken). Read only.
        /// </summary>
        public List<string> NearestTeammateDiabetes { get; internal set; }
    }
}