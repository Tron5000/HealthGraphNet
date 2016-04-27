using System;
using HealthGraphNet.Models;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    public interface INutritionEndpoint
    {
        //Get Nutrition Feed
        Task<FeedModel<NutritionFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        //Get Nutrition (Detailed)
        Task<NutritionPastModel> GetNutrition(string uri);
        //Update Nutrition (Detailed)
        Task<NutritionPastModel> UpdateNutrition(NutritionPastModel nutritionToUpdate);
        //Create Nutrition
        Task<string> CreateNutrition(NutritionNewModel nutritionToCreate);
        //Delete Nutrition
        Task DeleteNutrition(string uri);
    }
}