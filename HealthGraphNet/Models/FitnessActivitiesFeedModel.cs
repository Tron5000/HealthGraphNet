using System;
using System.Collections.Generic;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The fitness activities feed model used in conjunction with activity data.
    /// </summary>
    public class FitnessActivitiesFeedModel
    {
        internal const string ContentType = " application/vnd.com.runkeeper.FitnessActivityFeed+json";
        
        /// <summary>
        /// The total number of fitness activities across all pages. Read only.
        /// </summary>
        public int Size { get; internal set; }
        
        /// <summary>
        /// The user’s activities, from newest to oldest. Read only.
        /// </summary>
        public List<FitnessActivitiesFeedItemModel> Items { get; internal set; }
        
        /// <summary>
        /// The URI of the previous page in the user’s feed (omitted for the oldest page). Read only.
        /// </summary>
        public string Previous { get; internal set; }
        
        /// <summary>
        /// The URI of the next page in the user’s feed (omitted for the newest page). Read only.
        /// </summary>
        public string Next { get; internal set; }
    }
}