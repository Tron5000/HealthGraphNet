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
        FitnessActivitiesModel GetActivity(string uri);
        void GetActivityAsync(Action<FitnessActivitiesModel> success, Action<HealthGraphException> failure, string uri);
        //Update Activity (Detailed
        FitnessActivitiesModel UpdateActivity(FitnessActivitiesModel activityToUpdate);
        void UpdateSettingsAsync(Action<FitnessActivitiesModel> success, Action<HealthGraphException> failure, FitnessActivitiesModel activityToUpdate);
    }
}