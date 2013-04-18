using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IBackgroundActivitiesEndpoint
    {
        //Get Background Activities Feed
        FeedModel<BackgroundActivitiesFeedItemModel> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        void GetFeedPageAsync(Action<FeedModel<BackgroundActivitiesFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
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