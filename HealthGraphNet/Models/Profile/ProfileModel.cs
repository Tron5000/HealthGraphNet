using System;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The profile model.
    /// </summary>
    public class ProfileModel
    {
        internal const string ContentType = " application/vnd.com.runkeeper.Profile+json";        
        
        /// <summary>
        /// The user's full name (omitted if not yet specified). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "name")]        
        public string Name { get; internal set; }
        
        /// <summary>
        /// The user's geographical location (omitted if not yet specified). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "location")]                
        public string Location { get; internal set; }
        
        /// <summary>
        /// One of the following values: Athlete, Runner, Marathoner, Ultra Marathoner, Cyclist, Tri-Athlete, Walker, Hiker, Skier, Snowboarder, Skater, Swimmer, Rower (omitted if not yet specified).
        /// </summary>
        [JsonProperty(PropertyName = "athlete_type")]                
        public string AthleteType { get; set; }
        
        /// <summary>
        /// One of the following values: M, F (omitted if not yet specified). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "gender")]                
        public string Gender { get; internal set; }
        
        /// <summary>
        /// The user's birthday (e.g., Sat, 1 Jan 2011 00:00:00) (omitted if not yet specified). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "birthday")]                
        public DateTime? Birthday { get; internal set; }
        
        /// <summary>
        /// true if the user subscribes to RunKeeper Elite, false otherwise. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "elite")]                
        public bool Elite { get; internal set; }
        
        /// <summary>
        /// The URL of the user's public, human-readable profile on the RunKeeper Web site. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "profile")]                
        public string Profile { get; internal set; }
        
        /// <summary>
        /// The URI of the small (50×50 pixels) version of the user's profile picture on the RunKeeper Web site (omitted if the user has no such picture). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "small_picture")]                
        public string SmallPicture { get; internal set; }
        
        /// <summary>
        /// The URI of the small (100×100 pixels) version of the user's profile picture on the RunKeeper Web site (omitted if the user has no such picture). Read only.
        /// </summary>
        [JsonProperty(PropertyName = "normal_picture")]                
        public string NormalPicture { get; internal set; }
        
        /// <summary>
        /// The URI of the small (200×600 pixels) version of the user's profile picture on the RunKeeper Web site (omitted if the user has no such picture) Note: The image may be shorter than 600 pixels in height if the user has provided a smaller picture. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "medium_picture")]                
        public string MediumPicture { get; internal set; }
        
        /// <summary>
        /// The URI of the small (600×1800 pixels) version of the user's profile picture on the RunKeeper Web site (omitted if the user has no such picture) Note: The image may be shorter than 1800 pixels in height if the user has provided a smaller picture. Read only.
        /// </summary>
        [JsonProperty(PropertyName = "large_picture")]                
        public string LargePicture { get; internal set; }
    }
}