using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IStreetTeamEndpoint
    {
        //Get Street Team Feed
        FeedModel<StreetTeamFeedItemModel> GetFeedPage(int? pageIndex, int? pageSize, DateTime? noEarlierThan, DateTime? noLaterThan, DateTime? modifiedNoEarlierThan, DateTime? modifiedNoLaterThan);
        void GetFeedPageAsync(Action<FeedModel<StreetTeamFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex, int? pageSize, DateTime? noEarlierThan, DateTime? noLaterThan, DateTime? modifiedNoEarlierThan, DateTime? modifiedNoLaterThan);
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