using System;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The calories model used in conjunction with activity data.  Members that cannot be edited are marked as internal.
    /// </summary>      
    public class CaloriesModel
    {
        public double Timestamp { get; set; }
        public double Calories { get; set; }
    }
}