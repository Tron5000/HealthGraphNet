using System;
using RestSharp;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    /// <summary>
    /// Wrapper for retrieving the Uri's associated with a user.  http://developer.runkeeper.com/healthgraph/users  
    /// </summary>
    public class Users : IUsers
    {
        #region Fields and Properties

        private AccessTokenManagerBase _tokenManager;
        private const string UriResource = "user"; 

        #endregion

        #region Constructors

        public Users(AccessTokenManagerBase tokenManager)
        {
            _tokenManager = tokenManager;
        }

        #endregion

        #region IUsers

        public UserModel GetUser()
        {
            var request = new RestRequest(Method.GET);
            request.Resource = UriResource;
            return _tokenManager.Execute<UserModel>(request);
        }

        public void GetUserAsync(Action<UserModel> success, Action<HealthGraphException> failure)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = UriResource;
            _tokenManager.ExecuteAsync<UserModel>(request, success, failure);
        }

        #endregion
    }
}