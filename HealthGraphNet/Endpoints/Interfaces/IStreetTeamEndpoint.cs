using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IStreetTeamEndpoint
    {
        //Get Street Team Feed
        FeedModel<StreetTeamFeedItemModel> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        void GetFeedPageAsync(Action<FeedModel<StreetTeamFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        //Get Street Team (Detailed)
        StreetTeamModel GetStreetTeam(string uri);
        void GetStreetTeamAsync(Action<StreetTeamModel> success, Action<HealthGraphException> failure, string uri);
        //Invitation
        string CreateTeamInvitation(StreetTeamInvitationsModel invitationToCreate);
        string CreateTeamInvitation(int userID);
        void CreateTeamInvitationAsync(Action<string> success, Action<HealthGraphException> failure, StreetTeamInvitationsModel invitationToCreate);
        void CreateTeamInvitationAsync(Action<string> success, Action<HealthGraphException> failure, int userID);
    }
}