using System;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The image model used in conjunction with activity data.
    /// </summary>        
    public class ImageModel
    {
        /// <summary>
        /// The number of seconds since the start of the activity.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public double Timestamp { get; set; }
        
        /// <summary>
        /// The latitude, in degrees (values increase northward and decrease southward).
        /// </summary>
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }
        
        /// <summary>
        /// The longitude, in degrees (values increase eastward and decrease westward).
        /// </summary>
        [JsonProperty(PropertyName = "longitude")]        
        public double Longitude { get; set; }
        
        /// <summary>
        /// The URI of the image.
        /// </summary>
        [JsonProperty(PropertyName = "uri")]        
        public string Uri { get; set; }
        
        /// <summary>
        /// The URI of the thumbnail version of the image.
        /// </summary>
        [JsonProperty(PropertyName = "thumbnail_uri")]        
        public string ThumbnailUri { get; set; }
    }
}