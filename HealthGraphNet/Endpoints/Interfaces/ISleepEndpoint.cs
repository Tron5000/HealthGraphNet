using System;
using HealthGraphNet.Models;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    public interface ISleepEndpoint
    {
        //Get Sleep Feed
        Task<FeedModel<SleepFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        //Get Sleep (Detailed)
        Task<SleepPastModel> GetSleep(string uri);
        //Update Sleep (Detailed)
        Task<SleepPastModel> UpdateSleep(SleepPastModel sleepToUpdate);
        //Create Sleep
        Task<string> CreateSleep(SleepNewModel sleepToCreate);
        //Delete Sleep
        Task DeleteSleep(string uri);
    }
}