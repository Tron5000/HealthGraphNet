using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface INutritionEndpoint
    {
        //Get Nutrition Feed
        FeedModel<NutritionFeedItemModel> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        void GetFeedPageAsync(Action<FeedModel<NutritionFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        //Get Nutrition (Detailed)
        NutritionPastModel GetNutrition(string uri);
        void GetNutritionAsync(Action<NutritionPastModel> success, Action<HealthGraphException> failure, string uri);
        //Update Nutrition (Detailed)
        NutritionPastModel UpdateNutrition(NutritionPastModel nutritionToUpdate);
        void UpdateNutritionAsync(Action<NutritionPastModel> success, Action<HealthGraphException> failure, NutritionPastModel nutritionToUpdate);
        //Create Nutrition
        string CreateNutrition(NutritionNewModel nutritionToCreate);
        void CreateNutritionAsync(Action<string> success, Action<HealthGraphException> failure, NutritionNewModel nutritionToCreate);
        //Delete Nutrition
        void DeleteNutrition(string uri);
        void DeleteNutritionAsync(Action success, Action<HealthGraphException> failure, string uri);
    }
}