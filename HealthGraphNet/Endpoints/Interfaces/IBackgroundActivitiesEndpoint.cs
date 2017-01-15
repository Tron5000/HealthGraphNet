using System;
using HealthGraphNet.Models;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    public interface IBackgroundActivitiesEndpoint
    {
        //Get Background Activities Feed
        Task<FeedModel<BackgroundActivitiesFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        //Get Background Activity (Detailed)
        Task<BackgroundActivitiesPastModel> GetActivity(string uri);
        //Update Background Activity (Detailed)
        Task<BackgroundActivitiesPastModel> UpdateActivity(BackgroundActivitiesPastModel activityToUpdate);
        //Create Background Activity
        Task<string> CreateActivity(BackgroundActivitiesNewModel activityToCreate);
        //Delete Background Activity
        Task DeleteActivity(string uri);
    }
}