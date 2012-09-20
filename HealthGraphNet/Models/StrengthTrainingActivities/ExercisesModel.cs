using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    public class ExercisesModel
    {
        /// <summary>
        /// The primary exercise type, as one of the following values: Barbell Curl, Dumbbell Curl, Barbell Tricep Press, Dumbbell Tricep Press, Overhead Press, Wrist Curl, Tricep Kickback, Bench Press, Cable Crossover, Dumbbell Fly, Incline Bench, Dips, Pushup, Pullup, Back Raise, Bent-Over Row, Seated Row, Chinup, Lat Pulldown, Seated Reverse Fly, Military Press, Upright Row, Front Raise, Side Lateral Raise, Snatch, Push Press, Shrug, Crunch Machine, Crunch, Ab Twist, Bicycle Kick, Hanging Leg Raise, Hanging Knee Raise, Reverse Crunch, V Up, Situp, Squat, Lunge, Dead Lift, Hamstring Curl, Good Morning, Clean, Leg Press, Leg Extension, Other.
        /// </summary>
        [JsonProperty(PropertyName = "primary_type")]
        public string PrimaryType { get; set; }

        /// <summary>
        /// The secondary exercise type (optional; provides greater detail as free-form text if supplied).
        /// </summary>
        [JsonProperty(PropertyName = "secondary_type")]
        public string SecondaryType { get; set; }

        /// <summary>
        /// The primary muscle group, as one of the following values: Arms, Chest, Back, Shoulders, Abs, Legs.
        /// </summary>
        [JsonProperty(PropertyName = "primary_muscle_group")]
        public string PrimaryMuscleGroup { get; set; }

        /// <summary>
        /// The secondary muscle group, as one of the following values: Arms, Chest, Back, Shoulders, Abs, Legs (optional).
        /// </summary>
        [JsonProperty(PropertyName = "secondary_muscle_group")]
        public string SecondaryMuscleGroup { get; set; }

        /// <summary>
        /// Free-form tag for the routine of which this exercise is a part (max. 32 characters; optional).
        /// </summary>
        [JsonProperty(PropertyName = "routine")]
        public string Routine { get; set; }

        /// <summary>
        /// Any notes for this exercise (max. 1024 characters; optional).
        /// </summary>
        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }

        /// <summary>
        /// The sets performed during this exercise.
        /// </summary>
        [JsonProperty(PropertyName = "sets")]
        public List<SetsModel> Sets { get; set; }
    }
}