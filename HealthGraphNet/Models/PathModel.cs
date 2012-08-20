using System;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The path model used in conjunction with activity data to record geographical points.  Members that cannot be edited are marked as internal.
    /// </summary>    
    public class PathModel
    {
        public double Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public string Type { get; set; }    
    }
}