using System;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The heart rate model used in conjunction with activity data.
    /// </summary>      
    public class HeartRateModel
    {
        /// <summary>
        /// The number of seconds since the start of the activity.
        /// </summary>
        public double Timestamp { get; set; }
        
        /// <summary>
        /// The instantaneous heart rate, in beats per minute.
        /// </summary>
        public int HeartRate { get; set; }
    }
}