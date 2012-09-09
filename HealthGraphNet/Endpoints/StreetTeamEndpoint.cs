using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;
using RestSharp.Validation;
using RestSharp.Serializers;
using HealthGraphNet.Models;
using HealthGraphNet.RestSharp;

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

        public FeedModel<StreetTeamFeedItemModel> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = new RestRequest();
            request.PrepareFeedPageRequest(_user.Team, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return _tokenManager.Execute<FeedModel<StreetTeamFeedItemModel>>(request);
        }

        public void GetFeedPageAsync(Action<FeedModel<StreetTeamFeedItemModel>> success, Action<HealthGraphException> failure, int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = new RestRequest();
            request.PrepareFeedPageRequest(_user.Team, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            _tokenManager.ExecuteAsync<FeedModel<StreetTeamFeedItemModel>>(request, success, failure);
        }

        public StreetTeamModel GetStreetTeam(string uri)
        {
            if (uri.Contains(_user.Team) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Team + " endpoint.");
            }
            var request = new RestRequest(Method.GET);
            request.Resource = uri;
            return _tokenManager.Execute<StreetTeamModel>(request);
        }

        public void GetStreetTeamAsync(Action<StreetTeamModel> success, Action<HealthGraphException> failure, string uri)
        {
            if (uri.Contains(_user.Team) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.Team + " endpoint.");
            }
            var request = new RestRequest(Method.GET);
            request.Resource = uri;
            _tokenManager.ExecuteAsync<StreetTeamModel>(request, success, failure);
        }

        public string CreateTeamInvitation(StreetTeamInvitationsModel invitationToCreate)
        {
            var request = PrepareTeamInvitationCreateRequest(invitationToCreate);
            return _tokenManager.ExecuteCreate(request);
        }

        public string CreateTeamInvitation(int userID)
        {
            return CreateTeamInvitation(new StreetTeamInvitationsModel { UserID = userID });
        }

        public void CreateTeamInvitationAsync(Action<string> success, Action<HealthGraphException> failure, StreetTeamInvitationsModel invitationToCreate)
        {
            var request = PrepareTeamInvitationCreateRequest(invitationToCreate);            
            _tokenManager.ExecuteCreateAsync(request, success, failure);
        }

        public void CreateTeamInvitationAsync(Action<string> success, Action<HealthGraphException> failure, int userID)
        {
            CreateTeamInvitationAsync(success, failure, new StreetTeamInvitationsModel { UserID = userID });
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
            var request = new RestRequest(Method.POST);
            request.Resource = _user.Team;

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