using System;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    public class CommentsNewModel
    {
        internal const string ContentType = "application/vnd.com.runkeeper.Comment+json";

        /// <summary>
        /// The comment.
        /// </summary>
        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }
    }
}