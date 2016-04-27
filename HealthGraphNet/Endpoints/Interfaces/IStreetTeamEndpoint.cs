using System;
using HealthGraphNet.Models;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    public interface IStreetTeamEndpoint
    {
        //Get Street Team Feed
        Task<FeedModel<StreetTeamFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null);
        //Get Street Team (Detailed)
        Task<StreetTeamModel> GetStreetTeam(string uri);
        //Invitation
        Task<string> CreateTeamInvitation(StreetTeamInvitationsModel invitationToCreate);
        Task<string> CreateTeamInvitation(int userID);
    }
}