using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IBackgroundActivitiesEndpoint
    {
        //Get Background Activities Feed
        FeedModel<BackgroundActivitiesFeedItemModel> GetFeedPage(int? pageIndex, int? pageSize, DateTime? noEarlierThan, DateTime? noLaterThan, DateTime? modifiedNoEarlierThan, DateTime? modifiedNoLaterThan);
        void GetFeedPageAsync(Action<FeedModel<BackgroundActivitiesFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex, int? pageSize, DateTime? noEarlierThan, DateTime? noLaterThan, DateTime? modifiedNoEarlierThan, DateTime? modifiedNoLaterThan);
        //Get Background Activity (Detailed)
        BackgroundActivitiesPastModel GetActivity(string uri);
        void GetActivityAsync(Action<BackgroundActivitiesPastModel> success, Action<HealthGraphException> failure, string uri);
        //Update Background Activity (Detailed)
        BackgroundActivitiesPastModel UpdateActivity(BackgroundActivitiesPastModel activityToUpdate);
        void UpdateActivityAsync(Action<BackgroundActivitiesPastModel> success, Action<HealthGraphException> failure, BackgroundActivitiesPastModel activityToUpdate);
        //Create Background Activity
        string CreateActivity(BackgroundActivitiesNewModel activityToCreate);
        void CreateActivityAsync(Action<string> success, Action<HealthGraphException> failure, BackgroundActivitiesNewModel activityToCreate);
        //Delete Background Activity
        void DeleteActivity(string uri);
        void DeleteActivityAsync(Action success, Action<HealthGraphException> failure, string uri);
    }
}