using System;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The heart rate model used in conjunction with activity data.  Members that cannot be edited are marked as internal.
    /// </summary>      
    public class HeartRateModel
    {
        public double Timestamp { get; set; }
        public int HeartRate { get; set; }
    }
}