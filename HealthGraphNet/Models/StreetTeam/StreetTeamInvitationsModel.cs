using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet.Models
{
    public class StreetTeamInvitationsModel
    {
        internal const string ContentType = "application/vnd.com.runkeeper.Invitation+json";

        /// <summary>
        /// The ID of the user to invite. 
        /// </summary>
        [JsonProperty(PropertyName = "userID")]
        public int UserID { get; set; }    
    }
}