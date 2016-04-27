using System;
using System.Collections.Generic;
using System.Net;
using RestSharp.Portable;
using RestSharp.Portable.Serializers;
using HealthGraphNet.Models;
using HealthGraphNet.RestSharp;
using System.Net.Http;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    /// <summary>
    /// For http://developer.runkeeper.com/healthgraph/street-team
    /// </summary>
    public class StreetTeamEndpoint : IStreetTeamEndpoint
    {
        #region Fields and Properties

        private AccessTokenManagerBase _tokenManager;
        private UsersModel _user;

        #endregion      

        #region Constructors

        public StreetTeamEndpoint(AccessTokenManagerBase tokenManager, UsersModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion    

        #region IStreetTeamEndpoint

        public async Task<FeedModel<StreetTeamFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = ExtensionHelpers.CreateFeedPageRequest(_user.Team, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return await _tokenManager.Execute<FeedModel<StreetTeamFeedItemModel>>(request);
        }

        public async Task<StreetTeamModel> GetStreetTeam(string uri)
        {
            if (uri.Contains(_user.Team) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Team + " endpoint.");
            }
            var request = new RestRequest(uri, Method.GET);
            return await _tokenManager.Execute<StreetTeamModel>(request);
        }

        public async Task<string> CreateTeamInvitation(StreetTeamInvitationsModel invitationToCreate)
        {
            var request = PrepareTeamInvitationCreateRequest(invitationToCreate);
            return await _tokenManager.ExecuteCreate(request);
        }

        public async Task<string> CreateTeamInvitation(int userID)
        {
            return await CreateTeamInvitation(new StreetTeamInvitationsModel { UserID = userID });
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Prepares the request object to create a new model.
        /// </summary>
        /// <param name="invitationToCreate"></param>
        /// <returns></returns>
        private IRestRequest PrepareTeamInvitationCreateRequest(StreetTeamInvitationsModel invitationToCreate)
        {
            var request = new RestRequest(_user.Team, Method.POST);

            //Add body to the request
            request.AddParameter(StreetTeamInvitationsModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                userID = invitationToCreate.UserID
            }), ParameterType.RequestBody);
            return request;
        }

        #endregion
    }
}