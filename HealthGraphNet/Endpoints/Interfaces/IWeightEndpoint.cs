using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IWeightEndpoint
    {
        //Get Weight Feed
        FeedModel<WeightFeedItemModel> GetFeedPage(int? pageIndex, int? pageSize, DateTime? noEarlierThan, DateTime? noLaterThan, DateTime? modifiedNoEarlierThan, DateTime? modifiedNoLaterThan);
        void GetFeedPageAsync(Action<FeedModel<WeightFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex, int? pageSize, DateTime? noEarlierThan, DateTime? noLaterThan, DateTime? modifiedNoEarlierThan, DateTime? modifiedNoLaterThan);   
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