using System;
using RestSharp;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    /// <summary>
    /// Endpoint for retrieving the Uri's associated with a user.  http://developer.runkeeper.com/healthgraph/users  
    /// </summary>
    public class UsersEndpoint : IUsersEndpoint
    {
        #region Fields and Properties

        private const string UriResource = "user"; 
        private AccessTokenManagerBase _tokenManager;

        #endregion

        #region Constructors

        public UsersEndpoint(AccessTokenManagerBase tokenManager)
        {
            _tokenManager = tokenManager;
        }

        #endregion

        #region IUsersEndpoint

        public UsersModel GetUser()
        {
            var request = new RestRequest(Method.GET);
            request.Resource = UriResource;
            return _tokenManager.Execute<UsersModel>(request);
        }

        public void GetUserAsync(Action<UsersModel> success, Action<HealthGraphException> failure)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = UriResource;
            _tokenManager.ExecuteAsync<UsersModel>(request, success, failure);
        }

        #endregion
    }
}