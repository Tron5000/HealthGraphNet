using System;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The profile model.  Members that cannot be edited are marked as internal.
    /// </summary>
    public class ProfileModel
    {
        public string Name { get; internal set; }
        public string Location { get; internal set; }
        public string AthleteType { get; set; }
        public string Gender { get; internal set; }
        public DateTime? Birthday { get; internal set; }
        public bool Elite { get; internal set; }
        public string Profile { get; internal set; }
        public string SmallPicture { get; internal set; }
        public string NormalPicture { get; internal set; }
        public string MediumPicture { get; internal set; }
        public string LargePicture { get; internal set; }
    }
}