using System;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The fitness activities feed item model used in conjunction with activity data.
    /// </summary>
    public class FitnessActivitiesFeedItemModel
    {
        /// <summary>
        /// The type of activity, as one of the following values: Running, Cycling, Mountain Biking, Walking, Hiking, Downhill Skiing, Cross-Country Skiing, Snowboarding, Skating, Swimming, Wheelchair, Rowing, Elliptical, Other. Read only.
        /// </summary>
        public string Type { get; internal set; }
        
        /// <summary>
        /// The starting time for the activity (e.g., Sat, 1 Jan 2011 00:00:00).  Read only.
        /// </summary>
        public DateTime StartTime { get; internal set; }
        
        /// <summary>
        /// The total distance for the activity, in meters.  Read only.
        /// </summary>
        public double TotalDistance { get; internal set; }
        
        /// <summary>
        /// The duration of the activity, in seconds.  Read only.
        /// </summary>
        public double Duration { get; internal set; }
        
        /// <summary>
        /// The URI of the detailed information for the past activity.  Read only.
        /// </summary>
        public string Uri { get; internal set; }
    }
}