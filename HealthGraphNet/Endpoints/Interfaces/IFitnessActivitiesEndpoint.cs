using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IFitnessActivitiesEndpoint
    {
        //Get Activity Feed
        FitnessActivitiesFeedModel GetMostRecentFeedPage(int? pageIndex, int? pageSize, DateTime? noEarlierThan, DateTime? noLaterThan, DateTime? modifiedNoEarlierThan, DateTime? modifiedNoLaterThan);
        void GetMostRecentFeedPageAsync(Action<FitnessActivitiesFeedModel> success, Action<HealthGraphException> failure, int? pageIndex, int? pageSize, DateTime? noEarlierThan, DateTime? noLaterThan, DateTime? modifiedNoEarlierThan, DateTime? modifiedNoLaterThan);
        FitnessActivitiesFeedModel GetNextFeedPage(FitnessActivitiesFeedModel currentFeedPage);
        void GetNextFeedPageAsync(Action<FitnessActivitiesFeedModel> success, Action<HealthGraphException> failure, FitnessActivitiesFeedModel currentFeedPage);
        FitnessActivitiesFeedModel GetPrevFeedPage(FitnessActivitiesFeedModel currentFeedPage);
        void GetPrevFeedPageAsync(Action<FitnessActivitiesFeedModel> success, Action<HealthGraphException> failure, FitnessActivitiesFeedModel currentFeedPage);
        //Get Activity (Detailed)
        FitnessActivitiesModel GetActivity(FitnessActivitiesFeedItemModel currentFeedItem);
        void GetActivityAsync(Action<FitnessActivitiesModel> success, Action<HealthGraphException> failure, FitnessActivitiesFeedItemModel currentFeedItem);
        FitnessActivitiesModel GetNextActivity(FitnessActivitiesModel currentActivity);
        void GetNextActivityAsync(Action<FitnessActivitiesModel> success, Action<HealthGraphException> failure, FitnessActivitiesModel currentActivity);
        FitnessActivitiesModel GetPrevActivity(FitnessActivitiesModel currentActivity);
        void GetPrevActivityAsync(Action<FitnessActivitiesModel> success, Action<HealthGraphException> failure, FitnessActivitiesModel currentActivity);
        //Update Activity
        FitnessActivitiesModel UpdateActivity(FitnessActivitiesModel activityToUpdate);
        void UpdateSettingsAsync(Action<FitnessActivitiesModel> success, Action<HealthGraphException> failure, FitnessActivitiesModel activityToUpdate);
    }
}