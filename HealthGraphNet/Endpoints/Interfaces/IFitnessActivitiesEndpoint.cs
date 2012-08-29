using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IFitnessActivitiesEndpoint
    {
        //Get Activity Feed
        FitnessActivitiesFeedModel GetFeedPage(int? pageIndex, int? pageSize, DateTime? noEarlierThan, DateTime? noLaterThan, DateTime? modifiedNoEarlierThan, DateTime? modifiedNoLaterThan);
        void GetFeedPageAsync(Action<FitnessActivitiesFeedModel> success, Action<HealthGraphException> failure, int? pageIndex, int? pageSize, DateTime? noEarlierThan, DateTime? noLaterThan, DateTime? modifiedNoEarlierThan, DateTime? modifiedNoLaterThan);
        //Get Activity (Detailed)
        FitnessActivitiesPastModel GetActivity(string uri);
        void GetActivityAsync(Action<FitnessActivitiesPastModel> success, Action<HealthGraphException> failure, string uri);
        //Update Activity (Detailed)
        FitnessActivitiesPastModel UpdateActivity(FitnessActivitiesPastModel activityToUpdate);
        void UpdateSettingsAsync(Action<FitnessActivitiesPastModel> success, Action<HealthGraphException> failure, FitnessActivitiesPastModel activityToUpdate);
        //Create Activity
        string CreateActivity(FitnessActivitiesNewModel activityToCreate);
        void CreateActivityAsync(Action<string> success, Action<HealthGraphException> failure, FitnessActivitiesNewModel activityToCreate);
        //Delete Activity
        void DeleteActivity(string uri);
        void DeleteActivityAsync(Action success, Action<HealthGraphException> failure, string uri);
    }
}