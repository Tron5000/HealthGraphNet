using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IFitnessActivitiesEndpoint
    {
        //Get Activity Feed
        FitnessActivitiesFeedPageModel GetMostRecentFeedPage(int? pageIndex, int? pageSize, DateTime? noEarlierThan, DateTime? noLaterThan, DateTime? modifiedNoEarlierThan, DateTime? modifiedNoLaterThan);
        void GetMostRecentFeedPageAsync(Action<FitnessActivitiesFeedPageModel> success, Action<HealthGraphException> failure, int? pageIndex, int? pageSize, DateTime? noEarlierThan, DateTime? noLaterThan, DateTime? modifiedNoEarlierThan, DateTime? modifiedNoLaterThan);
        FitnessActivitiesFeedPageModel GetNextFeedPage(FitnessActivitiesFeedPageModel currentFeedPage);
        void GetNextFeedPageAsync(Action<FitnessActivitiesFeedPageModel> success, Action<HealthGraphException> failure, FitnessActivitiesFeedPageModel currentFeedPage);
        FitnessActivitiesFeedPageModel GetPrevFeedPage(FitnessActivitiesFeedPageModel currentFeedPage);
        void GetPrevFeedPageAsync(Action<FitnessActivitiesFeedPageModel> success, Action<HealthGraphException> failure, FitnessActivitiesFeedPageModel currentFeedPage);
        //Get Activity (Detailed)
        FitnessActivitiesModel GetActivity(FitnessActivitiesFeedItemModel currentFeedItem);
        void GetActivityAsync(Action<FitnessActivitiesModel> success, Action<HealthGraphException> failure, FitnessActivitiesFeedItemModel currentFeedItem);
        FitnessActivitiesModel GetNextActivity(FitnessActivitiesModel currentActivity);
        void GetNextActivityAsync(Action<FitnessActivitiesModel> success, Action<HealthGraphException> failure, FitnessActivitiesModel currentActivity);
        FitnessActivitiesModel GetPrevActivity(FitnessActivitiesModel currentActivity);
        void GetPrevActivityAsync(Action<FitnessActivitiesModel> success, Action<HealthGraphException> failure, FitnessActivitiesModel currentActivity);
    }
}