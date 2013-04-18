using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IFitnessActivitiesEndpoint
    {
        //Get Activity Feed
        FeedModel<FitnessActivitiesFeedItemModel> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        void GetFeedPageAsync(Action<FeedModel<FitnessActivitiesFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        //Get Activity (Detailed)
        FitnessActivitiesPastModel GetActivity(string uri);
        void GetActivityAsync(Action<FitnessActivitiesPastModel> success, Action<HealthGraphException> failure, string uri);
        //Update Activity (Detailed)
        FitnessActivitiesPastModel UpdateActivity(FitnessActivitiesPastModel activityToUpdate);
        void UpdateActivityAsync(Action<FitnessActivitiesPastModel> success, Action<HealthGraphException> failure, FitnessActivitiesPastModel activityToUpdate);
        //Create Activity
        string CreateActivity(FitnessActivitiesNewModel activityToCreate);
        void CreateActivityAsync(Action<string> success, Action<HealthGraphException> failure, FitnessActivitiesNewModel activityToCreate);
        //Delete Activity
        void DeleteActivity(string uri);
        void DeleteActivityAsync(Action success, Action<HealthGraphException> failure, string uri);
    }
}