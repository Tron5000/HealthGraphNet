using System;
using HealthGraphNet.Models;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    public interface IStrengthTrainingActivitiesEndpoint
    {
        //Get Strength Training Activity Feed
        Task<FeedModel<StrengthTrainingActivitiesFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        //Get Strength Training Activity (Detailed)
        Task<StrengthTrainingActivitiesPastModel> GetActivity(string uri);
        //Update Strength Training Activity (Detailed)
        Task<StrengthTrainingActivitiesPastModel> UpdateActivity(StrengthTrainingActivitiesPastModel activityToUpdate);
        //Create Activity
        Task<string> CreateActivity(StrengthTrainingActivitiesNewModel activityToCreate);
        //Delete Activity
        Task DeleteActivity(string uri);
    }
}