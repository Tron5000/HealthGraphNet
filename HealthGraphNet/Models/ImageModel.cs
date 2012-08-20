using System;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The image model used in conjunction with activity data.  Members that cannot be edited are marked as internal.
    /// </summary>        
    public class ImageModel
    {
        public double Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Uri { get; set; }
        public string ThumbnailUri { get; set; }
    }
}