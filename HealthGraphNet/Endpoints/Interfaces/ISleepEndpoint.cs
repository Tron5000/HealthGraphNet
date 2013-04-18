using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface ISleepEndpoint
    {
        //Get Sleep Feed
        FeedModel<SleepFeedItemModel> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        void GetFeedPageAsync(Action<FeedModel<SleepFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);   
        //Get Sleep (Detailed)
        SleepPastModel GetSleep(string uri);
        void GetSleepAsync(Action<SleepPastModel> success, Action<HealthGraphException> failure, string uri);
        //Update Sleep (Detailed)
        SleepPastModel UpdateSleep(SleepPastModel sleepToUpdate);
        void UpdateSleepAsync(Action<SleepPastModel> success, Action<HealthGraphException> failure, SleepPastModel sleepToUpdate);
        //Create Sleep
        string CreateSleep(SleepNewModel sleepToCreate);
        void CreateSleepAsync(Action<string> success, Action<HealthGraphException> failure, SleepNewModel sleepToCreate);
        //Delete Sleep
        void DeleteSleep(string uri);
        void DeleteSleepAsync(Action success, Action<HealthGraphException> failure, string uri);
    }
}