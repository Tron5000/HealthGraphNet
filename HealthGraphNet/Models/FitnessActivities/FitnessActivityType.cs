using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// Type of fitness activity
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FitnessActivityType
    {
        [EnumMember(Value = "Running")]
        Running,
        [EnumMember(Value = "Cycling")]
        Cycling,
        [EnumMember(Value = "Mountain Biking")]
        MountainBiking,
        [EnumMember(Value = "Walking")]
        Walking,
        [EnumMember(Value = "Hiking")]
        Hiking,
        [EnumMember(Value = "Downhill Skiing")]
        DownhillSkiing,
        [EnumMember(Value = "Cross-Country Skiing")]
        CrossCountrySkiing,
        [EnumMember(Value = "Snowboarding")]
        Snowboarding,
        [EnumMember(Value = "Skating")]
        Skating,
        [EnumMember(Value = "Swimming")]
        Swimming,
        [EnumMember(Value = "Wheelchair")]
        Wheelchair,
        [EnumMember(Value = "Rowing")]
        Rowing,
        [EnumMember(Value = "Elliptical")]
        Elliptical,
        [EnumMember(Value = "Other")]
        Other,
        [EnumMember(Value = "Yoga")]
        Yoga,
        [EnumMember(Value = "Pilates")]
        Pilates,
        [EnumMember(Value = "CrossFit")]
        CrossFit,
        [EnumMember(Value = "Spinning")]
        Spinning,
        [EnumMember(Value = "Zumba")]
        Zumba,
        [EnumMember(Value = "Barre")]
        Barre,
        [EnumMember(Value = "Group Workout")]
        GroupWorkout,
        [EnumMember(Value = "Dance")]
        Dance,
        [EnumMember(Value = "Bootcamp")]
        Bootcamp,
        [EnumMember(Value = "Boxing / MMA")]
        BoxingMMA,
        [EnumMember(Value = "Meditation")]
        Meditation,
        [EnumMember(Value = "Strength Training")]
        StrengthTraining,
        [EnumMember(Value = "Circuit Training")]
        CircuitTraining,
        [EnumMember(Value = "Core Strengthening")]
        CoreStrengthening,
        [EnumMember(Value = "Arc Trainer")]
        ArcTrainer,
        [EnumMember(Value = "Stairmaster / Stepwell")]
        StairmasterStepwell,
        [EnumMember(Value = "Sports")]
        Sports,
        [EnumMember(Value = "Nordic Walking")]
        NordicWalking
    }
}
