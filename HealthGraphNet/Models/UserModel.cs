using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The user model.
    /// </summary>
    public class UserModel
    {
        internal const string ContentType = "application/vnd.com.runkeeper.User+json";        
        
        /// <summary>
        /// The unique ID for the user. Read only.
        /// </summary>
        public int UserID { get; internal set; }

        /// <summary>
        /// The URI of the user profile resource. Read only.
        /// </summary>
        public string Profile { get; internal set; }

        /// <summary>
        /// The URI of the sharing and display settings resource. Read only.
        /// </summary>
        public string Settings { get; internal set; }

        /// <summary>
        /// The URI of the first page of the fitness activity feed. Read only.
        /// </summary>
        public string FitnessActivities { get; internal set; }

        /// <summary>
        /// The URI of the first page of the strength training activity feed. Read only.
        /// </summary>
        public string StrengthTrainingActivities { get; internal set; }

        /// <summary>
        /// The URI of the first page of the background activity feed. Read only.
        /// </summary>
        public string BackgroundActivities { get; internal set; }

        /// <summary>
        /// The URI of the first page of the sleep feed. Read only.
        /// </summary>
        public string Sleep { get; internal set; }

        /// <summary>
        /// The URI of the first page of the nutrition feed. Read only.
        /// </summary>
        public string Nutrition { get; internal set; }

        /// <summary>
        /// The URI of the first page of the weight measurement feed. Read only.
        /// </summary>
        public string Weight { get; internal set; }

        /// <summary>
        /// The URI of the first page of the general measurements feed. Read only.
        /// </summary>
        public string GeneralMeasurements { get; internal set; }    

        /// <summary>
        /// The URI of the first page of the diabetes measurements feed. Read only.
        /// </summary>
        public string Diabetes { get; internal set; }

        /// <summary>
        /// The URI of the personal records resource. Read only.
        /// </summary>
        public string Records { get; internal set; } 

        /// <summary>
        /// The URI of the street team resource. Read only.
        /// </summary>
        public string Team { get; internal set; }                                    
    }
}