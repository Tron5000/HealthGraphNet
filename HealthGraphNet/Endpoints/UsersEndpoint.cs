using System;
using RestSharp.Portable;
using HealthGraphNet.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    /// <summary>
    /// Endpoint for retrieving the Uri's associated with a user.  http://developer.runkeeper.com/healthgraph/users  
    /// </summary>
    public class UsersEndpoint : IUsersEndpoint
    {
        #region Fields and Properties

        private const string UriResource = "user"; 
        private Client _tokenManager;

        #endregion

        #region Constructors

        public UsersEndpoint(Client tokenManager)
        {
            _tokenManager = tokenManager;
        }

        #endregion

        #region IUsersEndpoint

        public async Task<UsersModel> GetUser()
        {
            var request = new RestRequest(UriResource, Method.GET);
            return await _tokenManager.Execute<UsersModel>(request);
        }

        #endregion
    }
}