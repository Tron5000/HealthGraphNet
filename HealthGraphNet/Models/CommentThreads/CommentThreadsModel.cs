using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    public class CommentThreadsModel
    {
        internal const string ContentType = "application/vnd.com.runkeeper.CommentThread+json";

        /// <summary>
        /// The URI for this thread. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; internal set; }

        /// <summary>
        /// The unique ID for the user that completed the commented-on activity. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "userID")]
        public int UserID { get; internal set; }

        /// <summary>
        /// The comments. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "comments")]
        public List<CommentsModel> Comments { get; internal set; }
    }
}