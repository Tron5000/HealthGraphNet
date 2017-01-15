using System;
using HealthGraphNet.Models;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    public interface IWeightEndpoint
    {
        //Get Weight Feed
        Task<FeedModel<WeightFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        //Get Weight (Detailed)
        Task<WeightPastModel> GetWeight(string uri);
        //Update Weight (Detailed)
        Task<WeightPastModel> UpdateWeight(WeightPastModel weightToUpdate);
        //Create Weight 
        Task<string> CreateWeight(WeightNewModel weightToCreate);
        //Delete Weight 
        Task DeleteWeight(string uri);
    }
}