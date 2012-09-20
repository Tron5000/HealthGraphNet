using System;
using System.Collections.Generic;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// Contract that describes common properties between StrengthTrainingActivitiesNewModel and StrengthTrainingActivitiesPastModel.
    /// Used whenever most common properties between these two models need to be targeted (eg. validation).
    /// </summary>
    internal interface IStrengthTrainingActivitiesModel
    {
        DateTime StartTime { get; set; }

        double TotalCalories { get; set; }

        string Notes { get; set; }

        List<ExercisesModel> Exercises { get; set; }
    }
}