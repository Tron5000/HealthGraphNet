using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IWeightEndpoint
    {
        //Get Weight Feed
        FeedModel<WeightFeedItemModel> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        void GetFeedPageAsync(Action<FeedModel<WeightFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);   
        //Get Weight (Detailed)
        WeightPastModel GetWeight(string uri);
        void GetWeightAsync(Action<WeightPastModel> success, Action<HealthGraphException> failure, string uri);
        //Update Weight (Detailed)
        WeightPastModel UpdateWeight(WeightPastModel weightToUpdate);
        void UpdateWeightAsync(Action<WeightPastModel> success, Action<HealthGraphException> failure, WeightPastModel weightToUpdate);
        //Create Weight 
        string CreateWeight(WeightNewModel weightToCreate);
        void CreateWeightAsync(Action<string> success, Action<HealthGraphException> failure, WeightNewModel weightToCreate);
        //Delete Weight 
        void DeleteWeight(string uri);
        void DeleteWeightAsync(Action success, Action<HealthGraphException> failure, string uri);
    }
}