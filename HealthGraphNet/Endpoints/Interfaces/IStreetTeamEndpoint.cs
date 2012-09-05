using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IStreetTeamEndpoint
    {
        //Get Street Team Feed
        FeedModel<StreetTeamFeedItemModel> GetFeedPage(int? pageIndex, int? pageSize, DateTime? noEarlierThan, DateTime? noLaterThan, DateTime? modifiedNoEarlierThan, DateTime? modifiedNoLaterThan);
        void GetFeedPageAsync(Action<FeedModel<StreetTeamFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex, int? pageSize, DateTime? noEarlierThan, DateTime? noLaterThan, DateTime? modifiedNoEarlierThan, DateTime? modifiedNoLaterThan);
    }
}