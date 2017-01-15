using System;
using HealthGraphNet.Models;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    public interface IFitnessActivitiesEndpoint
    {
        //Get Activity Feed
        Task<FeedModel<FitnessActivitiesFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        //Get Activity (Detailed)
        Task<FitnessActivitiesPastModel> GetActivity(string uri);
        //Update Activity (Detailed)
        Task<FitnessActivitiesPastModel> UpdateActivity(FitnessActivitiesPastModel activityToUpdate);
        //Create Activity
        Task<string> CreateActivity(FitnessActivitiesNewModel activityToCreate);
        //Delete Activity
        Task DeleteActivity(string uri);
    }
}