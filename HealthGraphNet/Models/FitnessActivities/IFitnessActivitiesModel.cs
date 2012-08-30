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
        string Type { get; set; }

        string SecondaryType { get; set; }

        string Equipment { get; set; }

        DateTime StartTime { get; set; }

        double TotalDistance { get; set; }

        double Duration { get; set; }

        int? AverageHeartRate { get; set; }

        List<HeartRateModel> HeartRate { get; set; }

        string Notes { get; set; }

        List<PathModel> Path { get; set; }
    }
}