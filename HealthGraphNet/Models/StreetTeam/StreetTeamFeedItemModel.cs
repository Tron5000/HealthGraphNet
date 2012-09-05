using System;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The street team feed item model used in conjunction with street team data.
    /// </summary>
    public class StreetTeamFeedItemModel : IFeedModelItem
    {
        /// <summary>
        /// The unique ID for the member. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "userID")]
        public int UserID { get; internal set; }

        /// <summary>
        /// The member’s full name. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; internal set; }

        /// <summary>
        /// The URL of the member’s public, human-readable profile on the RunKeeper website. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "profile")]
        public string Profile { get; internal set; }

        /// <summary>
        /// One of the following value: pending, member. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; internal set; }
    }
}