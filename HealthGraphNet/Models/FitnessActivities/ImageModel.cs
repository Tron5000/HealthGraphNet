using System;

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
        public double Timestamp { get; set; }
        
        /// <summary>
        /// The latitude, in degrees (values increase northward and decrease southward).
        /// </summary>
        public double Latitude { get; set; }
        
        /// <summary>
        /// The longitude, in degrees (values increase eastward and decrease westward).
        /// </summary>
        public double Longitude { get; set; }
        
        /// <summary>
        /// The URI of the image.
        /// </summary>
        public string Uri { get; set; }
        
        /// <summary>
        /// The URI of the thumbnail version of the image.
        /// </summary>
        public string ThumbnailUri { get; set; }
    }
}