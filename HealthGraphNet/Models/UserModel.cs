using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The user model.  Members that cannot be edited are marked as internal.
    /// </summary>
    public class UserModel
    {
        public string StrengthTrainingActivities { get; internal set; }
        public string Weight { get; internal set; }
        public string Settings { get; internal set; }
        public string Diabetes { get; internal set; }
        public string Team { get; internal set; }
        public string Sleep { get; internal set; }
        public string FitnessActivities { get; internal set; }
        public string UserID { get; internal set; }
        public string Nutrition { get; internal set; }
        public string GeneralMeasurements { get; internal set; }
        public string BackgroundActivities { get; internal set; }
        public string Records { get; internal set; }
        public string Profile { get; internal set; }
    }
}