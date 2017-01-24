using System;
using System.Collections.Generic;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// Contract that describes common properties between FitnessActivitiesNewModel and FitnessActivitiesPastModel.
    /// Used whenever most common properties between these two models need to be targeted (eg. validation).
    /// </summary>
    internal interface IFitnessActivitiesModel
    {
        FitnessActivityType Type { get; }

        string SecondaryType { get; set; }

        string Equipment { get; set; }

        DateTime StartTime { get; }

        double TotalDistance { get; }

        double Duration { get; }

        int? AverageHeartRate { get; }

        List<HeartRateModel> HeartRate { get; }

        string Notes { get; }

        List<PathModel> Path { get; }
    }
}